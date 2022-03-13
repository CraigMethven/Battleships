namespace BattleshipsGame
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.BtnStartGame = new System.Windows.Forms.Button();
            this.BtnOptions = new System.Windows.Forms.Button();
            this.BtnRules = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.HighscoresBtn = new System.Windows.Forms.Button();
            this.logoPnl = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnStartGame
            // 
            this.BtnStartGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnStartGame.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStartGame.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.BtnStartGame.Location = new System.Drawing.Point(60, 123);
            this.BtnStartGame.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnStartGame.Name = "BtnStartGame";
            this.BtnStartGame.Size = new System.Drawing.Size(255, 94);
            this.BtnStartGame.TabIndex = 0;
            this.BtnStartGame.Text = "Start Game";
            this.BtnStartGame.UseVisualStyleBackColor = false;
            this.BtnStartGame.Click += new System.EventHandler(this.BtnStartGame_Click);
            // 
            // BtnOptions
            // 
            this.BtnOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnOptions.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOptions.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.BtnOptions.Location = new System.Drawing.Point(60, 247);
            this.BtnOptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnOptions.Name = "BtnOptions";
            this.BtnOptions.Size = new System.Drawing.Size(255, 94);
            this.BtnOptions.TabIndex = 1;
            this.BtnOptions.Text = "Game Options";
            this.BtnOptions.UseVisualStyleBackColor = false;
            this.BtnOptions.Click += new System.EventHandler(this.BtnOptions_Click);
            // 
            // BtnRules
            // 
            this.BtnRules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnRules.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRules.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.BtnRules.Location = new System.Drawing.Point(63, 378);
            this.BtnRules.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnRules.Name = "BtnRules";
            this.BtnRules.Size = new System.Drawing.Size(252, 92);
            this.BtnRules.TabIndex = 2;
            this.BtnRules.Text = "Rules";
            this.BtnRules.UseVisualStyleBackColor = false;
            this.BtnRules.Click += new System.EventHandler(this.BtnRules_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1228, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(92, 29);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(164, 34);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.ExitToolStripMenuItem1_Click);
            // 
            // HighscoresBtn
            // 
            this.HighscoresBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HighscoresBtn.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HighscoresBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.HighscoresBtn.Location = new System.Drawing.Point(63, 506);
            this.HighscoresBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HighscoresBtn.Name = "HighscoresBtn";
            this.HighscoresBtn.Size = new System.Drawing.Size(252, 92);
            this.HighscoresBtn.TabIndex = 5;
            this.HighscoresBtn.Text = "Highscores";
            this.HighscoresBtn.UseVisualStyleBackColor = false;
            this.HighscoresBtn.Click += new System.EventHandler(this.HighscoresBtn_Click);
            // 
            // logoPnl
            // 
            this.logoPnl.BackColor = System.Drawing.Color.Transparent;
            this.logoPnl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logoPnl.BackgroundImage")));
            this.logoPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoPnl.Location = new System.Drawing.Point(708, 48);
            this.logoPnl.Name = "logoPnl";
            this.logoPnl.Size = new System.Drawing.Size(429, 235);
            this.logoPnl.TabIndex = 6;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1228, 794);
            this.Controls.Add(this.logoPnl);
            this.Controls.Add(this.HighscoresBtn);
            this.Controls.Add(this.BtnRules);
            this.Controls.Add(this.BtnOptions);
            this.Controls.Add(this.BtnStartGame);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(1250, 850);
            this.MinimumSize = new System.Drawing.Size(1250, 850);
            this.Name = "MenuForm";
            this.Text = "Battleships Menu";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStartGame;
        private System.Windows.Forms.Button BtnOptions;
        private System.Windows.Forms.Button BtnRules;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.Button HighscoresBtn;
        private System.Windows.Forms.Panel logoPnl;
    }
}

