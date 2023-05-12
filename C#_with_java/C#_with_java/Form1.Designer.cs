namespace C__with_java
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_A = new System.Windows.Forms.TextBox();
            this.txt_B = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Ket_qua = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_call_java = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(154, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "A =";
            // 
            // txt_A
            // 
            this.txt_A.Location = new System.Drawing.Point(211, 70);
            this.txt_A.Multiline = true;
            this.txt_A.Name = "txt_A";
            this.txt_A.Size = new System.Drawing.Size(264, 44);
            this.txt_A.TabIndex = 1;
            // 
            // txt_B
            // 
            this.txt_B.Location = new System.Drawing.Point(211, 131);
            this.txt_B.Multiline = true;
            this.txt_B.Name = "txt_B";
            this.txt_B.Size = new System.Drawing.Size(264, 44);
            this.txt_B.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(153, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "B =";
            // 
            // Ket_qua
            // 
            this.Ket_qua.Location = new System.Drawing.Point(211, 260);
            this.Ket_qua.Multiline = true;
            this.Ket_qua.Name = "Ket_qua";
            this.Ket_qua.Size = new System.Drawing.Size(264, 150);
            this.Ket_qua.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(153, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ket qua:";
            // 
            // btn_call_java
            // 
            this.btn_call_java.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_call_java.Location = new System.Drawing.Point(268, 193);
            this.btn_call_java.Name = "btn_call_java";
            this.btn_call_java.Size = new System.Drawing.Size(207, 44);
            this.btn_call_java.TabIndex = 6;
            this.btn_call_java.Text = "Call Java";
            this.btn_call_java.UseVisualStyleBackColor = true;
            this.btn_call_java.Click += new System.EventHandler(this.btn_call_java_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 450);
            this.Controls.Add(this.btn_call_java);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Ket_qua);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_B);
            this.Controls.Add(this.txt_A);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_A;
        private System.Windows.Forms.TextBox txt_B;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Ket_qua;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_call_java;
    }
}

