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
            visitedNodeList = new ListBox();
            nodePictureBox = new PictureBox();
            processLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)nodePictureBox).BeginInit();
            SuspendLayout();
            // 
            // BFSBTN
            // 
            BFSBTN.Location = new Point(729, 104);
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
            // visitedNodeList
            // 
            visitedNodeList.FormattingEnabled = true;
            visitedNodeList.ItemHeight = 15;
            visitedNodeList.Location = new Point(729, 311);
            visitedNodeList.Name = "visitedNodeList";
            visitedNodeList.Size = new Size(137, 199);
            visitedNodeList.TabIndex = 4;
            // 
            // nodePictureBox
            // 
            nodePictureBox.Location = new Point(46, 34);
            nodePictureBox.Name = "nodePictureBox";
            nodePictureBox.Size = new Size(650, 560);
            nodePictureBox.TabIndex = 5;
            nodePictureBox.TabStop = false;
            nodePictureBox.Paint += nodePictureBox_Paint;
            // 
            // processLabel
            // 
            processLabel.AutoSize = true;
            processLabel.Location = new Point(729, 34);
            processLabel.Name = "processLabel";
            processLabel.Size = new Size(75, 15);
            processLabel.TabIndex = 6;
            processLabel.Text = "processLabel";
            processLabel.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 630);
            Controls.Add(processLabel);
            Controls.Add(nodePictureBox);
            Controls.Add(visitedNodeList);
            Controls.Add(DosyaYukleButton);
            Controls.Add(DFSBTN);
            Controls.Add(BFSBTN);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)nodePictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button BFSBTN;
        private Button DFSBTN;
        private Button DosyaYukleButton;
        private ListBox visitedNodeList;
        private PictureBox nodePictureBox;
        private Label processLabel;
    }
}