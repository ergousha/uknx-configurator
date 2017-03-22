using System;
using System.Windows.Forms;

namespace uKNX_Configurator
{
    public partial class frmDeviceSettings : Form
    {
        public GatewayItem Gateway { get; set; }
        public frmDeviceSettings(GatewayItem gw)
        {
            InitializeComponent();
            btnCancel.DialogResult = DialogResult.Cancel;
            Gateway = gw;
            if (gw.DhcpEnabled)
            {
                cbDhcpEnabled.Checked = true;
            }
            else
            {
                tbIpAddress.Text = gw.StaticIP;
                tbSubnetMask.Text = gw.StaticSubnet;
                tbGatewayAddress.Text = gw.StaticGateway;
                tbDns1.Text = gw.StaticDns1;
                tbDns2.Text = gw.StaticDns2;
            }
            if (gw.LocalUdpEnabled) cbLocalServerEnabled.Checked = true;
            if (gw.BroadcastKnx) cbBroadcastKnxTraffic.Checked = true;

            cbDhcpEnabled.Focus();
        }

        private void cbDhcpEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDhcpEnabled.Checked)
            {
                tbIpAddress.Enabled = false;
                tbSubnetMask.Enabled = false;
                tbGatewayAddress.Enabled = false;
                tbDns1.Enabled = false;
                tbDns2.Enabled = false;

                tbIpAddress.Text = "";
                tbSubnetMask.Text = "";
                tbGatewayAddress.Text = "";
                tbDns1.Text = "";
                tbDns2.Text = "";
            }
            else
            {
                MessageBox.Show("You have selected not using DHCP. Please check your inputs twice, a wrong entry may cause your gateway inaccessable", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                tbIpAddress.Enabled = true;
                tbSubnetMask.Enabled = true;
                tbGatewayAddress.Enabled = true;
                tbDns1.Enabled = true;
                tbDns2.Enabled = true;

                tbIpAddress.Text = Gateway.StaticIP;
                tbSubnetMask.Text = Gateway.StaticSubnet;
                tbGatewayAddress.Text = Gateway.StaticGateway;
                tbDns1.Text = Gateway.StaticDns1;
                tbDns2.Text = Gateway.StaticDns2;
            }
        }

        private void cbLocalServerEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLocalServerEnabled.Checked)
            {
                cbBroadcastKnxTraffic.Enabled = true;
            }
            else
            {
                cbBroadcastKnxTraffic.Enabled = false;
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if (cbDhcpEnabled.Checked)
            {
                Gateway.DhcpEnabled = true;
            } else
            {
                Gateway.DhcpEnabled = false;

                if (Helper.ValidateIPv4(tbIpAddress.Text) 
                    && Helper.ValidateIPv4(tbSubnetMask.Text) && Helper.ValidateIPv4(tbGatewayAddress.Text))
                {
                    if (tbSubnetMask.Text != Helper.GetSubnetMask(Helper.GetLocalIPAddress()).ToString())
                    {
                        DialogResult dialogResult = MessageBox.Show("You are trying to set gateway's subnet mask " 
                            + tbSubnetMask.Text + " different than your computer " 
                            + Helper.GetSubnetMask(Helper.GetLocalIPAddress()) 
                            + ". Usually they are both expected same. Inconsistent network settings can make your gateway inaccessable. Are you sure?", "Check input", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }
                    }

                    string computerIp = Helper.GetLocalIPAddress().ToString();

                    if (computerIp.Split('.')[0] != tbIpAddress.Text.Split('.')[0] 
                        || computerIp.Split('.')[1] != tbIpAddress.Text.Split('.')[1] 
                        || computerIp.Split('.')[2] != tbIpAddress.Text.Split('.')[2])
                    {
                        DialogResult dialogResult = MessageBox.Show("You are trying to set gateway's ip address " 
                            + tbIpAddress.Text + " quite different than your computer " + computerIp 
                            + ". Inconsistent network settings can make your gateway inaccessable. Are you sure?", "Check input", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }
                    }

                    Gateway.StaticIP = tbIpAddress.Text;
                    Gateway.StaticSubnet = tbSubnetMask.Text;
                    Gateway.StaticGateway = tbGatewayAddress.Text;
                    Gateway.StaticDns1= tbDns1.Text;
                    Gateway.StaticDns2 = tbDns2.Text;
                } else
                {
                    MessageBox.Show("At least one IP address entered is wrong", "Check input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Gateway.LocalUdpEnabled = (cbLocalServerEnabled.Checked) ? true : false;
            Gateway.BroadcastKnx = (cbBroadcastKnxTraffic.Checked) ? true : false;

            DialogResult = DialogResult.OK;
        }

        private void cbDhcpEnabled_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbIpAddress.Focus();
                tbIpAddress.SelectAll();
            }
        }

        private void tbIpAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbSubnetMask.Focus();
                tbSubnetMask.SelectAll();
            }
        }

        private void tbSubnetMask_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbGatewayAddress.Focus();
                tbGatewayAddress.SelectAll();
            }
        }

        private void tbGatewayAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbLocalServerEnabled.Focus();
            }
        }

        private void cbLocalServerEnabled_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbBroadcastKnxTraffic.Focus();
            }
        }

        private void cbBroadcastKnxTraffic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSaveSettings.Focus();
            }
        }
    }
}
