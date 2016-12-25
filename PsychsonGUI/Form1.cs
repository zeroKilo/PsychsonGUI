using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Be.Windows.Forms;

namespace PsychsonGUI
{
    public partial class Form1 : Form
    {
        public char DriveLetter;
        public PhisonDevice device;
        public Form1()
        {
            InitializeComponent();
        }

        private void driveOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DriveSelector dl = new DriveSelector();
            dl.ShowDialog();
            if (dl.ok && dl.comboBox1.SelectedIndex != -1)
            {
                DriveLetter = dl.comboBox1.Items[dl.comboBox1.SelectedIndex].ToString()[0];
                if (device != null)
                    device.Close();
                device = new PhisonDevice(DriveLetter, rtb2);
                device.Open();
                tabControl1.Enabled = true;
                toolsToolStripMenuItem.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rtb1.Text = "";
            rtb1.AppendText("Gathering information...\n");
            rtb1.AppendText("Reported chip type: " + device.GetChipType().GetValueOrDefault().ToString("X04") + "\n");
            rtb1.AppendText("Reported chip ID: " + device.GetChipID() + "\n");
            rtb1.AppendText("Reported firmware version: " + device.GetFirmwareVersion() + "\n");
            var ret = device.GetRunMode();
            rtb1.AppendText("Mode: " + ret.ToString() + "\n");
            
        }

