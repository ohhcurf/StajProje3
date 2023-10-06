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
            treeView = new TreeView();
            BFSBTN = new Button();
            DFSBTN = new Button();
            DosyaYukleButton = new Button();
            listBox = new ListBox();
            SuspendLayout();
            // 
            // treeView
            // 
            treeView.Location = new Point(12, 12);
            treeView.Name = "treeView";
            treeView.Size = new Size(554, 417);
            treeView.TabIndex = 0;
            // 
            // BFSBTN
            // 
            BFSBTN.Location = new Point(614, 27);
            BFSBTN.Name = "BFSBTN";
            BFSBTN.Size = new Size(137, 47);
            BFSBTN.TabIndex = 1;
            BFSBTN.Text = "BFS";
            BFSBTN.UseVisualStyleBackColor = true;
            BFSBTN.Click += BFSBTN_Click;
            // 
            // DFSBTN
            // 
            DFSBTN.Location = new Point(614, 96);
            DFSBTN.Name = "DFSBTN";
            DFSBTN.Size = new Size(137, 44);
            DFSBTN.TabIndex = 2;
            DFSBTN.Text = "DFS";
            DFSBTN.UseVisualStyleBackColor = true;
            DFSBTN.Click += DFSBTN_Click;
            // 
            // DosyaYukleButton
            // 
            DosyaYukleButton.Location = new Point(614, 380);
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
            listBox.Location = new Point(614, 160);
            listBox.Name = "listBox";
            listBox.Size = new Size(137, 199);
            listBox.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBox);
            Controls.Add(DosyaYukleButton);
            Controls.Add(DFSBTN);
            Controls.Add(BFSBTN);
            Controls.Add(treeView);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeView;
        private Button BFSBTN;
        private Button DFSBTN;
        private Button DosyaYukleButton;
        private ListBox listBox;
    }
}