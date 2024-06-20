namespace DominionCardGame
{
    partial class endScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(endScreen));
            this.exitButton2 = new System.Windows.Forms.Button();
            this.playButton2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exitButton2
            // 
            this.exitButton2.BackColor = System.Drawing.Color.Moccasin;
            this.exitButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.exitButton2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exitButton2.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton2.ForeColor = System.Drawing.Color.Black;
            this.exitButton2.Location = new System.Drawing.Point(3, 413);
            this.exitButton2.Name = "exitButton2";
            this.exitButton2.Size = new System.Drawing.Size(161, 57);
            this.exitButton2.TabIndex = 2;
            this.exitButton2.Text = "Exit";
            this.exitButton2.UseVisualStyleBackColor = false;
            this.exitButton2.Click += new System.EventHandler(this.exitButton2_Click);
            // 
            // playButton2
            // 
            this.playButton2.BackColor = System.Drawing.Color.Moccasin;
            this.playButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.playButton2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.playButton2.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton2.ForeColor = System.Drawing.Color.Black;
            this.playButton2.Location = new System.Drawing.Point(3, 350);
            this.playButton2.Name = "playButton2";
            this.playButton2.Size = new System.Drawing.Size(161, 57);
            this.playButton2.TabIndex = 3;
            this.playButton2.Text = "Play Again";
            this.playButton2.UseVisualStyleBackColor = false;
            this.playButton2.Click += new System.EventHandler(this.playButton2_Click);
            // 
            // endScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.playButton2);
            this.Controls.Add(this.exitButton2);
            this.DoubleBuffered = true;
            this.Name = "endScreen";
            this.Size = new System.Drawing.Size(800, 518);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.endScreen_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitButton2;
        private System.Windows.Forms.Button playButton2;
    }
}
