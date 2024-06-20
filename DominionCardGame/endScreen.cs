using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DominionCardGame
{
    public partial class endScreen : UserControl
    {
        Rectangle playerResults = new Rectangle(400, 100, 300, 150);
        Rectangle cpuResults = new Rectangle(400, 300, 300, 150);

        public endScreen()
        {
            InitializeComponent();
        }

        private void endScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Moccasin, playerResults);
            e.Graphics.FillRectangle(Brushes.Moccasin, cpuResults);
            using (Font font1 = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point))
            {
                e.Graphics.DrawString($"Player Results", font1, Brushes.Black, playerResults);
                e.Graphics.DrawString($"\nTotal Victory Points: {Form1.player.TotalVictory}", font1, Brushes.Black, playerResults);
                e.Graphics.DrawString($"\n\nTotal Cards Played: {Form1.playerCardsPlayed}", font1, Brushes.Black, playerResults);

                e.Graphics.DrawString($"CPU Results", font1, Brushes.Black, cpuResults);
                e.Graphics.DrawString($"\nTotal Victory Points: {Form1.CPU.TotalVictory}", font1, Brushes.Black, cpuResults);
                e.Graphics.DrawString($"\n\nTotal Cards Played: {Form1.cpuCardsPlayed}", font1, Brushes.Black, cpuResults);
            }


        }

        private void playButton2_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new mneuScreen());
        }

        private void exitButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
