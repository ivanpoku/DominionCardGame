namespace DominionCardGame
{
    partial class playerHandScreen
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
            this.shopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // shopButton
            // 
            this.shopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopButton.Location = new System.Drawing.Point(264, 41);
            this.shopButton.Name = "shopButton";
            this.shopButton.Size = new System.Drawing.Size(210, 91);
            this.shopButton.TabIndex = 0;
            this.shopButton.Text = "proceed?";
            this.shopButton.UseVisualStyleBackColor = true;
            this.shopButton.Click += new System.EventHandler(this.shopButton_Click);
            // 
            // playerHandScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.shopButton);
            this.DoubleBuffered = true;
            this.Name = "playerHandScreen";
            this.Size = new System.Drawing.Size(800, 518);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.playerHandScreen_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.playerHandScreen_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button shopButton;
    }
}
