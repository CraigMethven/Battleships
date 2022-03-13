namespace BattleshipsGame
{
    partial class FrmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOptions));
            this.logoPnl = new System.Windows.Forms.Panel();
            this.LbLX = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnBack = new System.Windows.Forms.Button();
            this.btnX = new System.Windows.Forms.TextBox();
            this.btnY = new System.Windows.Forms.TextBox();
            this.btnLength = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CkBxDif = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // logoPnl
            // 
            this.logoPnl.BackColor = System.Drawing.Color.Transparent;
            this.logoPnl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logoPnl.BackgroundImage")));
            this.logoPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoPnl.Location = new System.Drawing.Point(776, -5);
            this.logoPnl.Name = "logoPnl";
            this.logoPnl.Size = new System.Drawing.Size(439, 196);
            this.logoPnl.TabIndex = 7;
            // 
            // LbLX
            // 
            this.LbLX.AutoSize = true;
            this.LbLX.BackColor = System.Drawing.Color.Transparent;
            this.LbLX.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold);
            this.LbLX.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LbLX.Location = new System.Drawing.Point(18, 183);
            this.LbLX.Name = "LbLX";
            this.LbLX.Size = new System.Drawing.Size(644, 29);
            this.LbLX.TabIndex = 8;
            this.LbLX.Text = "What length do you want the grid to be?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(18, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(639, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "What height do you want the grid to be?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(18, 375);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(471, 29);
            this.label2.TabIndex = 10;
            this.label2.Text = "How many ships do you want? ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(18, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(900, 29);
            this.label3.TabIndex = 11;
            this.label3.Text = "(The  number of ships is also the length of the longest ship)";
            // 
            // BtnBack
            // 
            this.BtnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnBack.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBack.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.BtnBack.Location = new System.Drawing.Point(923, 557);
            this.BtnBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(259, 94);
            this.BtnBack.TabIndex = 12;
            this.BtnBack.Text = "Menu";
            this.BtnBack.UseVisualStyleBackColor = false;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnX.Font = new System.Drawing.Font("Perpetua Titling MT", 24F, System.Drawing.FontStyle.Bold);
            this.btnX.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnX.Location = new System.Drawing.Point(963, 157);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(186, 65);
            this.btnX.TabIndex = 13;
            // 
            // btnY
            // 
            this.btnY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnY.Font = new System.Drawing.Font("Perpetua Titling MT", 24F, System.Drawing.FontStyle.Bold);
            this.btnY.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnY.Location = new System.Drawing.Point(963, 253);
            this.btnY.Name = "btnY";
            this.btnY.Size = new System.Drawing.Size(186, 65);
            this.btnY.TabIndex = 14;
            // 
            // btnLength
            // 
            this.btnLength.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLength.Font = new System.Drawing.Font("Perpetua Titling MT", 24F, System.Drawing.FontStyle.Bold);
            this.btnLength.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnLength.Location = new System.Drawing.Point(963, 349);
            this.btnLength.Name = "btnLength";
            this.btnLength.Size = new System.Drawing.Size(186, 65);
            this.btnLength.TabIndex = 15;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold);
            this.lblError.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblError.Location = new System.Drawing.Point(12, 590);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 29);
            this.lblError.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(18, 475);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(433, 29);
            this.label4.TabIndex = 17;
            this.label4.Text = "Do you want it to be easier?";
            // 
            // CkBxDif
            // 
            this.CkBxDif.AutoSize = true;
            this.CkBxDif.Location = new System.Drawing.Point(1040, 471);
            this.CkBxDif.Name = "CkBxDif";
            this.CkBxDif.Size = new System.Drawing.Size(22, 21);
            this.CkBxDif.TabIndex = 18;
            this.CkBxDif.UseVisualStyleBackColor = true;
            // 
            // FrmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1228, 694);
            this.Controls.Add(this.CkBxDif);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnLength);
            this.Controls.Add(this.btnY);
            this.Controls.Add(this.btnX);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LbLX);
            this.Controls.Add(this.logoPnl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1250, 750);
            this.MinimumSize = new System.Drawing.Size(1250, 750);
            this.Name = "FrmOptions";
            this.Text = "Battleships Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel logoPnl;
        private System.Windows.Forms.Label LbLX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.TextBox btnX;
        private System.Windows.Forms.TextBox btnY;
        private System.Windows.Forms.TextBox btnLength;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CkBxDif;
    }
}