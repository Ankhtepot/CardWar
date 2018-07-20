namespace CardWar
{
    partial class frMain
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
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ilMain = new System.Windows.Forms.ImageList(this.components);
            this.tiMain = new System.Windows.Forms.Timer(this.components);
            this.tbRecord = new System.Windows.Forms.TextBox();
            this.tbP1Total = new System.Windows.Forms.TextBox();
            this.tbP2Total = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRound = new System.Windows.Forms.TextBox();
            this.buStartGame = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbWOAnimation = new System.Windows.Forms.RadioButton();
            this.rbWAnimation = new System.Windows.Forms.RadioButton();
            this.buExit = new System.Windows.Forms.PictureBox();
            this.tbP1Name = new System.Windows.Forms.TextBox();
            this.tbP2Name = new System.Windows.Forms.TextBox();
            this.lbP1Name = new System.Windows.Forms.Label();
            this.lbP2Name = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TT = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.buStartGame)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BackgroundImage")));
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statusStrip1.BackgroundImage")));
            this.statusStrip1.Location = new System.Drawing.Point(0, 459);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(734, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ilMain
            // 
            this.ilMain.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilMain.ImageSize = new System.Drawing.Size(16, 16);
            this.ilMain.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tiMain
            // 
            this.tiMain.Enabled = true;
            this.tiMain.Interval = 5;
            this.tiMain.Tick += new System.EventHandler(this.tiMain_Tick);
            // 
            // tbRecord
            // 
            this.tbRecord.AcceptsReturn = true;
            this.tbRecord.AcceptsTab = true;
            this.tbRecord.Location = new System.Drawing.Point(537, 146);
            this.tbRecord.Multiline = true;
            this.tbRecord.Name = "tbRecord";
            this.tbRecord.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbRecord.Size = new System.Drawing.Size(185, 310);
            this.tbRecord.TabIndex = 24;
            // 
            // tbP1Total
            // 
            this.tbP1Total.Location = new System.Drawing.Point(26, 412);
            this.tbP1Total.Name = "tbP1Total";
            this.tbP1Total.Size = new System.Drawing.Size(32, 20);
            this.tbP1Total.TabIndex = 29;
            // 
            // tbP2Total
            // 
            this.tbP2Total.Location = new System.Drawing.Point(458, 412);
            this.tbP2Total.Name = "tbP2Total";
            this.tbP2Total.Size = new System.Drawing.Size(32, 20);
            this.tbP2Total.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(181, 415);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Round:";
            // 
            // tbRound
            // 
            this.tbRound.Location = new System.Drawing.Point(254, 415);
            this.tbRound.Name = "tbRound";
            this.tbRound.Size = new System.Drawing.Size(39, 20);
            this.tbRound.TabIndex = 32;
            // 
            // buStartGame
            // 
            this.buStartGame.BackColor = System.Drawing.Color.Transparent;
            this.buStartGame.Image = global::CardWar.Properties.Resources.startGameSmall;
            this.buStartGame.Location = new System.Drawing.Point(144, 107);
            this.buStartGame.Name = "buStartGame";
            this.buStartGame.Size = new System.Drawing.Size(250, 114);
            this.buStartGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buStartGame.TabIndex = 33;
            this.buStartGame.TabStop = false;
            this.buStartGame.Click += new System.EventHandler(this.buStartGame_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rbWOAnimation);
            this.groupBox1.Controls.Add(this.rbWAnimation);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(537, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 90);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cards move :";
            // 
            // rbWOAnimation
            // 
            this.rbWOAnimation.AutoSize = true;
            this.rbWOAnimation.Location = new System.Drawing.Point(22, 55);
            this.rbWOAnimation.Name = "rbWOAnimation";
            this.rbWOAnimation.Size = new System.Drawing.Size(144, 24);
            this.rbWOAnimation.TabIndex = 1;
            this.rbWOAnimation.TabStop = true;
            this.rbWOAnimation.Text = "W/O animation";
            this.rbWOAnimation.UseVisualStyleBackColor = true;
            this.rbWOAnimation.Click += new System.EventHandler(this.rbWOAnimation_Click);
            // 
            // rbWAnimation
            // 
            this.rbWAnimation.AutoSize = true;
            this.rbWAnimation.Location = new System.Drawing.Point(22, 25);
            this.rbWAnimation.Name = "rbWAnimation";
            this.rbWAnimation.Size = new System.Drawing.Size(142, 24);
            this.rbWAnimation.TabIndex = 0;
            this.rbWAnimation.TabStop = true;
            this.rbWAnimation.Text = "with animation";
            this.rbWAnimation.UseVisualStyleBackColor = true;
            this.rbWAnimation.Click += new System.EventHandler(this.rbWAnimation_Click);
            // 
            // buExit
            // 
            this.buExit.BackColor = System.Drawing.Color.Transparent;
            this.buExit.Image = global::CardWar.Properties.Resources.exitTest3;
            this.buExit.Location = new System.Drawing.Point(12, 38);
            this.buExit.Name = "buExit";
            this.buExit.Size = new System.Drawing.Size(86, 45);
            this.buExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buExit.TabIndex = 35;
            this.buExit.TabStop = false;
            this.TT.SetToolTip(this.buExit, "Exit");
            this.buExit.Click += new System.EventHandler(this.buExit_Click);
            // 
            // tbP1Name
            // 
            this.tbP1Name.Location = new System.Drawing.Point(26, 240);
            this.tbP1Name.Name = "tbP1Name";
            this.tbP1Name.Size = new System.Drawing.Size(100, 20);
            this.tbP1Name.TabIndex = 37;
            this.tbP1Name.Text = "Player 1";
            this.tbP1Name.TextChanged += new System.EventHandler(this.tbP1Name_TextChanged);
            // 
            // tbP2Name
            // 
            this.tbP2Name.Location = new System.Drawing.Point(414, 240);
            this.tbP2Name.Name = "tbP2Name";
            this.tbP2Name.Size = new System.Drawing.Size(100, 20);
            this.tbP2Name.TabIndex = 38;
            this.tbP2Name.Text = "Player 2";
            this.tbP2Name.TextChanged += new System.EventHandler(this.tbP2Name_TextChanged);
            // 
            // lbP1Name
            // 
            this.lbP1Name.AutoSize = true;
            this.lbP1Name.BackColor = System.Drawing.Color.Transparent;
            this.lbP1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbP1Name.ForeColor = System.Drawing.Color.White;
            this.lbP1Name.Location = new System.Drawing.Point(8, 217);
            this.lbP1Name.Name = "lbP1Name";
            this.lbP1Name.Size = new System.Drawing.Size(127, 16);
            this.lbP1Name.TabIndex = 39;
            this.lbP1Name.Text = "Name of Player 1";
            // 
            // lbP2Name
            // 
            this.lbP2Name.AutoSize = true;
            this.lbP2Name.BackColor = System.Drawing.Color.Transparent;
            this.lbP2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbP2Name.ForeColor = System.Drawing.Color.White;
            this.lbP2Name.Location = new System.Drawing.Point(400, 217);
            this.lbP2Name.Name = "lbP2Name";
            this.lbP2Name.Size = new System.Drawing.Size(127, 16);
            this.lbP2Name.TabIndex = 40;
            this.lbP2Name.Text = "Name of Player 2";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CardWar.Properties.Resources.optionsTest2;
            this.pictureBox1.Location = new System.Drawing.Point(104, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 45);
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            this.TT.SetToolTip(this.pictureBox1, "Options");
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::CardWar.Properties.Resources.background2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(734, 481);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbP2Name);
            this.Controls.Add(this.lbP1Name);
            this.Controls.Add(this.tbP2Name);
            this.Controls.Add(this.tbP1Name);
            this.Controls.Add(this.buExit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buStartGame);
            this.Controls.Add(this.tbRound);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbP2Total);
            this.Controls.Add(this.tbP1Total);
            this.Controls.Add(this.tbRecord);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(750, 520);
            this.MinimumSize = new System.Drawing.Size(750, 520);
            this.Name = "frMain";
            this.Text = "Card War";
            this.Load += new System.EventHandler(this.frMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.buStartGame)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ImageList ilMain;
        private System.Windows.Forms.Timer tiMain;
        private System.Windows.Forms.TextBox tbRecord;
        private System.Windows.Forms.TextBox tbP1Total;
        private System.Windows.Forms.TextBox tbP2Total;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRound;
        private System.Windows.Forms.PictureBox buStartGame;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbWOAnimation;
        private System.Windows.Forms.RadioButton rbWAnimation;
        private System.Windows.Forms.PictureBox buExit;
        private System.Windows.Forms.TextBox tbP1Name;
        private System.Windows.Forms.TextBox tbP2Name;
        private System.Windows.Forms.Label lbP1Name;
        private System.Windows.Forms.Label lbP2Name;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip TT;
    }
}