namespace Practica_API
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
            button1 = new Button();
            txtStartDate = new TextBox();
            txtEndDate = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            txtFecha = new TextBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(139, 135);
            button1.Name = "button1";
            button1.Size = new Size(411, 53);
            button1.TabIndex = 0;
            button1.Text = "GET INFORMACION";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // txtStartDate
            // 
            txtStartDate.Location = new Point(139, 83);
            txtStartDate.Name = "txtStartDate";
            txtStartDate.PlaceholderText = "yyyy-mm-dd";
            txtStartDate.Size = new Size(177, 27);
            txtStartDate.TabIndex = 1;
            txtStartDate.TextAlign = HorizontalAlignment.Center;
            // 
            // txtEndDate
            // 
            txtEndDate.Location = new Point(373, 83);
            txtEndDate.Name = "txtEndDate";
            txtEndDate.PlaceholderText = "yyyy-mm-dd";
            txtEndDate.Size = new Size(177, 27);
            txtEndDate.TabIndex = 2;
            txtEndDate.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(169, 47);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 3;
            label1.Text = "FECHA INICIAL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(407, 47);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 4;
            label2.Text = "FECHA FINAL";
            // 
            // button2
            // 
            button2.Location = new Point(668, 135);
            button2.Name = "button2";
            button2.Size = new Size(411, 53);
            button2.TabIndex = 5;
            button2.Text = "GET IMAGENES";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(687, 236);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(363, 393);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // txtFecha
            // 
            txtFecha.Location = new Point(791, 83);
            txtFecha.Name = "txtFecha";
            txtFecha.PlaceholderText = "yyyy-mm-dd";
            txtFecha.Size = new Size(177, 27);
            txtFecha.TabIndex = 7;
            txtFecha.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(854, 47);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 8;
            label3.Text = "FECHA";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1205, 766);
            Controls.Add(label3);
            Controls.Add(txtFecha);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtEndDate);
            Controls.Add(txtStartDate);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox txtStartDate;
        private TextBox txtEndDate;
        private Label label1;
        private Label label2;
        private Button button2;
        private PictureBox pictureBox1;
        private TextBox txtFecha;
        private Label label3;
    }
}
