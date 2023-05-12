using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayMP3
{
    public partial class Form1 : Form
    {
        WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();
        public Form1()
        {
            InitializeComponent();
        }

        private void PLAY_Click(object sender, EventArgs e)
        {
            Player.URL = @"D:\\Alec Benjamin - If We Have Each Other [Live from Irving Plaza].mp3";
            Player.controls.play();

        }

        private void STOP_Click(object sender, EventArgs e)
        {
            Player.controls.stop();
            
        }

        private void PAUSE_Click(object sender, EventArgs e)
        {

             Player.controls.pause();
             Player.controls.play();

        }

    }
}
