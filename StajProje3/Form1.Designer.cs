namespace StajProje3
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
            BFSBTN = new Button();
            DFSBTN = new Button();
            DosyaYukleButton = new Button();
            listBox = new ListBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // BFSBTN
            // 
            BFSBTN.Location = new Point(729, 106);
            BFSBTN.Name = "BFSBTN";
            BFSBTN.Size = new Size(137, 47);
            BFSBTN.TabIndex = 1;
            BFSBTN.Text = "BFS";
            BFSBTN.UseVisualStyleBackColor = true;
            BFSBTN.Click += BFSBTN_Click;
            // 
            // DFSBTN
            // 
            DFSBTN.Location = new Point(729, 199);
            DFSBTN.Name = "DFSBTN";
            DFSBTN.Size = new Size(137, 44);
            DFSBTN.TabIndex = 2;
            DFSBTN.Text = "DFS";
            DFSBTN.UseVisualStyleBackColor = true;
            DFSBTN.Click += DFSBTN_Click;
            // 
            // DosyaYukleButton
            // 
            DosyaYukleButton.Location = new Point(729, 545);
            DosyaYukleButton.Name = "DosyaYukleButton";
            DosyaYukleButton.Size = new Size(137, 49);
            DosyaYukleButton.TabIndex = 3;
            DosyaYukleButton.Text = "Dosya Yükle";
            DosyaYukleButton.UseVisualStyleBackColor = true;
            DosyaYukleButton.Click += FileUploadButton_Click;
            // 
            // listBox
            // 
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 15;
            listBox.Location = new Point(729, 311);
            listBox.Name = "listBox";
            listBox.Size = new Size(137, 199);
            listBox.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(46, 34);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(650, 560);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 630);
            Controls.Add(pictureBox1);
            Controls.Add(listBox);
            Controls.Add(DosyaYukleButton);
            Controls.Add(DFSBTN);
            Controls.Add(BFSBTN);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button BFSBTN;
        private Button DFSBTN;
        private Button DosyaYukleButton;
        private ListBox listBox;
        private PictureBox pictureBox1;
    }
}