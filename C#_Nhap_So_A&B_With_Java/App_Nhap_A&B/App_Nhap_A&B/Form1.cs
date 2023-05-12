using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Nhap_A_B
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Cal_java_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "\"C:\\Program Files\\Java\\jdk-17\\bin\\java.exe\"";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.RedirectStandardOutput = true;
            startInfo.WorkingDirectory = "D:\\C#_programming\\C#_Nhap_So_A&B_With_Java";
            startInfo.Arguments = $"duycop {txt_Nhap_A.Text} {txt_Nhap_B.Text}";

            try
            {
                using(Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                    while(!exeProcess.StandardOutput.EndOfStream)
                    {
                        String line = exeProcess.StandardOutput.ReadLine();
                        //do something with line
                        txt_Ket_qua.AppendText(line + "\r\n");
                    }
                }
            }
            catch (Exception ex)
            {
                txt_Ket_qua.AppendText($"ERROR: {ex.Message}");
            }
        }
    }
}
