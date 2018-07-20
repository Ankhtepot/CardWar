namespace CardWar {
    partial class Pause {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.buResume = new System.Windows.Forms.PictureBox();
            this.buExit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.buResume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buExit)).BeginInit();
            this.SuspendLayout();
            // 
            // buResume
            // 
            this.buResume.BackColor = System.Drawing.Color.Transparent;
            this.buResume.Image = global::CardWar.Properties.Resources.resume_icon;
            this.buResume.Location = new System.Drawing.Point(59, 38);
            this.buResume.Name = "buResume";
            this.buResume.Size = new System.Drawing.Size(180, 85);
            this.buResume.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buResume.TabIndex = 0;
            this.buResume.TabStop = false;
            this.buResume.Click += new System.EventHandler(this.buResume_Click);
            // 
            // buExit
            // 
            this.buExit.BackColor = System.Drawing.Color.Transparent;
            this.buExit.Image = global::CardWar.Properties.Resources.exit_icon2;
            this.buExit.Location = new System.Drawing.Point(59, 129);
            this.buExit.Name = "buExit";
            this.buExit.Size = new System.Drawing.Size(180, 85);
            this.buExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buExit.TabIndex = 1;
            this.buExit.TabStop = false;
            this.buExit.Click += new System.EventHandler(this.buExit_Click);
            // 
            // Pause
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CardWar.Properties.Resources.background2;
            this.ClientSize = new System.Drawing.Size(305, 255);
            this.Controls.Add(this.buExit);
            this.Controls.Add(this.buResume);
            this.Name = "Pause";
            this.Text = "Pause";
            this.Load += new System.EventHandler(this.Pause_Load);
            ((System.ComponentModel.ISupportInitialize)(this.buResume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox buResume;
        private System.Windows.Forms.PictureBox buExit;
    }
}