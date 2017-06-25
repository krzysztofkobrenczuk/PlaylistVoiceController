namespace VoiceControlDesktop
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.aPlaylistBox = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.OnBtn = new System.Windows.Forms.Button();
            this.MicroBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.prevBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Playlist ID:";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(12, 67);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(628, 378);
            this.webBrowser1.TabIndex = 3;
            // 
            // aPlaylistBox
            // 
            this.aPlaylistBox.Location = new System.Drawing.Point(74, 28);
            this.aPlaylistBox.Name = "aPlaylistBox";
            this.aPlaylistBox.Size = new System.Drawing.Size(566, 20);
            this.aPlaylistBox.TabIndex = 6;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(646, 67);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(132, 355);
            this.listBox1.TabIndex = 7;
            // 
            // OnBtn
            // 
            this.OnBtn.Location = new System.Drawing.Point(646, 28);
            this.OnBtn.Name = "OnBtn";
            this.OnBtn.Size = new System.Drawing.Size(66, 23);
            this.OnBtn.TabIndex = 9;
            this.OnBtn.Text = "Start";
            this.OnBtn.UseVisualStyleBackColor = true;
            this.OnBtn.Click += new System.EventHandler(this.OnBtn_Click);
            // 
            // MicroBtn
            // 
            this.MicroBtn.Location = new System.Drawing.Point(712, 28);
            this.MicroBtn.Name = "MicroBtn";
            this.MicroBtn.Size = new System.Drawing.Size(66, 23);
            this.MicroBtn.TabIndex = 10;
            this.MicroBtn.Text = "Micro Off";
            this.MicroBtn.UseVisualStyleBackColor = true;
            this.MicroBtn.Click += new System.EventHandler(this.OffBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "f.e PLsDtAfpBUwXSQZNyxZJVfmC7wYLv_JrTG";
            // 
            // prevBtn
            // 
            this.prevBtn.Location = new System.Drawing.Point(646, 428);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(66, 23);
            this.prevBtn.TabIndex = 12;
            this.prevBtn.Text = "Prev";
            this.prevBtn.UseVisualStyleBackColor = true;
            this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(718, 428);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(60, 23);
            this.nextBtn.TabIndex = 13;
            this.nextBtn.Text = "Next";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 457);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.prevBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MicroBtn);
            this.Controls.Add(this.OnBtn);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.aPlaylistBox);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox aPlaylistBox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button OnBtn;
        private System.Windows.Forms.Button MicroBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button prevBtn;
        private System.Windows.Forms.Button nextBtn;
    }
}

