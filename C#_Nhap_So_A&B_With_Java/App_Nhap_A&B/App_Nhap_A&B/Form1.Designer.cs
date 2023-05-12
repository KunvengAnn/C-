namespace App_Nhap_A_B
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
            this.txt_Nhap_A = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Nhap_B = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Cal_java = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Ket_qua = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_Nhap_A
            // 
            this.txt_Nhap_A.Location = new System.Drawing.Point(162, 90);
            this.txt_Nhap_A.Name = "txt_Nhap_A";
            this.txt_Nhap_A.Size = new System.Drawing.Size(161, 22);
            this.txt_Nhap_A.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhap A=";
            // 
            // txt_Nhap_B
            // 
            this.txt_Nhap_B.Location = new System.Drawing.Point(162, 141);
            this.txt_Nhap_B.Name = "txt_Nhap_B";
            this.txt_Nhap_B.Size = new System.Drawing.Size(161, 22);
            this.txt_Nhap_B.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nhap B=";
            // 
            // btn_Cal_java
            // 
            this.btn_Cal_java.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cal_java.Location = new System.Drawing.Point(146, 191);
            this.btn_Cal_java.Name = "btn_Cal_java";
            this.btn_Cal_java.Size = new System.Drawing.Size(177, 44);
            this.btn_Cal_java.TabIndex = 4;
            this.btn_Cal_java.Text = "Call java";
            this.btn_Cal_java.UseVisualStyleBackColor = true;
            this.btn_Cal_java.Click += new System.EventHandler(this.btn_Cal_java_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Perpetua Titling MT", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(93, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ket qua:";
            // 
            // txt_Ket_qua
            // 
            this.txt_Ket_qua.Location = new System.Drawing.Point(98, 289);
            this.txt_Ket_qua.Multiline = true;
            this.txt_Ket_qua.Name = "txt_Ket_qua";
            this.txt_Ket_qua.Size = new System.Drawing.Size(289, 138);
            this.txt_Ket_qua.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 450);
            this.Controls.Add(this.txt_Ket_qua);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Cal_java);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Nhap_B);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Nhap_A);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Nhap_A;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Nhap_B;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Cal_java;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Ket_qua;
    }
}

