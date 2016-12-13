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
            device.JumpToBootMode();
            Thread.Sleep(2000);
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
                    Thread.Sleep(2000);
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
            var ret = device.SendCommand(new byte[] { 0x06, 0xEE, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, 64 + 8);
            Thread.Sleep(1000);
            device.TransferFile(data, 0x03, 0x02);
            ret = device.SendCommand(new byte[] { 0x06, 0xEE, 0x01, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 }, 64 + 8);
            Thread.Sleep(1000);
            ret = device.SendCommand(new byte[] { 0x06, 0xEE, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, 64 + 8);
            Thread.Sleep(1000);
            ret = device.SendCommand(new byte[] { 0x06, 0xEE, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 }, 64 + 8);
            Thread.Sleep(1000);
            device.JumpToPRAM();
            Thread.Sleep(1000);
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
            hb1.ByteProvider = new DynamicByteProvider(device.RequestInfo(cmd, count));
        }

        public byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
