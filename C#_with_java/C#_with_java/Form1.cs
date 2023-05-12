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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace C__with_java
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_call_java_Click(object sender, EventArgs e)
        {

            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                WorkingDirectory = "D:\\C#_programming\\Githubfolder\\C_Sharp\\C#_with_java",
                FileName = @"C:\Program Files\Java\jdk-17\bin\java.exe",
                Arguments = $"duycop.java {txt_A.Text} \"{txt_B.Text}",
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                UseShellExecute = false
            };
            try
            {
                Process p = Process.Start(startInfo);
                p.WaitForExit();

                while (!p.StandardOutput.EndOfStream)
                {
                    string line = p.StandardOutput.ReadLine(); // tên file                                            
                                                               //do somthing with line  
                    Ket_qua.AppendText(line + "\r\n");//axWindowsMediaPlayer1.Ctlcontrols.play();
                }
            }
            catch (Exception ex)
            {
                Ket_qua.AppendText($"Error: {ex.Message}");
            }

        }
    }
}
