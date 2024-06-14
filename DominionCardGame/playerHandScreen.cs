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
        public static int cpuDecision;
        public static Rectangle playerHandCard1 = new Rectangle(30, 370, 100, 150);
        public static Rectangle playerHandCard2 = new Rectangle(145, 370, 100, 150);
        public static Rectangle playerHandCard3 = new Rectangle(260, 370, 100, 150);
        public static Rectangle playerHandCard4 = new Rectangle(375, 370, 100, 150);
        public static Rectangle playerHandCard5 = new Rectangle(490, 370, 100, 150);

        public playerHandScreen()
        {
            InitializeComponent();
            if (Form1.playerTurn == "Player")
            {
                playerActionTurn();
            }
            else if (Form1.playerTurn == "CPU")
            {
                CPUActionTurn();
                shopButton.Visible = false;
            }
        }

        private void shopButton_Click(object sender, EventArgs e)
        {
            if (Form1.player.roundActions == 0 && Form1.player.roundCards == 0 && Form1.playerTurn == "Player")
            {
                Form1.playerTurn = "None";
                Form form = this.FindForm();
                GameScreen gs = new GameScreen();
                Form1.ChangeScreen(this, gs);
                //gs.playerBuyTurn();
            }
            for (int j = 0; j < 5; j++)
            {
                Form1.playerHand.Remove(Form1.playerHand[j]);
                Form1.playerHand.Add(Form1.playerHand[j]);
            }
        }

        #region actionTurn
        public void playerActionTurn()
        {
            for (int i = 0; i < 5; i++)
            {          
                if (Form1.playerHand[i].type == "Treasure" && Form1.player.roundActions == 1)
                {
                    shopButton.Visible = true;
                    Console.WriteLine("No cards avalible to play");
                    Form1.player.roundCoins += Form1.playerHand[i].coins;
                }             
            }
            Form1.player.roundActions = 0;
        }
        public void CPUActionTurn()
        {
            for (int i = 0; i < 5; i++)
            {
                if (Form1.computerhand[i].type == "Treasure")
                {
                    Form1.CPU.roundCoins += Form1.computerhand[i].coins;
                    Console.WriteLine("no cards for CPU");
                }
                else
                {
                    cpuDecision = new Random().Next(0, i);
                    Console.WriteLine($"{cpuDecision}");
                }
            }
            Form1.CPU.roundActions = 0;
            Form1.ChangeScreen(this, new GameScreen());
            GameScreen.CpuBuyTurn();
        }

        private void playerHandScreen_MouseClick(object sender, MouseEventArgs e)
        {
            Rectangle mouseRec = new Rectangle(e.X, e.Y, 1, 1);
            if (mouseRec.IntersectsWith(playerHandCard1) && Form1.player.roundActions >= 1 && Form1.playerTurn == "Player" && Form1.playerHand[0].type != "Treasure")
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
            if (Form1.playerTurn == "Player")
            {
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
            }
            else
            {
                for (int i = 0; i < Form1.computerhand.Count; i++)
                {
                    using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
                    {
                        e.Graphics.DrawString($"{Form1.computerhand[0].name}", font1, Brushes.White, playerHandCard1);
                        e.Graphics.DrawString($"{Form1.computerhand[1].name}", font1, Brushes.White, playerHandCard2);
                        e.Graphics.DrawString($"{Form1.computerhand[2].name}", font1, Brushes.White, playerHandCard3);
                        e.Graphics.DrawString($"{Form1.computerhand[3].name}", font1, Brushes.White, playerHandCard4);
                        e.Graphics.DrawString($"{Form1.computerhand[4].name}", font1, Brushes.White, playerHandCard5);
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
            }
            

            //Draws player stats for current round
            Rectangle statsDispaly = new Rectangle(650, 300, 150, 218);
            e.Graphics.FillRectangle(Brushes.Black, statsDispaly);
            if (Form1.playerTurn == "Player")
            {
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
            }
            else
            {
                for (int i = 0; i < Form1.computerhand.Count; i++)
                {
                    using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
                    {
                        e.Graphics.DrawString("CPU Stats", font1, Brushes.White, statsDispaly);
                        e.Graphics.DrawString($"\nCoins: {Form1.CPU.roundCoins}", font1, Brushes.White, statsDispaly);
                        e.Graphics.DrawString($"\n\nActions: {Form1.CPU.roundActions}", font1, Brushes.White, statsDispaly);
                        e.Graphics.DrawString($"\n\n\nBuys: {Form1.CPU.roundBuys}", font1, Brushes.White, statsDispaly);
                        e.Graphics.DrawString($"\n\n\n\nCards Playable: {Form1.CPU.roundCards}", font1, Brushes.White, statsDispaly);
                    }
                }
            }
           
        }

    }
}
