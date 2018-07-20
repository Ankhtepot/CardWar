namespace CardWar {
    partial class Options {
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
            this.components = new System.ComponentModel.Container();
            this.trbSpeed = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trbWaiting = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.trbRounds = new System.Windows.Forms.TrackBar();
            this.lbRounds = new System.Windows.Forms.Label();
            this.lbWaiting = new System.Windows.Forms.Label();
            this.TT = new System.Windows.Forms.ToolTip(this.components);
            this.buOK = new System.Windows.Forms.PictureBox();
            this.buCancel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbWaiting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbRounds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // trbSpeed
            // 
            this.trbSpeed.Location = new System.Drawing.Point(175, 63);
            this.trbSpeed.Maximum = 6;
            this.trbSpeed.Minimum = 1;
            this.trbSpeed.Name = "trbSpeed";
            this.trbSpeed.Size = new System.Drawing.Size(439, 45);
            this.trbSpeed.TabIndex = 37;
            this.trbSpeed.Value = 6;
            this.trbSpeed.Scroll += new System.EventHandler(this.trbSpeed_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 38;
            this.label1.Text = "Movement speed:";
            // 
            // lbSpeed
            // 
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lbSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbSpeed.ForeColor = System.Drawing.Color.White;
            this.lbSpeed.Location = new System.Drawing.Point(620, 63);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(56, 37);
            this.lbSpeed.TabIndex = 39;
            this.lbSpeed.Text = ": 5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(56, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 40;
            this.label3.Text = "Waiting time:";
            // 
            // trbWaiting
            // 
            this.trbWaiting.Location = new System.Drawing.Point(175, 114);
            this.trbWaiting.Maximum = 12;
            this.trbWaiting.Name = "trbWaiting";
            this.trbWaiting.Size = new System.Drawing.Size(439, 45);
            this.trbWaiting.TabIndex = 41;
            this.trbWaiting.Value = 6;
            this.trbWaiting.Scroll += new System.EventHandler(this.trbWaiting_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 20);
            this.label4.TabIndex = 42;
            this.label4.Text = "Number of rounds:";
            // 
            // trbRounds
            // 
            this.trbRounds.Location = new System.Drawing.Point(175, 12);
            this.trbRounds.Maximum = 200;
            this.trbRounds.Minimum = 1;
            this.trbRounds.Name = "trbRounds";
            this.trbRounds.Size = new System.Drawing.Size(439, 45);
            this.trbRounds.TabIndex = 43;
            this.trbRounds.Value = 6;
            this.trbRounds.Scroll += new System.EventHandler(this.trbRounds_Scroll);
            // 
            // lbRounds
            // 
            this.lbRounds.AutoSize = true;
            this.lbRounds.BackColor = System.Drawing.Color.Transparent;
            this.lbRounds.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbRounds.ForeColor = System.Drawing.Color.White;
            this.lbRounds.Location = new System.Drawing.Point(620, 16);
            this.lbRounds.Name = "lbRounds";
            this.lbRounds.Size = new System.Drawing.Size(56, 37);
            this.lbRounds.TabIndex = 44;
            this.lbRounds.Text = ": 5";
            // 
            // lbWaiting
            // 
            this.lbWaiting.AutoSize = true;
            this.lbWaiting.BackColor = System.Drawing.Color.Transparent;
            this.lbWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbWaiting.ForeColor = System.Drawing.Color.White;
            this.lbWaiting.Location = new System.Drawing.Point(620, 114);
            this.lbWaiting.Name = "lbWaiting";
            this.lbWaiting.Size = new System.Drawing.Size(56, 37);
            this.lbWaiting.TabIndex = 45;
            this.lbWaiting.Text = ": 5";
            // 
            // buOK
            // 
            this.buOK.BackColor = System.Drawing.Color.Transparent;
            this.buOK.Image = global::CardWar.Properties.Resources.accept_icon2;
            this.buOK.Location = new System.Drawing.Point(684, 170);
            this.buOK.Name = "buOK";
            this.buOK.Size = new System.Drawing.Size(45, 45);
            this.buOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buOK.TabIndex = 47;
            this.buOK.TabStop = false;
            this.TT.SetToolTip(this.buOK, "Accept changes and return to game.");
            this.buOK.Click += new System.EventHandler(this.buOK_Click);
            // 
            // buCancel
            // 
            this.buCancel.BackColor = System.Drawing.Color.Transparent;
            this.buCancel.Image = global::CardWar.Properties.Resources.exit_icon21;
            this.buCancel.Location = new System.Drawing.Point(12, 170);
            this.buCancel.Name = "buCancel";
            this.buCancel.Size = new System.Drawing.Size(45, 45);
            this.buCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buCancel.TabIndex = 46;
            this.buCancel.TabStop = false;
            this.TT.SetToolTip(this.buCancel, "Cancel changes and return to game.");
            this.buCancel.Click += new System.EventHandler(this.buCancel_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CardWar.Properties.Resources.tyrkys_wood_canvas_resized;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(741, 227);
            this.Controls.Add(this.buOK);
            this.Controls.Add(this.buCancel);
            this.Controls.Add(this.lbWaiting);
            this.Controls.Add(this.lbRounds);
            this.Controls.Add(this.trbRounds);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trbWaiting);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbSpeed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trbSpeed);
            this.Name = "Options";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbWaiting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbRounds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buCancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trbSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trbWaiting;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trbRounds;
        private System.Windows.Forms.Label lbRounds;
        private System.Windows.Forms.Label lbWaiting;
        private System.Windows.Forms.PictureBox buCancel;
        private System.Windows.Forms.PictureBox buOK;
        private System.Windows.Forms.ToolTip TT;
    }
}