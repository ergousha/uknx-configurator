using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace uKNX_Configurator
{
    public static class KNXConversion
    {
        public static int Hex2Dec(string hex, int maxDigits)
        {
            string hexNumber = "0123456789ABCDEF";
            int address = 0;

            hex = hex.ToUpper();
            if (hex.Length > maxDigits)
                return 0;

            for (int byteCount = 0; byteCount < hex.Length; byteCount++)
            {
                if (hexNumber.IndexOf(hex.Substring(byteCount, byteCount + 1)) == -1)
                    return 0;
                else
                    address = address * 16 + hexNumber.IndexOf(hex.Substring(byteCount, byteCount + 1));
            }
            return address;
        }

        public static string Dec2Hex(int dec, int hexDigits)
        {
            string hexNumber = "0123456789ABCDEF";
            string hex = "";
            if (dec > Math.Pow(16, hexDigits))
                return "";

            while (hexDigits > 0)
            {
                hex = hexNumber.Substring(dec % 16, dec % 16 + 1) + hex;
                dec = dec / 16;
                hexDigits = hexDigits - 1;
            }
            return hex;
        }

        public static UInt16 GroupETS2Addr(string etsString)
        {
            int address = 0;
            if (etsString.IndexOf("/") == -1)
                return 0;

            address = Convert.ToInt32(etsString.Substring(0, etsString.IndexOf("/"))) * 2048;
            etsString = etsString.Substring(etsString.IndexOf("/") + 1);

            if (etsString.IndexOf("/") == -1)
            {
                address = address + Convert.ToInt32(etsString);
            }
            else
            {
                address = address + Convert.ToInt32(etsString.Substring(0, etsString.IndexOf("/"))) * 256;
                address = address + Convert.ToInt32(etsString.Substring(etsString.IndexOf("/") + 1));
            }
            return (UInt16)address;
        }

        public static string GroupAddr2Ets(UInt16 address, int addrLevel)
        {
            string ets;
            if (addrLevel == 2)
                ets = Math.Floor((double)address / 2048).ToString() + "/" + Math.Floor((double)address % 2048).ToString();
            else
                ets = Math.Floor((double)address / 2048).ToString() + "/" + Math.Floor(((double)address % 2048) / 256).ToString() + "/" + Math.Floor((double)address % 256).ToString();

            return ets;
        }

        public static byte Eis62Percent(byte eis6)
        {
            return (byte)(Math.Round((decimal)eis6 * 1000 / 255) / 10);
        }

        public static byte Percent2Eis6(Double percent)
        {
            return (byte)(Math.Round((decimal)percent * 255 / 100));
        }

        public static byte Eis62Angle(byte eis6)
        {
            return (byte)(Math.Round((decimal)eis6 * 3600 / 255) / 10);
        }

        public static byte Angle2Eis6(Double angle)
        {
            return (byte)(Math.Round((decimal)angle * 255 / 360));
        }

        public static Double Eis52Value(UInt32 eis5)
        {
            Double value = eis5 & 0x07ff;
            if ((eis5 & 0x08000) != 0)
            {
                value = (UInt32)value | 0xfffff800;
                value = -value;
            }

            value = (Int32)value << (((Int32)eis5 & 0x07800) >> 11);
            
            if ((eis5 & 0x08000) != 0)
                value = -value;

            return value/100;
        }

        public static Int32 Value2Eis5(Double value)
        {
            value = value * 100;
            Int32 eis5 = 0;
            byte exponent = 0;

            if (value < 0)
            {
                eis5 = 0x08000;
                value = -value;
            }

            while (value > 0x07ff)
            {
                value = (Int32)value >> 1;
                exponent++;
            }

            if (eis5 != 0)
                value = -value;

            eis5 |= (Int32)value & 0x7ff;
            eis5 |= (exponent << 11) & 0x07800;
            return (Int32)(eis5 & 0x0ffff);
        }

        public static void Test()
        {
            Debug.Write("Eis52Value 0xOCFB = " + (KNXConversion.Eis52Value(3323).ToString()) + "\r\n"); // expected to give 25.5
            Debug.Write("Value2Eis5 25.5 = " + (KNXConversion.Value2Eis5(25.5).ToString()) + "\r\n"); // expected to give 3323 = 0xOCFB
            
            Debug.Write("Eis62Percent 0xCC = " + (KNXConversion.Eis62Percent(204).ToString()) + "\r\n");
            Debug.Write("Eis62Percent 0xFF = " + (KNXConversion.Eis62Percent(255).ToString()) + "\r\n");
            Debug.Write("Eis62Percent 0x00 = " + (KNXConversion.Eis62Percent(0).ToString()) + "\r\n");
            Debug.Write("Percent2Eis6 0.4% = " + (KNXConversion.Percent2Eis6(0.4).ToString()) + "\r\n");
            Debug.Write("Percent2Eis6 100% = " + (KNXConversion.Percent2Eis6(100).ToString()) + "\r\n");
            Debug.Write("Percent2Eis6 0% = " + (KNXConversion.Percent2Eis6(0).ToString()) + "\r\n");

            Debug.Write("Eis62Angle 0x01 = " + (KNXConversion.Eis62Angle(1).ToString()) + "\r\n");
            Debug.Write("Eis62Angle 0xFF = " + (KNXConversion.Eis62Angle(255).ToString()) + "\r\n");
            Debug.Write("Eis62Angle 0x00 = " + (KNXConversion.Eis62Angle(0).ToString()) + "\r\n");
            Debug.Write("Angle2Eis6 1.4 degree = " + (KNXConversion.Angle2Eis6(1.4).ToString()) + "\r\n");
            Debug.Write("Angle2Eis6 360 degree = " + (KNXConversion.Angle2Eis6(360).ToString()) + "\r\n");
            Debug.Write("Angle2Eis6 0 degree = " + (KNXConversion.Angle2Eis6(0).ToString()) + "\r\n");
        }
    }
}
