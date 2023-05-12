using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace C__with_phython_Speak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                WorkingDirectory = @"D:\C#_programming\Githubfolder\C_Sharp\C#_with_Phython_Speak\C#_with_phython_Speak\C#_with_phython_Speak",
                FileName = @"C:\Users\Veng Ann\AppData\Local\Programs\Python\Python311\python.exe",
                Arguments = $"test_voice.py \"{textBox1.Text}",
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process p = Process.Start(startInfo);
            p.WaitForExit();

            while (!p.StandardOutput.EndOfStream)
            {
                string fn = p.StandardOutput.ReadLine(); // tên file
                axWindowsMediaPlayer1.URL = @"D:\C#_programming\Githubfolder\C_Sharp\C#_with_Phython_Speak\C#_with_phython_Speak\C#_with_phython_Speak\" + fn; //play luôn 
                //axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }
    }
}
