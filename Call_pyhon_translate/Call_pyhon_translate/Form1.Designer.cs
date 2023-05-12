namespace Call_pyhon_translate
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
            this.txtSource = new System.Windows.Forms.TextBox();
            this.cbox_lang1 = new System.Windows.Forms.ComboBox();
            this.btn_Doi = new System.Windows.Forms.Button();
            this.cbox_Lang2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_translate = new System.Windows.Forms.Button();
            this.txtKQ = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbel_status = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.ForeColor = System.Drawing.SystemColors.Desktop;
            this.txtSource.Location = new System.Drawing.Point(56, 41);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(562, 135);
            this.txtSource.TabIndex = 0;
            // 
            // cbox_lang1
            // 
            this.cbox_lang1.BackColor = System.Drawing.SystemColors.Window;
            this.cbox_lang1.FormattingEnabled = true;
            this.cbox_lang1.Location = new System.Drawing.Point(142, 194);
            this.cbox_lang1.Name = "cbox_lang1";
            this.cbox_lang1.Size = new System.Drawing.Size(184, 24);
            this.cbox_lang1.TabIndex = 15;
            // 
            // btn_Doi
            // 
            this.btn_Doi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Doi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Doi.Location = new System.Drawing.Point(341, 188);
            this.btn_Doi.Name = "btn_Doi";
            this.btn_Doi.Size = new System.Drawing.Size(62, 35);
            this.btn_Doi.TabIndex = 2;
            this.btn_Doi.Text = "< >";
            this.btn_Doi.UseVisualStyleBackColor = true;
            this.btn_Doi.Click += new System.EventHandler(this.btn_Doi_Click);
            // 
            // cbox_Lang2
            // 
            this.cbox_Lang2.BackColor = System.Drawing.SystemColors.Control;
            this.cbox_Lang2.FormattingEnabled = true;
            this.cbox_Lang2.Location = new System.Drawing.Point(453, 193);
            this.cbox_Lang2.Name = "cbox_Lang2";
            this.cbox_Lang2.Size = new System.Drawing.Size(165, 24);
            this.cbox_Lang2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(409, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Translate";
            // 
            // btn_translate
            // 
            this.btn_translate.Location = new System.Drawing.Point(636, 164);
            this.btn_translate.Name = "btn_translate";
            this.btn_translate.Size = new System.Drawing.Size(87, 58);
            this.btn_translate.TabIndex = 6;
            this.btn_translate.Text = "Translate";
            this.btn_translate.UseVisualStyleBackColor = true;
            this.btn_translate.Click += new System.EventHandler(this.btn_translate_Click);
            // 
            // txtKQ
            // 
            this.txtKQ.Location = new System.Drawing.Point(56, 262);
            this.txtKQ.Multiline = true;
            this.txtKQ.Name = "txtKQ";
            this.txtKQ.Size = new System.Drawing.Size(562, 171);
            this.txtKQ.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 439);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 38);
            this.button1.TabIndex = 8;
            this.button1.Text = "btn_Talk";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbel_status
            // 
            this.lbel_status.AutoSize = true;
            this.lbel_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbel_status.Location = new System.Drawing.Point(156, 452);
            this.lbel_status.Name = "lbel_status";
            this.lbel_status.Size = new System.Drawing.Size(74, 25);
            this.lbel_status.TabIndex = 9;
            this.lbel_status.Text = "Status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(56, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Write to Translate:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 489);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbel_status);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtKQ);
            this.Controls.Add(this.btn_translate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbox_Lang2);
            this.Controls.Add(this.btn_Doi);
            this.Controls.Add(this.cbox_lang1);
            this.Controls.Add(this.txtSource);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.ComboBox cbox_lang1;
        private System.Windows.Forms.Button btn_Doi;
        private System.Windows.Forms.ComboBox cbox_Lang2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_translate;
        private System.Windows.Forms.TextBox txtKQ;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbel_status;
        private System.Windows.Forms.Label label4;
    }
}