        private void enterBootmodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isBootMode())
                device.JumpToPRAM();
            else
                device.JumpToBootMode();
            MessageBox.Show("Done.");
        }

        private void flashBurnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isBootMode()) return;
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "*.bin|*.bin";
            d.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath) + "\\img\\burner\\";
            if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    device.TransferFile(File.ReadAllBytes(d.FileName), pb1);
                    device.JumpToPRAM();
                    MessageBox.Show("Done.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:\n" + ex.Message);
                }
            }
        }

        private void flashFirmwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (device.GetRunMode() != PhisonDevice.RunMode.Burner)
            {
                MessageBox.Show("Device is not in burner mode!");
                return;
            }
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "*.bin|*.bin";
            d.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath) + "\\img\\firmware\\";
            if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    RunFirmware(d.FileName);
                    MessageBox.Show("Done.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:\n" + ex.Message);
                }
            }
        }

        private void RunFirmware(string fileName)
        {
            var fw = new FileStream(fileName, FileMode.Open);
            var data = new byte[fw.Length];
            fw.Read(data, 0, data.Length);
            fw.Close();
            device.TransferFile(data, 0x01, 0x00, pb1);
            //var ret = device.SendCommand(new byte[] { 0x06, 0xEE, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, 64 + 8);
            device.TransferFile(data, 0x03, 0x02, pb1);
            //ret = device.SendCommand(new byte[] { 0x06, 0xEE, 0x01, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 }, 64 + 8);
            //ret = device.SendCommand(new byte[] { 0x06, 0xEE, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, 64 + 8);
            //ret = device.SendCommand(new byte[] { 0x06, 0xEE, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 }, 64 + 8);
            device.JumpToPRAM();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog d = new SaveFileDialog();
            d.Filter = "*.bin|*.bin";
            if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MemoryStream m = new MemoryStream();
                for (int i = 0; i < hb1.ByteProvider.Length; i++)
                    m.WriteByte(hb1.ByteProvider.ReadByte(i));
                File.WriteAllBytes(d.FileName, m.ToArray());
                MessageBox.Show("Done.");
            }
        }

        private void traceUSBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            traceUSBToolStripMenuItem.Checked = !traceUSBToolStripMenuItem.Checked;
            PhisonDevice.trace = traceUSBToolStripMenuItem.Checked;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rtb2.Text = "";
        }

        private bool isBootMode()
        {
            if (device == null)
                return false;
            if (device.GetRunMode() != PhisonDevice.RunMode.BootMode)
            {
                MessageBox.Show("Device is not in boot mode!");
                return false;
            }
            return true;
        }

        private void info1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hb1.ByteProvider = new DynamicByteProvider(device.RequestInfo(
                new byte[] { 0x06, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01 }, 528));
        }

        private void info2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hb1.ByteProvider = new DynamicByteProvider(device.RequestInfo(
                new byte[] { 0x06, 0x56, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, 512));
        }

        private void info3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hb1.ByteProvider = new DynamicByteProvider(device.RequestInfo(
                new byte[] { 0x06, 0x05, 0x49, 0x4e, 0x46, 0x4f, 0x00, 0x00, 0x80 }, 528));
        }

        private void sendCustomCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter hex bytes:", "", "06 0d 02 00 00 00 00 00 4c 45 44 00");
            if (input == null || input.Length == 0) return;
            byte[] cmd = StringToByteArray(input.Replace(" ", ""));
            input = Microsoft.VisualBasic.Interaction.InputBox("Enter count of expected return bytes:", "", "18");
            if (input == null || input.Length == 0) return;
            int count = Convert.ToInt32(input);
            byte[] result = device.RequestInfo(cmd, count);
            if (result == null)
                result = new byte[0];
            hb1.ByteProvider = new DynamicByteProvider(result);
        }

        public byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        private void dumpMemoryAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog d = new SaveFileDialog();
            d.Filter = "*.bin|*.bin";
            if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DriveSelector ds = new DriveSelector();
                ds.ShowDialog();
                if (ds.ok && ds.comboBox1.SelectedIndex != -1)
                {
                    char letter = ds.comboBox1.Items[ds.comboBox1.SelectedIndex].ToString()[0];
                    string input = Microsoft.VisualBasic.Interaction.InputBox("Enter region start and size in hex, like XXXX:YYYY", "", "0000:1000");
                    if (input != "" && input.Split(':').Length == 2)
                    {
                        string[] parts = input.Split(':');
                        int start = Convert.ToInt32(parts[0].Trim(), 16);
                        int size = Convert.ToInt32(parts[1].Trim(), 16);
                        if (device != null)
                            device.Close();
                        int leaksize = 0x74;
                        int count = size / leaksize;
                        if (count * leaksize < size)
                            count++;
                        int addr = start;
                        string path = Path.GetDirectoryName(Application.ExecutablePath);
                        byte[] payload = File.ReadAllBytes(path + "\\img\\exploit\\exploit_dump_68.BIN");
                        MemoryStream m = new MemoryStream();
                        for (int i = 0; i < count; i++)
                        {
                            MessageBox.Show("Copy transfer " + (i + 1) + " / " + count + " @0x" + addr.ToString("X4") + " : Please unplug and replug usb stick!");
                            device = new PhisonDevice(letter, rtb2);
                            device.Open();
                            if (device.GetRunMode() != PhisonDevice.RunMode.BootMode)
                            {
                                MessageBox.Show("Device is not in boot mode!");
                                break;
                            }
                            payload[0x35a4] = (byte)(addr >> 8);//0x18 bytes
                            payload[0x35a6] = (byte)(addr & 0xFF);
                            payload[0x35ad] = (byte)((addr + 0x18) >> 8);//0x40 bytes
                            payload[0x35af] = (byte)((addr + 0x18) & 0xFF);
                            payload[0x35bd] = (byte)((addr + 0x58) >> 8);//0x10 bytes
                            payload[0x35bf] = (byte)((addr + 0x58) & 0xFF);
                            payload[0x35c8] = (byte)((addr + 0x68) >> 8);//0x8 bytes
                            payload[0x35ca] = (byte)((addr + 0x68) & 0xFF);
                            payload[0x35d3] = (byte)((addr + 0x70) >> 8);//0x4 bytes
                            payload[0x35d5] = (byte)((addr + 0x70) & 0xFF);
                            device.TransferFile(payload, pb1);
                            device.JumpToPRAM();
                            byte[] buff = device.RequestInfo(new byte[] { 0x06, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01 }, 528);
                            m.Write(buff, 0x36, 0x18);
                            m.Write(buff, 0x50, 0x40);
                            m.Write(buff, 0x9C, 0x10);
                            m.Write(buff, 0xB0, 0x8);
                            m.Write(buff, 0xB8, 0x4);
                            device.Close();
                            addr += leaksize;
                        }
                        File.WriteAllBytes(d.FileName, m.ToArray());
                        MessageBox.Show("Done.");
                    }
                }
            }
        }
    }
}
