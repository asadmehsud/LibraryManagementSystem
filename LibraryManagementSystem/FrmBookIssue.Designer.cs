namespace LibraryManagementSystem
{
    partial class FrmBookIssue
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
            this.btnCross = new System.Windows.Forms.Button();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.lblBook = new System.Windows.Forms.Label();
            this.lblStudent = new System.Windows.Forms.Label();
            this.lblLibrarian = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblList = new System.Windows.Forms.LinkLabel();
            this.dtIssueDate = new System.Windows.Forms.DateTimePicker();
            this.ddlStudent = new System.Windows.Forms.ComboBox();
            this.ddlBook = new System.Windows.Forms.ComboBox();
            this.ddlLibrarian = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCross
            // 
            this.btnCross.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(145)))), ((int)(((byte)(235)))));
            this.btnCross.FlatAppearance.BorderSize = 0;
            this.btnCross.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCross.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCross.ForeColor = System.Drawing.Color.White;
            this.btnCross.Location = new System.Drawing.Point(547, 5);
            this.btnCross.Margin = new System.Windows.Forms.Padding(2);
            this.btnCross.Name = "btnCross";
            this.btnCross.Size = new System.Drawing.Size(35, 30);
            this.btnCross.TabIndex = 36;
            this.btnCross.Text = "X";
            this.btnCross.UseVisualStyleBackColor = false;
            this.btnCross.Click += new System.EventHandler(this.btnCross_Click);
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueDate.ForeColor = System.Drawing.Color.Red;
            this.lblIssueDate.Location = new System.Drawing.Point(212, 224);
            this.lblIssueDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(0, 13);
            this.lblIssueDate.TabIndex = 29;
            // 
            // lblBook
            // 
            this.lblBook.AutoSize = true;
            this.lblBook.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBook.ForeColor = System.Drawing.Color.Red;
            this.lblBook.Location = new System.Drawing.Point(212, 179);
            this.lblBook.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBook.Name = "lblBook";
            this.lblBook.Size = new System.Drawing.Size(0, 13);
            this.lblBook.TabIndex = 28;
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudent.ForeColor = System.Drawing.Color.Red;
            this.lblStudent.Location = new System.Drawing.Point(214, 133);
            this.lblStudent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(0, 13);
            this.lblStudent.TabIndex = 25;
            // 
            // lblLibrarian
            // 
            this.lblLibrarian.AutoSize = true;
            this.lblLibrarian.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLibrarian.ForeColor = System.Drawing.Color.Red;
            this.lblLibrarian.Location = new System.Drawing.Point(214, 89);
            this.lblLibrarian.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLibrarian.Name = "lblLibrarian";
            this.lblLibrarian.Size = new System.Drawing.Size(0, 13);
            this.lblLibrarian.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(117, 219);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "Issue Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(117, 175);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Book";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(117, 129);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Student";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(117, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Librarian";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(145)))), ((int)(((byte)(235)))));
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(117, 280);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(322, 29);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LibraryManagementSystem.Properties.Resources.icons8_book_50__1_;
            this.pictureBox1.Location = new System.Drawing.Point(8, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblList);
            this.panel1.Controls.Add(this.dtIssueDate);
            this.panel1.Controls.Add(this.ddlStudent);
            this.panel1.Controls.Add(this.ddlBook);
            this.panel1.Controls.Add(this.ddlLibrarian);
            this.panel1.Controls.Add(this.lblIssueDate);
            this.panel1.Controls.Add(this.lblBook);
            this.panel1.Controls.Add(this.lblStudent);
            this.panel1.Controls.Add(this.lblLibrarian);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Location = new System.Drawing.Point(8, 39);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 429);
            this.panel1.TabIndex = 34;
            // 
            // lblList
            // 
            this.lblList.AutoSize = true;
            this.lblList.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Italic);
            this.lblList.Location = new System.Drawing.Point(261, 335);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(59, 14);
            this.lblList.TabIndex = 37;
            this.lblList.TabStop = true;
            this.lblList.Text = "View List";
            this.lblList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblList_LinkClicked);
            // 
            // dtIssueDate
            // 
            this.dtIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtIssueDate.Location = new System.Drawing.Point(118, 240);
            this.dtIssueDate.Name = "dtIssueDate";
            this.dtIssueDate.Size = new System.Drawing.Size(323, 20);
            this.dtIssueDate.TabIndex = 4;
            // 
            // ddlStudent
            // 
            this.ddlStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlStudent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlStudent.FormattingEnabled = true;
            this.ddlStudent.Location = new System.Drawing.Point(117, 151);
            this.ddlStudent.Margin = new System.Windows.Forms.Padding(2);
            this.ddlStudent.Name = "ddlStudent";
            this.ddlStudent.Size = new System.Drawing.Size(323, 23);
            this.ddlStudent.TabIndex = 2;
            this.ddlStudent.SelectedIndexChanged += new System.EventHandler(this.ddlStudent_SelectedIndexChanged);
            // 
            // ddlBook
            // 
            this.ddlBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBook.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlBook.FormattingEnabled = true;
            this.ddlBook.Location = new System.Drawing.Point(116, 195);
            this.ddlBook.Margin = new System.Windows.Forms.Padding(2);
            this.ddlBook.Name = "ddlBook";
            this.ddlBook.Size = new System.Drawing.Size(323, 23);
            this.ddlBook.TabIndex = 3;
            this.ddlBook.SelectedIndexChanged += new System.EventHandler(this.ddlBook_SelectedIndexChanged);
            // 
            // ddlLibrarian
            // 
            this.ddlLibrarian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlLibrarian.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlLibrarian.FormattingEnabled = true;
            this.ddlLibrarian.Location = new System.Drawing.Point(117, 105);
            this.ddlLibrarian.Margin = new System.Windows.Forms.Padding(2);
            this.ddlLibrarian.Name = "ddlLibrarian";
            this.ddlLibrarian.Size = new System.Drawing.Size(323, 23);
            this.ddlLibrarian.TabIndex = 1;
            this.ddlLibrarian.SelectedIndexChanged += new System.EventHandler(this.ddlLibrarian_SelectedIndexChanged);
            // 
            // FrmBookIssue
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(145)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(590, 473);
            this.Controls.Add(this.btnCross);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmBookIssue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBookIssue";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCross;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.Label lblBook;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.Label lblLibrarian;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox ddlStudent;
        private System.Windows.Forms.ComboBox ddlBook;
        private System.Windows.Forms.ComboBox ddlLibrarian;
        private System.Windows.Forms.DateTimePicker dtIssueDate;
        private System.Windows.Forms.LinkLabel lblList;
    }
}