using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;

namespace uKNX_Configurator
{
    public partial class frmDiscoverer : Form
    {
        private static volatile List<GatewayItem> mFoundGateways;

        private static object syncRoot = new Object();

        UdpClient UdpClient = new UdpClient(4201);

        IPEndPoint broadcastIp = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 4200);

        public frmDiscoverer()
        {
            InitializeComponent();
        }

        public static List<GatewayItem> FoundGateways
        {
            get
            {
                if (mFoundGateways == null)
                {
                    lock (syncRoot)
                    {
                        if (mFoundGateways == null)
                        {
                            mFoundGateways = new List<GatewayItem>();
                        }
                    }
                }

                return mFoundGateways;
            }
        }

        private void AddIPAddress2Gateways(string IP, string MAC, string Model, string Firmware)
        {
            GatewayItem item = new GatewayItem();
            item.IP = IP;
            item.Mac = MAC;
            item.Model = Model;
            item.Firmware = Firmware;
            FoundGateways.Add(item);
            Debug.WriteLine("Gateways collection now has " + FoundGateways.Count.ToString() + " element(s)");
            UpdateFoundDeviceLabel(FoundGateways.Count);
            AddDiscoveryEntry(item.IP + "\n" + item.Mac + "\n" + item.Model + "\n" + item.Firmware);
        }

