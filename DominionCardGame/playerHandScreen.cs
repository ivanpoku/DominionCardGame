using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace DominionCardGame
{
    public partial class playerHandScreen : UserControl
    {
        public static Image cardImage = Properties.Resources._374px_Militia;    

        public static int cpuDecision;

        public static bool playerCanPlay = false;
        public static bool CpuCanPlay = false;

        public static Rectangle playerHandCard1 = new Rectangle(30, 370, 100, 150);
        public static Rectangle playerHandCard2 = new Rectangle(145, 370, 100, 150);
        public static Rectangle playerHandCard3 = new Rectangle(260, 370, 100, 150);
        public static Rectangle playerHandCard4 = new Rectangle(375, 370, 100, 150);
        public static Rectangle playerHandCard5 = new Rectangle(490, 370, 100, 150);

        public playerHandScreen()
        {
            InitializeComponent();

        }

        private void handButton_Click(object sender, EventArgs e)
        {
            if (Form1.player.roundActions == 0 && Form1.player.roundCards == 0)
            {
                Form form = this.FindForm();
                GameScreen gs = new GameScreen();
                form.Controls.Add(gs);
                form.Controls.Remove(this);
                gs.Focus();
                gs.Location = new Point((form.Width - gs.Width) / 2, (form.Height - gs.Height) / 2);
                GameScreen.playerBuyTurn();
            }
            for (int j = 0; j < 5; j++)
            {
                Form1.playerHand.Remove(Form1.playerHand[j]);
                Form1.playerHand.Add(Form1.playerHand[j]);
            }
        }

        #region actionTurn
        public static void playerActionTurn()
        {
            playerHandScreen ps = new playerHandScreen();
            GameScreen gs = new GameScreen();

            playerCanPlay = true;
            for (int i = 0; i < 5; i++)
            {          
                if (Form1.playerHand[i].type == "Treasure")
                {
                    playerCanPlay = false;
                    Console.WriteLine("No cards avalible to play");
                    Form1.player.roundCoins += Form1.playerHand[i].coins;
                    Form1.player.roundActions = 0;
                }    
            }
        }
        public static void CPUActionTurn()
        {
            CpuCanPlay = true;
            for (int i = 0; i < 5; i++)
            {
                if (Form1.computerhand[i].type == "Treasure")
                {
                    Form1.CPU.roundCoins += Form1.computerhand[i].coins;

                }
                if (Form1.computerhand[i].type != "Action" || Form1.computerhand[i].type != "Attack" || Form1.computerhand[i].type != "Reaction")
                {
                    playerCanPlay = false;
                    Console.WriteLine("No cards avalible to play for CPU");
                }
                else
                {
                    cpuDecision = new Random().Next(0, i);
                    Console.WriteLine($"{cpuDecision}");
                }
            }
        }

        private void playerHandScreen_MouseClick(object sender, MouseEventArgs e)
        {
            Rectangle mouseRec = new Rectangle(e.X, e.Y, 1, 1);
            if (mouseRec.IntersectsWith(playerHandCard1) && Form1.player.roundActions >= 1 && playerCanPlay == true && Form1.playerHand[0].type != "Treasure")
            {
                Form1.player.roundCards += Form1.playerHand[0].cards;
                Form1.player.roundBuys += Form1.playerHand[0].buys;
                Form1.player.roundCoins += Form1.playerHand[0].coins;
                Form1.player.roundActions += Form1.playerHand[0].actions;
            }
        }
        #endregion

        private void playerHandScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Black, playerHandCard1);
            e.Graphics.FillRectangle(Brushes.Black, playerHandCard2);
            e.Graphics.FillRectangle(Brushes.Black, playerHandCard3);
            e.Graphics.FillRectangle(Brushes.Black, playerHandCard4);
            e.Graphics.FillRectangle(Brushes.Black, playerHandCard5);


            //Draws player's current hand
            foreach (Card card in Form1.roundCards) 
            {
                e.Graphics.DrawImage(cardImage, playerHandCard1.X, playerHandCard1.Y, playerHandCard1.Width, playerHandCard1.Height);
            }

            for (int i = 0; i < Form1.playerHand.Count; i++)
            {
                using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
                {
                    e.Graphics.DrawString($"{Form1.playerHand[0].name}", font1, Brushes.White, playerHandCard1);
                    e.Graphics.DrawString($"{Form1.playerHand[1].name}", font1, Brushes.White, playerHandCard2);
                    e.Graphics.DrawString($"{Form1.playerHand[2].name}", font1, Brushes.White, playerHandCard3);
                    e.Graphics.DrawString($"{Form1.playerHand[3].name}", font1, Brushes.White, playerHandCard4);
                    e.Graphics.DrawString($"{Form1.playerHand[4].name}", font1, Brushes.White, playerHandCard5);
                }
                using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
                {
                    e.Graphics.DrawString($"", font1, Brushes.White, playerHandCard1);
                    e.Graphics.DrawString($"", font1, Brushes.White, playerHandCard2);
                    e.Graphics.DrawString($"", font1, Brushes.White, playerHandCard3);
                    e.Graphics.DrawString($"", font1, Brushes.White, playerHandCard4);
                    e.Graphics.DrawString($"", font1, Brushes.White, playerHandCard5);
                }

            }

            //Draws player stats for current round
            Rectangle statsDispaly = new Rectangle(650, 300, 150, 218);
            e.Graphics.FillRectangle(Brushes.Black, statsDispaly);
            for (int i = 0; i < Form1.playerHand.Count; i++)
            {
                using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
                {
                    e.Graphics.DrawString("Player Stats", font1, Brushes.White, statsDispaly);
                    e.Graphics.DrawString($"\nCoins: {Form1.player.roundCoins}", font1, Brushes.White, statsDispaly);
                    e.Graphics.DrawString($"\n\nActions: {Form1.player.roundActions}", font1, Brushes.White, statsDispaly);
                    e.Graphics.DrawString($"\n\n\nBuys: {Form1.player.roundBuys}", font1, Brushes.White, statsDispaly);
                    e.Graphics.DrawString($"\n\n\n\nCards Playable: {Form1.player.roundCards}", font1, Brushes.White, statsDispaly);
                }
            }
            Refresh();
        }

    }
}
