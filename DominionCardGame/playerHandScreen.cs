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
        public static Rectangle playerHandCard1 = new Rectangle(30, 350, 100, 150);
        public static Rectangle playerHandCard2 = new Rectangle(145, 350, 100, 150);
        public static Rectangle playerHandCard3 = new Rectangle(260, 350, 100, 150);
        public static Rectangle playerHandCard4 = new Rectangle(375, 350, 100, 150);
        public static Rectangle playerHandCard5 = new Rectangle(490, 350, 100, 150);

        List<Rectangle> handCard = new List<Rectangle>();

        public playerHandScreen()
        {
            InitializeComponent();
            shopButton.Visible = false;
            playerHandCard1 = new Rectangle(30, 350, 100, 150);
            playerHandCard2 = new Rectangle(145, 350, 100, 150);
            playerHandCard3 = new Rectangle(260, 350, 100, 150);
            playerHandCard4 = new Rectangle(375, 350, 100, 150);
            playerHandCard5 = new Rectangle(490, 350, 100, 150);
            handCard.Add(playerHandCard1);
            handCard.Add(playerHandCard2);
            handCard.Add(playerHandCard3);
            handCard.Add(playerHandCard4);
            handCard.Add(playerHandCard5);
            Thread.Sleep(1000);
            Refresh();
        }

        private void shopButton_Click(object sender, EventArgs e)
        {
            //if (Form1.player.roundActions == 0 && Form1.player.roundCards == 0 && Form1.playerTurn == "Player")
            //{
            //Form1.playerTurn = "None";
            GameScreen gs = new GameScreen();
            Form1.ChangeScreen(this, gs);
            gs.playerBuyTurn();
            //}
            for (int i = 0; i < 5; i++)
            {
                var currentHand = Form1.playerHand[i];
                Form1.playerHand.RemoveAt(i);
                Form1.playerHand.Add(currentHand);
            }
        }

        public void drawButton_Click(object sender, EventArgs e)
        {
            if (Form1.player.roundCards >= 1)
            {
                Rectangle drawRec = new Rectangle(30, 180, 100, 150);
                Form1.player.roundCards--;
            }
        }
        #region actionTurn
        public void playerActionTurn()
        {
            Form1.player.roundActions = 1;
            Form1.player.roundCoins = 0;
            Form1.player.roundBuys = 1;
            Form1.player.roundCards = 0;
            if (Form1.playerTurn == "Player")
            {
                for (int i = 0; i < 5; i++)
                {
                    if (Form1.playerHand[i].type != "Attack" && Form1.playerHand[i].type != "Action" && Form1.playerHand[i].type != "Reaction" && Form1.player.roundActions >= 1)
                    {
                        shopButton.Visible = true;
                        Console.WriteLine("No cards avalible to play");
                        Form1.player.roundCoins += Form1.playerHand[i].coins;

                    }
                }
            }
        }
        public void CPUActionTurn()
        {
            Form1.CPU.roundCoins = 0;
            Form1.CPU.roundBuys = 1;
            Form1.CPU.roundActions = 1;
            Form1.CPU.roundCards = 0;
            if (Form1.playerTurn == "CPU")
            {
                
                for (int i = 0; i < 5; i++)
                {
                    cpuDecision = new Random().Next(0, 5);
                    if (Form1.computerhand[i].type != "Action" && Form1.computerhand[i].type != "Attack" && Form1.computerhand[i].type != "Reaction")
                    {
                        Form1.CPU.roundCoins += Form1.computerhand[i].coins;
                        Console.WriteLine("no cards for CPU");
                    }
                    
                }
                if (Form1.computerhand[cpuDecision].type != "Treasure" && Form1.computerhand[cpuDecision].type != "Victory")
                {
                    Form1.CPU.roundCoins += Form1.computerhand[cpuDecision].coins;
                    Form1.CPU.roundActions += Form1.computerhand[cpuDecision].actions;
                    Form1.CPU.roundBuys += Form1.computerhand[cpuDecision].buys;
                    Form1.CPU.roundCards += Form1.computerhand[cpuDecision].cards;
                    Form1.CPU.roundActions--;
                    Console.WriteLine($"{Form1.computerhand[cpuDecision].name} Played");
                    Form1.cpuCardsPlayed++;
                }

                    Form1.CPU.roundActions = 0;
                for (int j = 0; j < 5; j++)
                {
                    var currentHand = Form1.computerhand[j];
                    Form1.computerhand.RemoveAt(j);
                    Form1.computerhand.Add(currentHand);
                }
                Thread.Sleep(1000);
                Refresh();
                GameScreen gs = new GameScreen();
                Form1.ChangeScreen(this, gs);
                gs.CpuBuyTurn();
            }

        }

        private void playerHandScreen_MouseClick(object sender, MouseEventArgs e)
        {
            Rectangle mouseRec = new Rectangle(e.X, e.Y, 1, 1);
           /* if (mouseRec.IntersectsWith(playerHandCard1) && Form1.player.roundActions >= 1 && Form1.playerTurn == "Player" && Form1.playerHand[0].type != "Treasure" && Form1.playerHand[0].type != "Victory")
            {
                Form1.player.roundCards += Form1.playerHand[0].cards;
                Form1.player.roundBuys += Form1.playerHand[0].buys;
                Form1.player.roundCoins += Form1.playerHand[0].coins;
                Form1.player.roundActions += Form1.playerHand[0].actions;
                Form1.player.roundActions--;
                playerHandCard1 = new Rectangle(200, 150, 100, 150);
            }
            if (mouseRec.IntersectsWith(playerHandCard2) && Form1.player.roundActions >= 1 && Form1.playerTurn == "Player" && Form1.playerHand[1].type != "Treasure" && Form1.playerHand[0].type != "Victory")
            {
                Form1.player.roundCards += Form1.playerHand[1].cards;
                Form1.player.roundBuys += Form1.playerHand[1].buys;
                Form1.player.roundCoins += Form1.playerHand[1].coins;
                Form1.player.roundActions += Form1.playerHand[1].actions;
                Form1.player.roundActions--;
                playerHandCard2 = new Rectangle(200, 150, 100, 150);
            }
            if (mouseRec.IntersectsWith(playerHandCard3) && Form1.player.roundActions >= 1 && Form1.playerTurn == "Player" && Form1.playerHand[2].type != "Treasure" && Form1.playerHand[0].type != "Victory")
            {
                Form1.player.roundCards += Form1.playerHand[2].cards;
                Form1.player.roundBuys += Form1.playerHand[2].buys;
                Form1.player.roundCoins += Form1.playerHand[2].coins;
                Form1.player.roundActions += Form1.playerHand[2].actions;
                Form1.player.roundActions--;
                playerHandCard3 = new Rectangle(200, 150, 100, 150);
            }
            if (mouseRec.IntersectsWith(playerHandCard4) && Form1.player.roundActions >= 1 && Form1.playerTurn == "Player" && Form1.playerHand[3].type != "Treasure" && Form1.playerHand[0].type != "Victory")
            {
                Form1.player.roundCards += Form1.playerHand[3].cards;
                Form1.player.roundBuys += Form1.playerHand[3].buys;
                Form1.player.roundCoins += Form1.playerHand[3].coins;
                Form1.player.roundActions += Form1.playerHand[3].actions;
                Form1.player.roundActions--;
                playerHandCard4 = new Rectangle(200, 150, 100, 150);
            }
            if (mouseRec.IntersectsWith(playerHandCard5) && Form1.player.roundActions >= 1 && Form1.playerTurn == "Player" && Form1.playerHand[4].type != "Treasure" && Form1.playerHand[0].type != "Victory")
            {
                Form1.player.roundCards += Form1.playerHand[4].cards;
                Form1.player.roundBuys += Form1.playerHand[4].buys;
                Form1.player.roundCoins += Form1.playerHand[4].coins;
                Form1.player.roundActions += Form1.playerHand[4].actions;
                Form1.player.roundActions--;
                playerHandCard5 = new Rectangle(200, 150, 100, 150);
            }
           */
            for (int i = 0; i < 5; i++)
            {
                if (mouseRec.IntersectsWith(handCard[i]) && Form1.player.roundActions >= 1 && Form1.playerTurn == "Player" && Form1.playerHand[i].type != "Treasure" && Form1.playerHand[i].type != "Victory")
                {
                    Form1.player.roundCards += Form1.playerHand[i].cards;
                    Form1.player.roundBuys += Form1.playerHand[i].buys;
                    Form1.player.roundCoins += Form1.playerHand[i].coins;
                    Form1.player.roundActions += Form1.playerHand[i].actions;
                    Form1.player.roundActions--;
                    Form1.playerCardsPlayed++;
                    handCard[i] = new Rectangle(200, 150, 100, 150);
                }
            }
            if (Form1.player.roundCards >= 1)
            {
                drawButton.Visible = true;
            }
            Refresh();
        }
        #endregion

        public void playerHandScreen_Paint(object sender, PaintEventArgs e)
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
                    using (Font font1 = new Font("Arial", 11, FontStyle.Regular, GraphicsUnit.Point))
                    {
                        e.Graphics.DrawString($"{Form1.playerHand[0].name} \n\nCoins:{Form1.playerHand[0].coins} \nActions:{Form1.playerHand[0].actions} \nBuys:{Form1.playerHand[0].buys} \nCards:{Form1.playerHand[0].cards} \nVictory:{Form1.playerHand[0].victoryP}", font1, Brushes.White, playerHandCard1);
                        e.Graphics.DrawString($"{Form1.playerHand[1].name} \n\nCoins:{Form1.playerHand[1].coins} \nActions:{Form1.playerHand[1].actions} \nBuys:{Form1.playerHand[1].buys} \nCards:{Form1.playerHand[1].cards} \nVictory:{Form1.playerHand[1].victoryP}", font1, Brushes.White, playerHandCard2);
                        e.Graphics.DrawString($"{Form1.playerHand[2].name} \n\nCoins:{Form1.playerHand[2].coins} \nActions:{Form1.playerHand[2].actions} \nBuys:{Form1.playerHand[2].buys} \nCards:{Form1.playerHand[2].cards} \nVictory:{Form1.playerHand[2].victoryP}", font1, Brushes.White, playerHandCard3);
                        e.Graphics.DrawString($"{Form1.playerHand[3].name} \n\nCoins:{Form1.playerHand[3].coins} \nActions:{Form1.playerHand[3].actions} \nBuys:{Form1.playerHand[3].buys} \nCards:{Form1.playerHand[3].cards} \nVictory:{Form1.playerHand[3].victoryP}", font1, Brushes.White, playerHandCard4);
                        e.Graphics.DrawString($"{Form1.playerHand[4].name} \n\nCoins:{Form1.playerHand[4].coins} \nActions:{Form1.playerHand[4].actions} \nBuys:{Form1.playerHand[4].buys} \nCards:{Form1.playerHand[4].cards} \nVictory:{Form1.playerHand[4].victoryP}", font1, Brushes.White, playerHandCard5);
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
                    using (Font font1 = new Font("Arial", 11, FontStyle.Regular, GraphicsUnit.Point))
                    {
                        e.Graphics.DrawString($"{Form1.computerhand[0].name} \n\nCoins:{Form1.computerhand[0].coins} \nActions:{Form1.computerhand[0].actions} \nBuys:{Form1.computerhand[0].buys} \nCards:{Form1.computerhand[0].cards} \nVictory:{Form1.computerhand[0].victoryP}", font1, Brushes.White, playerHandCard1);
                        e.Graphics.DrawString($"{Form1.computerhand[1].name} \n\nCoins:{Form1.computerhand[1].coins} \nActions:{Form1.computerhand[1].actions} \nBuys:{Form1.computerhand[1].buys} \nCards:{Form1.computerhand[1].cards} \nVictory:{Form1.computerhand[1].victoryP}", font1, Brushes.White, playerHandCard2);
                        e.Graphics.DrawString($"{Form1.computerhand[2].name} \n\nCoins:{Form1.computerhand[2].coins} \nActions:{Form1.computerhand[2].actions} \nBuys:{Form1.computerhand[2].buys} \nCards:{Form1.computerhand[2].cards} \nVictory:{Form1.computerhand[2].victoryP}", font1, Brushes.White, playerHandCard3);
                        e.Graphics.DrawString($"{Form1.computerhand[3].name} \n\nCoins:{Form1.computerhand[3].coins} \nActions:{Form1.computerhand[3].actions} \nBuys:{Form1.computerhand[3].buys} \nCards:{Form1.computerhand[3].cards} \nVictory:{Form1.computerhand[3].victoryP}", font1, Brushes.White, playerHandCard4);
                        e.Graphics.DrawString($"{Form1.computerhand[4].name} \n\nCoins:{Form1.computerhand[4].coins} \nActions:{Form1.computerhand[4].actions} \nBuys:{Form1.computerhand[4].buys} \nCards:{Form1.computerhand[4].cards} \nVictory:{Form1.computerhand[4].victoryP}", font1, Brushes.White, playerHandCard5);
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
                        e.Graphics.DrawString($"\n\n\n\n\nTotal Victory: {Form1.player.TotalVictory}", font1, Brushes.White, statsDispaly);
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
                        e.Graphics.DrawString($"\n\n\n\n\nTotal Victory: {Form1.CPU.TotalVictory}", font1, Brushes.White, statsDispaly);
                    }
                }
            }
        }

        private void playerHandScreen_Load(object sender, EventArgs e)
        {
            playerActionTurn();
            CPUActionTurn();
        }


    }
}