        public void UpdateFoundDeviceLabel(int deviceFound)
        {
            if (lblFoundDevices.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    lblFoundDevices.Text = deviceFound.ToString() 
                    + " device(s) found, double click on them to edit settings..";
                }
                ));
            }
            else
            {
                lblFoundDevices.Text = deviceFound.ToString()
                + " device(s) found, double click on them to edit settings..";
            }
        }

        public void AddDiscoveryEntry(object o)
        {
            if (listView1.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    listView1.Items.Add(new ListViewItem(((string)(o)).Split('\n')));
                    listView1.Items[listView1.Items.Count-1].Selected = true;
                    listView1.Select();
                }
                ));
            }
            else
            {
                listView1.Items.Add(new ListViewItem(((string)(o)).Split('\n')));
                listView1.Items[listView1.Items.Count - 1].Selected = true;
                listView1.Select();
            }
        }

        public void AddKnxMessageEntry(string msg)
        {
            if (listView1.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    tbKnxTraffic.AppendText(DateTime.Now.ToString("HH:mm:ss") + "-> " + msg + Environment.NewLine);
                }
                ));
            }
            else
            {
                tbKnxTraffic.AppendText(DateTime.Now.ToString("HH:mm:ss") + "-> " + msg + Environment.NewLine);
            }
        }

        public void RemoveDiscoveryEntry(string mac)
        {
            if (listView1.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[1].Text == mac)
                            listView1.Items.Remove(item);
                    }
                }
                ));
            }
            else
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.SubItems[1].Text == mac)
                        listView1.Items.Remove(item);
                }
            }
        }

        private void recv(IAsyncResult res)
        {
            byte[] received = new byte[1];
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 4200);
            try
            {
                received = UdpClient.EndReceive(res, ref RemoteIpEndPoint);
            }
            catch (SocketException e)
            {
                Debug.WriteLine(e.Message);
                return;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return;
            }
            finally
            {
                UdpClient.BeginReceive(new AsyncCallback(recv), null);
            }
            
            if (received[0] == 0x5A)
            {
                switch (received[2]) // Message Type
                {
                    case 0x74:
                    case 0x75:
                    case 0x76:
                        AddKnxMessageEntry(ParseKNXTelegram(received) + " Demopad: " + KNX2Demopad(received));
                        break;

                    case 0x30:
                        string rcvString = Encoding.ASCII.GetString(received);

                        int i = rcvString.IndexOf("\0");
                        int y = rcvString.IndexOf("\0", i + 1);

                        string ModelString = rcvString.Substring(3, (i - 3));
                        string FirmwareString = rcvString.Substring(i + 1, (y - i - 1));

                        string ReceivedMAC = Convert.ToByte(received[received.Length - 7]).ToString("X2") + ":"
                            + Convert.ToByte(received[received.Length - 6]).ToString("X2") + ":"
                            + Convert.ToByte(received[received.Length - 5]).ToString("X2") + ":"
                            + Convert.ToByte(received[received.Length - 4]).ToString("X2") + ":"
                            + Convert.ToByte(received[received.Length - 3]).ToString("X2") + ":"
                            + Convert.ToByte(received[received.Length - 2]).ToString("X2");

                        GatewayItem isAnyGateway = null;
                        try
                        {
                            isAnyGateway = FoundGateways.First(w => w.Mac == ReceivedMAC);
                        }
                        catch (Exception e) // Not found in list
                        {
                            Debug.WriteLine(e.Message);
                        } 
                        finally // Found in list already
                        {
                            Debug.WriteLine("Recieved MAC " + ReceivedMAC + " is found in the list already and removed");
                            RemoveDiscoveryEntry(ReceivedMAC);
                            FoundGateways.Remove(isAnyGateway);
                        }
                        
                        AddIPAddress2Gateways(RemoteIpEndPoint.Address.ToString(), ReceivedMAC, ModelString, FirmwareString);

                        byte[] GetSettings = { 0x5A, 0x01, 0x31, 0x00 };
                        GetSettings[3] = Helper.calculateChecksum(GetSettings);

                        IPEndPoint remoteIp = new IPEndPoint(RemoteIpEndPoint.Address, 4200);
                        UdpClient.Send(GetSettings, GetSettings.Length, remoteIp);

                        break;

                    case 0x31:

                        if (received[1] == 0x01 && received.Length == 4)
                        {
                            MessageBox.Show("Settings successfully saved", "Affirmative", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }

                        if (received[1] != 0x19 || received.Length != 28)
                        {
                            break;
                        }

                        Debug.WriteLine("Device settings recieved: " + BitConverter.ToString(received));

                        GatewayItem gw = new GatewayItem();
                        try
                        {
                            gw = FoundGateways.First(w => w.IP == RemoteIpEndPoint.Address.ToString());
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.Message);
                            return;
                        }
                        finally
                        {
                            gw.StaticIP = Convert.ToString(received[10]) + "." + Convert.ToString(received[9]) + "." + Convert.ToString(received[8]) + "." + Convert.ToString(received[7]);
                            gw.StaticSubnet = Convert.ToString(received[14]) + "." + Convert.ToString(received[13]) + "." + Convert.ToString(received[12]) + "." + Convert.ToString(received[11]);
                            gw.StaticGateway = Convert.ToString(received[18]) + "." + Convert.ToString(received[17]) + "." + Convert.ToString(received[16]) + "." + Convert.ToString(received[15]);
                            gw.StaticDns1 = Convert.ToString(received[22]) + "." + Convert.ToString(received[21]) + "." + Convert.ToString(received[20]) + "." + Convert.ToString(received[19]);
                            gw.StaticDns2 = Convert.ToString(received[26]) + "." + Convert.ToString(received[25]) + "." + Convert.ToString(received[24]) + "." + Convert.ToString(received[23]);
                            if (received[4] > 0) gw.DhcpEnabled = true; else gw.DhcpEnabled = false;
                            if (received[5] > 0) gw.LocalUdpEnabled = true; else gw.LocalUdpEnabled = false;
                            if (received[6] == 0) gw.BroadcastKnx = true; else gw.BroadcastKnx = false;
                        }

                        break;

                    case 0x3F:
                        //MessageBox.Show("Awaiting firmware upload for 4 seconds", "Affirmative", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        

                        break;

                    default:
                        break;
                }
            }
        }

        private void frmDiscoverer_Load(object sender, EventArgs ev)
        {
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            Text = Text + " " + version.Major + "." + version.Minor + " (build " + version.Build + ")"; //change form title

            byte[] DiscoverDevice = { 0x5A, 0x01, 0x30, 0x00 };
            DiscoverDevice[3] = Helper.calculateChecksum(DiscoverDevice);

            UdpClient.BeginReceive(new AsyncCallback(recv), null);
            UdpClient.Send(DiscoverDevice, DiscoverDevice.Length, broadcastIp);

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count==0)
            {
                MessageBox.Show("Please first select a device from the list", "Can not continue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmDeviceSettings frmDeviceSettings = new frmDeviceSettings(FoundGateways.First(i => i.IP == listView1.SelectedItems[0].SubItems[0].Text));
            frmDeviceSettings.ShowDialog();

            if (frmDeviceSettings.DialogResult == DialogResult.OK)
            {
                byte[] SetSettings = new byte[28];
                Array.Clear(SetSettings, 0, SetSettings.Length);

                SetSettings[0] = 0x5A;
                SetSettings[1] = 0x19;
                SetSettings[2] = 0x31;
                SetSettings[3] = 0x00; // Cloud Service
                SetSettings[4] = (frmDeviceSettings.Gateway.DhcpEnabled) ? (byte)0x01 : (byte)0x00;
                SetSettings[5] = (frmDeviceSettings.Gateway.LocalUdpEnabled) ? (byte)0x01 : (byte)0x00;
                SetSettings[6] = (frmDeviceSettings.Gateway.BroadcastKnx) ? (byte)0x00 : (byte)0x01;
                SetSettings[7] = Convert.ToByte(frmDeviceSettings.Gateway.StaticIP.Split('.')[3]);
                SetSettings[8] = Convert.ToByte(frmDeviceSettings.Gateway.StaticIP.Split('.')[2]);
                SetSettings[9] = Convert.ToByte(frmDeviceSettings.Gateway.StaticIP.Split('.')[1]);
                SetSettings[10] = Convert.ToByte(frmDeviceSettings.Gateway.StaticIP.Split('.')[0]);
                SetSettings[11] = Convert.ToByte(frmDeviceSettings.Gateway.StaticSubnet.Split('.')[3]);
                SetSettings[12] = Convert.ToByte(frmDeviceSettings.Gateway.StaticSubnet.Split('.')[2]);
                SetSettings[13] = Convert.ToByte(frmDeviceSettings.Gateway.StaticSubnet.Split('.')[1]);
                SetSettings[14] = Convert.ToByte(frmDeviceSettings.Gateway.StaticSubnet.Split('.')[0]);
                SetSettings[15] = Convert.ToByte(frmDeviceSettings.Gateway.StaticGateway.Split('.')[3]);
                SetSettings[16] = Convert.ToByte(frmDeviceSettings.Gateway.StaticGateway.Split('.')[2]);
                SetSettings[17] = Convert.ToByte(frmDeviceSettings.Gateway.StaticGateway.Split('.')[1]);
                SetSettings[18] = Convert.ToByte(frmDeviceSettings.Gateway.StaticGateway.Split('.')[0]);
                SetSettings[19] = Convert.ToByte(frmDeviceSettings.Gateway.StaticDns1.Split('.')[3]);
                SetSettings[20] = Convert.ToByte(frmDeviceSettings.Gateway.StaticDns1.Split('.')[2]);
                SetSettings[21] = Convert.ToByte(frmDeviceSettings.Gateway.StaticDns1.Split('.')[1]);
                SetSettings[22] = Convert.ToByte(frmDeviceSettings.Gateway.StaticDns1.Split('.')[0]);
                SetSettings[23] = Convert.ToByte(frmDeviceSettings.Gateway.StaticDns2.Split('.')[3]);
                SetSettings[24] = Convert.ToByte(frmDeviceSettings.Gateway.StaticDns2.Split('.')[2]);
                SetSettings[25] = Convert.ToByte(frmDeviceSettings.Gateway.StaticDns2.Split('.')[1]);
                SetSettings[26] = Convert.ToByte(frmDeviceSettings.Gateway.StaticDns2.Split('.')[0]);

                SetSettings[27] = Helper.calculateChecksum(SetSettings);

                Debug.WriteLine("Sending save settings UDP command: " + BitConverter.ToString(SetSettings));
                IPEndPoint remoteIp = new IPEndPoint(IPAddress.Parse(listView1.SelectedItems[0].SubItems[0].Text), 4200);
                UdpClient.Send(SetSettings, SetSettings.Length, remoteIp);
            }
            else
            {
                frmDeviceSettings.Dispose();
            }
        }

        private void pbKknxGroupAddress_Click(object sender, EventArgs e)
        {
            MessageBox.Show("KNX Group adress format is between 0/0/1 and 15/7/255", "Input Format", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pbValue_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Value will be converted depending on value type\r\n"+
                "For 1-6 Bit type, value can be between 0-63 decimal\r\n" +
                "For 1 byte type, value can be beetween 0-255 decimal\r\n" +
                "For 2 byte type, value will be converted depending on DPT9\r\n", "Input Format", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tbKnxGroupAddress_Validating(object sender, CancelEventArgs e)
        {
            
            String strpattern = @"\b([0-9]|[1]?[0-5]?)\/[0-7]\/(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b"; //Pattern is Ok
            Regex regex = new Regex(strpattern);
            if (!regex.Match(tbKnxGroupAddress.Text).Success)
            {
                Debug.WriteLine("passed");
            } else
            {
                //Debug.WriteLine("error");
            }
        }

        private void btnBuildRead_Click(object sender, EventArgs e)
        {
            tbDemopadCommand.Text = KNX2Demopad(buildKNXTelegram(0x71));
            Clipboard.SetText(tbDemopadCommand.Text);
        }

        private void btnBuildWrite_Click(object sender, EventArgs e)
        {
            tbDemopadCommand.Text = KNX2Demopad(buildKNXTelegram(0x70));
            Clipboard.SetText(tbDemopadCommand.Text);
        }

        private void btnBuildFeedback_Click(object sender, EventArgs e)
        {
            tbDemopadCommand.Text = KNX2Demopad(buildKNXTelegram(0x76));
            Clipboard.SetText(tbDemopadCommand.Text);
        }

        private void btnWriteRcv_Click(object sender, EventArgs e)
        {
            tbDemopadCommand.Text = KNX2Demopad(buildKNXTelegram(0x74));
            Clipboard.SetText(tbDemopadCommand.Text);
        }

        private byte[] buildKNXTelegram(byte commandType)
        {
            if (commandType == 0x71)
            {
                byte[] knxMessage = { 0x5A, 0x03, commandType, 0x00, 0x00, 0x00 };
                int knxAddress = 0;

                try
                {
                    knxAddress = KNXConversion.GroupETS2Addr(tbKnxGroupAddress.Text);
                }
                catch
                {
                    MessageBox.Show("KNX Group Address Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
                finally
                {
                    knxMessage[3] = (byte)(knxAddress >> 8);
                    knxMessage[4] = (byte)(knxAddress % 256);
                }

                knxMessage[5] = Helper.calculateChecksum(knxMessage);

                return knxMessage;
            }
            else
            {
                byte[] knxMessage = { 0x5A, 0x05, commandType, 0x00, 0x00, 0x00, 0x00, 0x00 };
                byte val = 0;

                switch (cbValueType.SelectedIndex)
                {
                    case -1: // Nothing selected
                        MessageBox.Show("You have to select a value type", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return null;

                    case 0: // 1-6 Bit
                        knxMessage = new byte[] { 0x5A, 0x05, commandType, 0x00, 0x00, 0x00, 0x00, 0x00 };

                        try
                        {
                            val = Convert.ToByte(tbValue.Text);
                        }
                        catch
                        {
                            MessageBox.Show("For 1-6 Bit type, value can be between 0-63 decimal", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return null;
                        }
                        finally
                        {
                            knxMessage[6] = val;
                        }

                        if (val < 0 || val > 63)
                        {
                            MessageBox.Show("For 1-6 Bit type, value can be between 0-63 decimal", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return null;
                        }

                        break;

                    case 1: // 1 Byte
                        knxMessage = new byte[] { 0x5A, 0x05, commandType, 0x00, 0x00, 0x00, 0x00, 0x00 };
                        knxMessage[5] = 0x01;

                        try
                        {
                            val = Convert.ToByte(tbValue.Text);
                        }
                        catch
                        {
                            MessageBox.Show("For 1 byte type, value can be beetween 0-255 decimal", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return null;
                        }
                        finally
                        {
                            knxMessage[6] = val;
                        }

                        if (val < 0 || val > 255)
                        {
                            MessageBox.Show("For 1 byte type, value can be beetween 0-255 decimal", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return null;
                        }
                        break;

                    case 2: // 2 Byte
                        knxMessage = new byte[] { 0x5A, 0x06, commandType, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                        int convertedValue = 0;
                        knxMessage[5] = 0x02;

                        try
                        {
                            convertedValue = KNXConversion.Value2Eis5(Convert.ToDouble(tbValue.Text));
                        }
                        catch
                        {
                            MessageBox.Show("For 2 byte type, value will be converted depending on DPT9", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return null;
                        }
                        finally
                        {
                            knxMessage[6] = (byte)(convertedValue >> 8);
                            knxMessage[7] = (byte)(convertedValue % 256);
                        }

                        break;
                }

                int knxAddress = 0;
                try
                {
                    knxAddress = KNXConversion.GroupETS2Addr(tbKnxGroupAddress.Text);
                }
                catch
                {
                    MessageBox.Show("KNX Group Address Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
                finally
                {
                    knxMessage[3] = (byte)(knxAddress >> 8);
                    knxMessage[4] = (byte)(knxAddress % 256);
                }

                knxMessage[knxMessage.Length - 1] = Helper.calculateChecksum(knxMessage);

                return knxMessage;
            }
        }

        private void tbDemopadCommand_KeyDown(object sender, KeyEventArgs e)
        {
            return;
        }

        private void btnTry_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please first select a device from the list", "Can not continue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (tbDemopadCommand.Text == "")
            {
                MessageBox.Show("Command textbox can not be empty, first build a command", "Can not continue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                byte[] command2send = { };
                try
                {
                    command2send = tbDemopadCommand.Text.Split(new string[] { "\\x" }, 
                        StringSplitOptions.RemoveEmptyEntries).Select(s => Convert.ToByte(s, 16)).ToArray();
                }
                catch { return; }
                finally
                {
                    IPEndPoint remoteIp = new IPEndPoint(IPAddress.Parse(listView1.SelectedItems[0].SubItems[0].Text), 4200);
                    AddKnxMessageEntry(ParseKNXTelegram(command2send) + " Demopad: " + KNX2Demopad(command2send));
                    UdpClient.Send(command2send, command2send.Length, remoteIp);
                }
            }
            
        }
    
        private string KNX2Demopad(byte[] b)
        {
            string result = "";

            for (int i = 0; i < b.Length; i++)
            {
                result += @"\x" + string.Format("{0:X2} ", b[i]).Trim();
            }

            return result;
        }

        private string ParseKNXTelegram(byte[] b)
        {
            ushort address = (ushort)(b[3] << 8);
            address += b[4];
            uint usefulData = 0;
            string sUsefulData = "";

            if (b[2] != 0x71 || b[2] != 0x75)
            {
                switch (b[5])
                {
                    case 0:
                    case 1:
                        usefulData = b[6];
                        sUsefulData = b[6].ToString();
                        break;
                    case 2:
                        usefulData = (uint)(b[6] << 8);
                        usefulData += b[7];
                        sUsefulData = KNXConversion.Eis52Value(usefulData).ToString();
                        break;
                    default:

                        break;
                }
            }

            string eventType = "";
            switch (b[2])
            {
                case 0x70:
                    eventType = "Write Sent";
                    break;
                case 0x71:
                    eventType = "Read Sent";
                    break;
                case 0x74:
                    eventType = "Write Recieved";
                    break;
                case 0x75:
                    eventType = "Read Recieved";
                    break;
                case 0x76:
                    eventType = "Response Recieved";
                    break;
            }

            string result = "";
            if (b[2] == 0x71 || b[2] == 0x75)
            {
                result = eventType + ". Address: " + KNXConversion.GroupAddr2Ets(address, 3);
            } else
            {
                result = eventType + ". Address: " + KNXConversion.GroupAddr2Ets(address, 3) + " Length: " + b[5].ToString() + " Data: " + sUsefulData;
            }

            return result;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            byte[] ResetCommand = new byte[4];
            Array.Clear(ResetCommand, 0, ResetCommand.Length);

            ResetCommand[0] = 0x5A;
            ResetCommand[1] = 0x01;
            ResetCommand[2] = 0x3F;
            ResetCommand[3] = Helper.calculateChecksum(ResetCommand);

            IPEndPoint remoteIp = new IPEndPoint(IPAddress.Parse(listView1.SelectedItems[0].SubItems[0].Text), 4200);
UdpClient.Send(ResetCommand, ResetCommand.Length, remoteIp);

Process.Start("c:\\tftp.exe"+ " -i " + remoteIp.Address.ToString() + " put " + "c:\\origin-s-a_130.hex");

            ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.CreateNoWindow = false;
            //startInfo.UseShellExecute = false;
            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Verb = "runas";
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = "tftp.exe";
            startInfo.Arguments = " -i " + remoteIp.Address.ToString() + " put " + "c:\\origin-s-a_130.hex";
            Debug.WriteLine("c:\\tftp.exe" + " -i " + remoteIp.Address.ToString() + " put " + "c:\\origin-s-a_130.hex");
            try
            {
                
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message.ToString());
            }
            finally
            {
                
            }
        }

        private void btn1BitBatch_Click(object sender, EventArgs e)
        {
            string result = "";

            cbValueType.SelectedIndex = 0;

            tbValue.Text = "0";
            result += KNX2Demopad(buildKNXTelegram(0x70));
            result += Environment.NewLine;
            tbValue.Text = "1";
            result += " " + KNX2Demopad(buildKNXTelegram(0x70));
            result += Environment.NewLine;

            tbKnxGroupAddress.Text = tbKnxGroupAddress.Text.Split('/')[0]
                + "/" + tbKnxGroupAddress.Text.Split('/')[1] + "/"
                + (Convert.ToInt16(tbKnxGroupAddress.Text.Split('/')[2]) + 1).ToString();
            
            result += " " + KNX2Demopad(buildKNXTelegram(0x71));
            result += Environment.NewLine;

            tbValue.Text = "0";
            result += " " + KNX2Demopad(buildKNXTelegram(0x76));
            result += Environment.NewLine;
            tbValue.Text = "1";
            result += " " + KNX2Demopad(buildKNXTelegram(0x76));
            result += Environment.NewLine;

            tbValue.Text = "0";
            result += " " + KNX2Demopad(buildKNXTelegram(0x74));
            result += Environment.NewLine;
            tbValue.Text = "1";
            result += " " + KNX2Demopad(buildKNXTelegram(0x74));

            Clipboard.SetText(result);
        }

        private void btn6BitBatch_Click(object sender, EventArgs e)
        {
            string result = "";

            cbValueType.SelectedIndex = 0;

            tbValue.Text = "1";
            result += KNX2Demopad(buildKNXTelegram(0x70));
            result += Environment.NewLine;
            tbValue.Text = "0";
            result += " " + KNX2Demopad(buildKNXTelegram(0x70));
            result += Environment.NewLine;
            tbValue.Text = "9";
            result += KNX2Demopad(buildKNXTelegram(0x70));
            result += Environment.NewLine;
            tbValue.Text = "8";
            result += " " + KNX2Demopad(buildKNXTelegram(0x70));

            Clipboard.SetText(result);
        }

        private void btnCyclicTest_Click(object sender, EventArgs e)
        {
            if (timerCyclic.Enabled) timerCyclic.Enabled = false;
            else
            {
                if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please first select a device from the list", "Can not continue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (tbDemopadCommand.Text == "")
                {
                    MessageBox.Show("Command textbox can not be empty, first build a command", "Can not continue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                timerCyclic.Enabled = true;
            }
        }

        public volatile bool changeOver = false;
        private void timerCyclic_Tick(object sender, EventArgs e)
        {
            byte[] command2send = { };
            try
            {
                if (changeOver)
                {
                    command2send = @"\x5A\x05\x70\x4C\x01\x00\x01\x9C".Split(new string[] { "\\x" },
    StringSplitOptions.RemoveEmptyEntries).Select(s => Convert.ToByte(s, 16)).ToArray();
                }
                else
                {
                    command2send = @"\x5A\x05\x70\x4C\x01\x00\x00\x9D".Split(new string[] { "\\x" },
    StringSplitOptions.RemoveEmptyEntries).Select(s => Convert.ToByte(s, 16)).ToArray();
                }
                changeOver = !changeOver;
            }
            catch { return; }
            finally
            {
                IPEndPoint remoteIp = new IPEndPoint(IPAddress.Parse(listView1.SelectedItems[0].SubItems[0].Text), 4200);
                AddKnxMessageEntry(ParseKNXTelegram(command2send) + " Demopad: " + KNX2Demopad(command2send));
                UdpClient.Send(command2send, command2send.Length, remoteIp);
            }
        }


    }
}
