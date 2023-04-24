namespace Project1_Student
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            label1 = new Label();
            button1 = new Button();
            txt_Masv = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txt_Ten = new TextBox();
            txt_lop = new TextBox();
            txt_diem = new TextBox();
            txt_DiaChi = new TextBox();
            button2 = new Button();
            btn_Edit = new Button();
            button4 = new Button();
            label6 = new Label();
            txt_Id = new TextBox();
            label7 = new Label();
            btn_Exit = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(32, 188);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(606, 141);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 69);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "Masv:";
            // 
            // button1
            // 
            button1.Location = new Point(428, 114);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(82, 22);
            button1.TabIndex = 2;
            button1.Text = "Clear_data";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txt_Masv
            // 
            txt_Masv.Location = new Point(87, 67);
            txt_Masv.Margin = new Padding(3, 2, 3, 2);
            txt_Masv.Name = "txt_Masv";
            txt_Masv.Size = new Size(162, 23);
            txt_Masv.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 92);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 4;
            label2.Text = "Ten:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 140);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 5;
            label3.Text = "Diem";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(51, 118);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 6;
            label4.Text = "Lop:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 169);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 7;
            label5.Text = "Diachi:";
            // 
            // txt_Ten
            // 
            txt_Ten.Location = new Point(87, 92);
            txt_Ten.Margin = new Padding(3, 2, 3, 2);
            txt_Ten.Name = "txt_Ten";
            txt_Ten.Size = new Size(162, 23);
            txt_Ten.TabIndex = 8;
            // 
            // txt_lop
            // 
            txt_lop.Location = new Point(87, 116);
            txt_lop.Margin = new Padding(3, 2, 3, 2);
            txt_lop.Name = "txt_lop";
            txt_lop.Size = new Size(162, 23);
            txt_lop.TabIndex = 9;
            // 
            // txt_diem
            // 
            txt_diem.Location = new Point(87, 141);
            txt_diem.Margin = new Padding(3, 2, 3, 2);
            txt_diem.Name = "txt_diem";
            txt_diem.Size = new Size(162, 23);
            txt_diem.TabIndex = 10;
            // 
            // txt_DiaChi
            // 
            txt_DiaChi.Location = new Point(87, 166);
            txt_DiaChi.Margin = new Padding(3, 2, 3, 2);
            txt_DiaChi.Name = "txt_DiaChi";
            txt_DiaChi.Size = new Size(162, 23);
            txt_DiaChi.TabIndex = 11;
            // 
            // button2
            // 
            button2.Location = new Point(428, 162);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(82, 22);
            button2.TabIndex = 12;
            button2.Text = "Add";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btn_Edit
            // 
            btn_Edit.Location = new Point(556, 114);
            btn_Edit.Margin = new Padding(3, 2, 3, 2);
            btn_Edit.Name = "btn_Edit";
            btn_Edit.Size = new Size(82, 22);
            btn_Edit.TabIndex = 13;
            btn_Edit.Text = "Edit";
            btn_Edit.UseVisualStyleBackColor = true;
            btn_Edit.Click += btn_Edit_Click;
            // 
            // button4
            // 
            button4.Location = new Point(556, 162);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(82, 22);
            button4.TabIndex = 14;
            button4.Text = "Delete";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Stencil", 18F, FontStyle.Italic, GraphicsUnit.Point);
            label6.Location = new Point(291, 21);
            label6.Name = "label6";
            label6.Size = new Size(129, 29);
            label6.TabIndex = 15;
            label6.Text = "StudentS";
            // 
            // txt_Id
            // 
            txt_Id.Location = new Point(87, 42);
            txt_Id.Margin = new Padding(3, 2, 3, 2);
            txt_Id.Name = "txt_Id";
            txt_Id.Size = new Size(162, 23);
            txt_Id.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(60, 44);
            label7.Name = "label7";
            label7.Size = new Size(21, 15);
            label7.TabIndex = 16;
            label7.Text = "ID:";
            // 
            // btn_Exit
            // 
            btn_Exit.Location = new Point(556, 62);
            btn_Exit.Margin = new Padding(3, 2, 3, 2);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(82, 22);
            btn_Exit.TabIndex = 18;
            btn_Exit.Text = "Exit";
            btn_Exit.UseVisualStyleBackColor = true;
            btn_Exit.Click += btn_Exit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            ClientSize = new Size(660, 338);
            Controls.Add(btn_Exit);
            Controls.Add(txt_Id);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(button4);
            Controls.Add(btn_Edit);
            Controls.Add(button2);
            Controls.Add(txt_DiaChi);
            Controls.Add(txt_diem);
            Controls.Add(txt_lop);
            Controls.Add(txt_Ten);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txt_Masv);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button button1;
        private TextBox txt_Masv;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txt_Ten;
        private TextBox txt_lop;
        private TextBox txt_diem;
        private TextBox txt_DiaChi;
        private Button button2;
        private Button btn_Edit;
        private Button button4;
        private Label label6;
        private TextBox txt_Id;
        private Label label7;
        private Button btn_Exit;
    }
}