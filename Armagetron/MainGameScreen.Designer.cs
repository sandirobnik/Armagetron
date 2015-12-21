namespace KpoVaja01
{
    partial class MainGameScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGameScreen));
            this.GreenPlayer = new System.Windows.Forms.Label();
            this.BluePlayer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GreenPlayer
            // 
            this.GreenPlayer.AutoSize = true;
            this.GreenPlayer.Dock = System.Windows.Forms.DockStyle.Left;
            this.GreenPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GreenPlayer.ForeColor = System.Drawing.SystemColors.Info;
            this.GreenPlayer.Location = new System.Drawing.Point(0, 0);
            this.GreenPlayer.Name = "GreenPlayer";
            this.GreenPlayer.Padding = new System.Windows.Forms.Padding(20, 20, 0, 0);
            this.GreenPlayer.Size = new System.Drawing.Size(129, 37);
            this.GreenPlayer.TabIndex = 0;
            this.GreenPlayer.Text = "Zeleni igralec: 0";
            // 
            // BluePlayer
            // 
            this.BluePlayer.AutoSize = true;
            this.BluePlayer.Dock = System.Windows.Forms.DockStyle.Right;
            this.BluePlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BluePlayer.ForeColor = System.Drawing.SystemColors.Info;
            this.BluePlayer.Location = new System.Drawing.Point(659, 0);
            this.BluePlayer.Name = "BluePlayer";
            this.BluePlayer.Padding = new System.Windows.Forms.Padding(0, 20, 20, 0);
            this.BluePlayer.Size = new System.Drawing.Size(125, 37);
            this.BluePlayer.TabIndex = 1;
            this.BluePlayer.Text = "Modri igralec: 0";
            // 
            // MainGameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.BluePlayer);
            this.Controls.Add(this.GreenPlayer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainGameScreen";
            this.Text = "Armagetron";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainGameScreen_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GreenPlayer;
        private System.Windows.Forms.Label BluePlayer;
    }
}

