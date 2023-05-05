namespace PlayMP3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PLAY = new System.Windows.Forms.Button();
            this.STOP = new System.Windows.Forms.Button();
            this.PAUSE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PLAY
            // 
            this.PLAY.Location = new System.Drawing.Point(12, 143);
            this.PLAY.Name = "PLAY";
            this.PLAY.Size = new System.Drawing.Size(146, 73);
            this.PLAY.TabIndex = 0;
            this.PLAY.Text = "PLAY";
            this.PLAY.UseVisualStyleBackColor = true;
            this.PLAY.Click += new System.EventHandler(this.PLAY_Click);
            // 
            // STOP
            // 
            this.STOP.Location = new System.Drawing.Point(317, 143);
            this.STOP.Name = "STOP";
            this.STOP.Size = new System.Drawing.Size(146, 73);
            this.STOP.TabIndex = 1;
            this.STOP.Text = "STOP";
            this.STOP.UseVisualStyleBackColor = true;
            this.STOP.Click += new System.EventHandler(this.STOP_Click);
            // 
            // PAUSE
            // 
            this.PAUSE.Location = new System.Drawing.Point(164, 143);
            this.PAUSE.Name = "PAUSE";
            this.PAUSE.Size = new System.Drawing.Size(146, 73);
            this.PAUSE.TabIndex = 2;
            this.PAUSE.Text = "PAUSE";
            this.PAUSE.UseVisualStyleBackColor = true;
            this.PAUSE.Click += new System.EventHandler(this.PAUSE_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 319);
            this.Controls.Add(this.PAUSE);
            this.Controls.Add(this.STOP);
            this.Controls.Add(this.PLAY);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PLAY;
        private System.Windows.Forms.Button STOP;
        private System.Windows.Forms.Button PAUSE;
    }
}

