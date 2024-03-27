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
            txt_Tim_kiem = new TextBox();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(37, 251);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(693, 188);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 92);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 1;
            label1.Text = "Masv:";
            // 
            // button1
            // 
            button1.Location = new Point(635, 83);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "Clear_data";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txt_Masv
            // 
            txt_Masv.Location = new Point(99, 89);
            txt_Masv.Name = "txt_Masv";
            txt_Masv.Size = new Size(185, 27);
            txt_Masv.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 123);
            label2.Name = "label2";
            label2.Size = new Size(35, 20);
            label2.TabIndex = 4;
            label2.Text = "Ten:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 187);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 5;
            label3.Text = "Diem";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(58, 157);
            label4.Name = "label4";
            label4.Size = new Size(37, 20);
            label4.TabIndex = 6;
            label4.Text = "Lop:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(41, 225);
            label5.Name = "label5";
            label5.Size = new Size(54, 20);
            label5.TabIndex = 7;
            label5.Text = "Diachi:";
            // 
            // txt_Ten
            // 
            txt_Ten.Location = new Point(99, 123);
            txt_Ten.Name = "txt_Ten";
            txt_Ten.Size = new Size(185, 27);
            txt_Ten.TabIndex = 8;
            // 
            // txt_lop
            // 
            txt_lop.Location = new Point(99, 155);
            txt_lop.Name = "txt_lop";
            txt_lop.Size = new Size(185, 27);
            txt_lop.TabIndex = 9;
            // 
            // txt_diem
            // 
            txt_diem.Location = new Point(99, 188);
            txt_diem.Name = "txt_diem";
            txt_diem.Size = new Size(185, 27);
            txt_diem.TabIndex = 10;
            // 
            // txt_DiaChi
            // 
            txt_DiaChi.Location = new Point(99, 221);
            txt_DiaChi.Name = "txt_DiaChi";
            txt_DiaChi.Size = new Size(185, 27);
            txt_DiaChi.TabIndex = 11;
            // 
            // button2
            // 
            button2.Location = new Point(635, 168);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 12;
            button2.Text = "Add";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btn_Edit
            // 
            btn_Edit.Location = new Point(636, 123);
            btn_Edit.Name = "btn_Edit";
            btn_Edit.Size = new Size(94, 29);
            btn_Edit.TabIndex = 13;
            btn_Edit.Text = "Edit";
            btn_Edit.UseVisualStyleBackColor = true;
            btn_Edit.Click += btn_Edit_Click;
            // 
            // button4
            // 
            button4.Location = new Point(635, 216);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 14;
            button4.Text = "Delete";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Stencil", 18F, FontStyle.Italic, GraphicsUnit.Point);
            label6.Location = new Point(333, 28);
            label6.Name = "label6";
            label6.Size = new Size(162, 35);
            label6.TabIndex = 15;
            label6.Text = "StudentS";
            // 
            // txt_Id
            // 
            txt_Id.Location = new Point(99, 56);
            txt_Id.Name = "txt_Id";
            txt_Id.Size = new Size(185, 27);
            txt_Id.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(69, 59);
            label7.Name = "label7";
            label7.Size = new Size(27, 20);
            label7.TabIndex = 16;
            label7.Text = "ID:";
            // 
            // btn_Exit
            // 
            btn_Exit.Location = new Point(636, 35);
            btn_Exit.Name = "btn_Exit";
            btn_Exit.Size = new Size(94, 29);
            btn_Exit.TabIndex = 18;
            btn_Exit.Text = "Exit";
            btn_Exit.UseVisualStyleBackColor = true;
            btn_Exit.Click += btn_Exit_Click;
            // 
            // txt_Tim_kiem
            // 
            txt_Tim_kiem.Location = new Point(333, 216);
            txt_Tim_kiem.Multiline = true;
            txt_Tim_kiem.Name = "txt_Tim_kiem";
            txt_Tim_kiem.Size = new Size(235, 28);
            txt_Tim_kiem.TabIndex = 19;
            txt_Tim_kiem.TextChanged += txt_Tim_kiem_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(333, 188);
            label8.Name = "label8";
            label8.Size = new Size(122, 20);
            label8.TabIndex = 20;
            label8.Text = "Tim Kiem by Ten:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            ClientSize = new Size(754, 451);
            Controls.Add(label8);
            Controls.Add(txt_Tim_kiem);
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
        private TextBox txt_Tim_kiem;
        private Label label8;
    }
}