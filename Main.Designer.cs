namespace sethc
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Main.cs Design

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.labelskcontent = new System.Windows.Forms.Label();
            this.labelturnsk = new System.Windows.Forms.Label();
            this.buttonYes = new System.Windows.Forms.Button();
            this.buttonNo = new System.Windows.Forms.Button();
            this.labeldeactivatedialog = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelskcontent
            // 
            this.labelskcontent.AutoEllipsis = true;
            this.labelskcontent.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.labelskcontent.Location = new System.Drawing.Point(40, 43);
            this.labelskcontent.Name = "labelskcontent";
            this.labelskcontent.Size = new System.Drawing.Size(445, 59);
            this.labelskcontent.TabIndex = 1;
            this.labelskcontent.Text = "Sticky Keys lets you use the SHIFT, CTRL, ALT, or Windows Logo keys by pressing o" +
    "ne key at a time. The keyboard shortcut to turn on Sticky Keys is to press the S" +
    "HIFT key 5 times.";
            // 
            // labelturnsk
            // 
            this.labelturnsk.AutoSize = true;
            this.labelturnsk.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.labelturnsk.Location = new System.Drawing.Point(15, 21);
            this.labelturnsk.Name = "labelturnsk";
            this.labelturnsk.Size = new System.Drawing.Size(196, 15);
            this.labelturnsk.TabIndex = 0;
            this.labelturnsk.Text = "Do you want to turn on Sticky Keys?";
            // 
            // buttonYes
            // 
            this.buttonYes.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.buttonYes.Location = new System.Drawing.Point(298, 142);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(76, 23);
            this.buttonYes.TabIndex = 2;
            this.buttonYes.Text = "&Yes";
            this.buttonYes.UseVisualStyleBackColor = true;
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // buttonNo
            // 
            this.buttonNo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.buttonNo.Location = new System.Drawing.Point(384, 142);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(76, 23);
            this.buttonNo.TabIndex = 3;
            this.buttonNo.Text = "&No";
            this.buttonNo.UseVisualStyleBackColor = true;
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // labeldeactivatedialog
            // 
            this.labeldeactivatedialog.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            this.labeldeactivatedialog.AutoEllipsis = true;
            this.labeldeactivatedialog.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.labeldeactivatedialog.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.labeldeactivatedialog.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            this.labeldeactivatedialog.Location = new System.Drawing.Point(38, 102);
            this.labeldeactivatedialog.Name = "labeldeactivatedialog";
            this.labeldeactivatedialog.Size = new System.Drawing.Size(450, 15);
            this.labeldeactivatedialog.TabIndex = 4;
            this.labeldeactivatedialog.TabStop = true;
            this.labeldeactivatedialog.Text = "Go to the Ease of Access Center to disable the keyboard shortcut";
            this.labeldeactivatedialog.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(255)))));
            this.labeldeactivatedialog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labeldeactivatedialog_LinkClicked);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(500, 181);
            this.Controls.Add(this.labeldeactivatedialog);
            this.Controls.Add(this.buttonNo);
            this.Controls.Add(this.buttonYes);
            this.Controls.Add(this.labelskcontent);
            this.Controls.Add(this.labelturnsk);
            this.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(105, 100);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Sticky Keys";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelskcontent;
        public System.Windows.Forms.Label labelturnsk;
        public System.Windows.Forms.Button buttonYes;
        public System.Windows.Forms.Button buttonNo;
        public System.Windows.Forms.LinkLabel labeldeactivatedialog;
    }
}

