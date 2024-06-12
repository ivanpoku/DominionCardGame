using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Threading;

namespace DominionCardGame
{
    public partial class GameScreen : UserControl
    {
        playerHandScreen ps = new playerHandScreen();

        public int roundCoins;
        public int roundActions;

        public static bool playerCanPlayCard = false;
        public static bool playerCanBuy = false;
        public static bool mouseClicked = false;
        public GameScreen()
        {
            InitializeComponent();
            handButton.Visible = true;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }
        private void handButton_Click(object sender, EventArgs e)
        {
            if (Form1.player.roundCoins == 0)
            {
                playerCanBuy = false;
                Thread.Sleep(100);
                playerHandScreen ps = new playerHandScreen();
                Form f = this.FindForm();
                f.Controls.Add(ps);
                f.Controls.Remove(this);
                playerHandScreen.CPUActionTurn();
                handButton.Visible = false;
            }
            
        }

        public static void updateStats()
        {
            Form1.player.TotalVictory = 0;
            for (int i = 0; i < Form1.playerHand.Count; i++)
            {
                Form1.player.TotalVictory += Form1.playerHand[i].victoryP;

            }
        }

        #region Player Buy System
        public static void playerBuyTurn()
        {
            playerCanBuy = true;
        }

        public static void CpuBuyTurn()
        {

        }
        private void GameScreen_MouseClick(object sender, MouseEventArgs e)
        {
            Rectangle mouseRec = new Rectangle(e.X, e.Y, 1, 1);
            foreach (Rectangle rectangle in Form1.cardRectangles)
            {
                if (mouseRec.IntersectsWith(Form1.cardRectangles[0]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
                {
                    if (Form1.player.roundCoins >= Form1.coins1.cost)
                    {
                        Form1.playerHand.Add(Form1.coins1);
                        Form1.player.roundCoins = Form1.player.roundCoins - Form1.coins1.cost;
                        Form1.player.roundBuys--;
                    }
                }
                else if (mouseRec.IntersectsWith(Form1.cardRectangles[1]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
                {
                    if (Form1.player.roundCoins >= Form1.coins2.cost)
                    {
                        Form1.playerHand.Add(Form1.coins2);
                        Form1.player.roundCoins -= Form1.coins2.cost;
                        Form1.player.roundBuys--;
                    }
                }
                else if (mouseRec.IntersectsWith(Form1.cardRectangles[2]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
                {
                    if (Form1.player.roundCoins >= Form1.coins3.cost)
                    {
                        Form1.playerHand.Add(Form1.coins3);
                        Form1.player.roundCoins -= Form1.coins3.cost;
                        Form1.player.roundBuys--;
                    }
                }
                else if (mouseRec.IntersectsWith(Form1.cardRectangles[3]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
                {
                    if (Form1.player.roundCoins >= Form1.roundCards[0].cost)
                    {
                        Form1.playerHand.Add(Form1.roundCards[0]);
                        Form1.player.roundCoins -= Form1.roundCards[0].cost;
                        Form1.player.roundBuys--;
                    }
                }
                else if (mouseRec.IntersectsWith(Form1.cardRectangles[4]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
                {
                    if (Form1.player.roundCoins >= Form1.roundCards[1].cost)
                    {
                        Form1.playerHand.Add(Form1.roundCards[1]);
                        Form1.player.roundCoins -= Form1.roundCards[1].cost;
                        Form1.player.roundBuys--;
                    }
                }
                else if (mouseRec.IntersectsWith(Form1.cardRectangles[5]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
                {
                    if (Form1.player.roundCoins >= Form1.roundCards[2].cost)
                    {
                        Form1.playerHand.Add(Form1.roundCards[2]);
                        Form1.player.roundCoins -= Form1.roundCards[2].cost;
                        Form1.player.roundBuys--;
                    }
                }
                else if (mouseRec.IntersectsWith(Form1.cardRectangles[6]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
                {
                    if (Form1.player.roundCoins >= Form1.roundCards[3].cost)
                    {
                        Form1.playerHand.Add(Form1.roundCards[3]);
                        Form1.player.roundCoins -= Form1.roundCards[3].cost;
                        Form1.player.roundBuys--;
                    }
                }
                else if (mouseRec.IntersectsWith(Form1.cardRectangles[7]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
                {
                    if (Form1.player.roundCoins >= Form1.roundCards[4].cost)
                    {
                        Form1.playerHand.Add(Form1.roundCards[4]);
                        Form1.player.roundCoins -= Form1.roundCards[4].cost;
                        Form1.player.roundBuys--;
                    }
                }
                else if (mouseRec.IntersectsWith(Form1.cardRectangles[8]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
                {
                    if (Form1.player.roundCoins >= Form1.roundCards[5].cost)
                    {
                        Form1.playerHand.Add(Form1.roundCards[5]);
                        Form1.player.roundCoins -= Form1.roundCards[5].cost;
                        Form1.player.roundBuys--;
                    }
                }
                else if (mouseRec.IntersectsWith(Form1.cardRectangles[9]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
                {
                    if (Form1.player.roundCoins >= Form1.roundCards[6].cost)
                    {
                        Form1.playerHand.Add(Form1.roundCards[6]);
                        Form1.player.roundCoins -= Form1.roundCards[6].cost;
                        Form1.player.roundBuys--;
                    }
                }
                else if (mouseRec.IntersectsWith(Form1.cardRectangles[10]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
                {
                    if (Form1.player.roundCoins >= Form1.roundCards[7].cost)
                    {
                        Form1.playerHand.Add(Form1.roundCards[7]);
                        Form1.player.roundCoins -= Form1.roundCards[7].cost;
                        Form1.player.roundBuys--;
                    }
                }
                else if (mouseRec.IntersectsWith(Form1.cardRectangles[11]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
                {
                    if (Form1.player.roundCoins >= Form1.victory1.cost)
                    {
                        Form1.playerHand.Add(Form1.victory1);
                        Form1.player.roundCoins -= Form1.victory1.cost;
                        Form1.player.roundBuys--;
                    }
                }
                else if (mouseRec.IntersectsWith(Form1.cardRectangles[12]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
                {
                    if (Form1.player.roundCoins >= Form1.victory2.cost)
                    {
                        Form1.playerHand.Add(Form1.victory2);
                        Form1.player.roundCoins -= Form1.victory2.cost;
                        Form1.player.roundBuys--;
                    }
                }
                else if (mouseRec.IntersectsWith(Form1.cardRectangles[13]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
                {
                    if (Form1.player.roundCoins >= Form1.victory3.cost)
                    {
                        Form1.playerHand.Add(Form1.victory3);
                        Form1.player.roundCoins -= Form1.victory3.cost;
                        Form1.player.roundBuys--;
                    }
                }
                else if (mouseRec.IntersectsWith(Form1.cardRectangles[14]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
                {
                    if (Form1.player.roundCoins >= Form1.negVictory.cost)
                    {
                        Form1.playerHand.Add(Form1.negVictory);
                        Form1.player.roundCoins -= Form1.negVictory.cost;
                        Form1.player.roundBuys--;
                    }
                }
                if (Form1.player.roundBuys == 0)
                {
                    handButton.Visible = true;
                }
                Console.WriteLine($"{rectangle} Clicked, Player Coins: {Form1.player.roundCoins}");
                updateStats();

            }
        }
        #endregion
        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //Draws all rectangles and displays card stats
            foreach (Rectangle rectangle in Form1.cardRectangles)
            {
                e.Graphics.FillRectangle(Brushes.White, rectangle);
                foreach (Card card in Form1.allCards)
                {
                    e.Graphics.DrawImage(playerHandScreen.cardImage, rectangle);
                    using (Font font1 = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point))
                    {
                        e.Graphics.DrawString($"{Form1.coins1.name}\nCost:{Form1.coins1.cost}\n+{Form1.coins1.coins} Treasure", font1, Brushes.Black, Form1.cardRectangles[0]);
                        e.Graphics.DrawString($"{Form1.coins2.name}\nCost:{Form1.coins2.cost}\n+{Form1.coins2.coins} Treasure", font1, Brushes.Black, Form1.cardRectangles[1]);
                        e.Graphics.DrawString($"{Form1.coins3.name}\nCost:{Form1.coins3.cost}\n+{Form1.coins3.coins} Treasure", font1, Brushes.Black, Form1.cardRectangles[2]);
                        e.Graphics.DrawString($"{Form1.roundCards[0].name}\nCost:{Form1.roundCards[0].cost}\nActions +{Form1.roundCards[0].actions}\nBuys +{Form1.roundCards[0].buys}\nCards +{Form1.roundCards[0].cards}\n+{Form1.roundCards[0].coins} Coins", font1, Brushes.Black, Form1.cardRectangles[3]);
                        e.Graphics.DrawString($"{Form1.roundCards[1].name}\nCost:{Form1.roundCards[1].cost}\nActions +{Form1.roundCards[1].actions}\nBuys +{Form1.roundCards[1].buys}\nCards +{Form1.roundCards[1].cards}\n+{Form1.roundCards[1].coins} Coins", font1, Brushes.Black, Form1.cardRectangles[4]);
                        e.Graphics.DrawString($"{Form1.roundCards[2].name}\nCost:{Form1.roundCards[2].cost}\nActions +{Form1.roundCards[2].actions}\nBuys +{Form1.roundCards[2].buys}\nCards +{Form1.roundCards[2].cards}\n+{Form1.roundCards[2].coins} Coins", font1, Brushes.Black, Form1.cardRectangles[5]);
                        e.Graphics.DrawString($"{Form1.roundCards[3].name}\nCost:{Form1.roundCards[3].cost}\nActions +{Form1.roundCards[3].actions}\nBuys +{Form1.roundCards[3].buys}\nCards +{Form1.roundCards[3].cards}\n+{Form1.roundCards[3].coins} Coins", font1, Brushes.Black, Form1.cardRectangles[6]);
                        e.Graphics.DrawString($"{Form1.roundCards[4].name}\nCost:{Form1.roundCards[4].cost}\nActions +{Form1.roundCards[4].actions}\nBuys +{Form1.roundCards[4].buys}\nCards +{Form1.roundCards[4].cards}\n+{Form1.roundCards[4].coins} Coins", font1, Brushes.Black, Form1.cardRectangles[7]);
                        e.Graphics.DrawString($"{Form1.roundCards[5].name}\nCost:{Form1.roundCards[5].cost}\nActions +{Form1.roundCards[5].actions}\nBuys +{Form1.roundCards[5].buys}\nCards +{Form1.roundCards[5].cards}\n+{Form1.roundCards[5].coins} Coins", font1, Brushes.Black, Form1.cardRectangles[8]);
                        e.Graphics.DrawString($"{Form1.roundCards[6].name}\nCost:{Form1.roundCards[6].cost}\nActions +{Form1.roundCards[6].actions}\nBuys +{Form1.roundCards[6].buys}\nCards +{Form1.roundCards[6].cards}\n+{Form1.roundCards[6].coins} Coins", font1, Brushes.Black, Form1.cardRectangles[9]);
                        e.Graphics.DrawString($"{Form1.roundCards[7].name}\nCost:{Form1.roundCards[7].cost}\nActions +{Form1.roundCards[7].actions}\nBuys +{Form1.roundCards[7].buys}\nCards +{Form1.roundCards[7].cards}\n+{Form1.roundCards[7].coins} Coins", font1, Brushes.Black, Form1.cardRectangles[10]);
                        e.Graphics.DrawString($"{Form1.victory1.name}\nCost:{Form1.victory1.cost}\n+{Form1.victory1.victoryP} Victory Points", font1, Brushes.Black, Form1.cardRectangles[11]);
                        e.Graphics.DrawString($"{Form1.victory2.name}\nCost:{Form1.victory2.cost}\n+{Form1.victory2.victoryP} Victory Points", font1, Brushes.Black, Form1.cardRectangles[12]);
                        e.Graphics.DrawString($"{Form1.victory3.name}\nCost:{Form1.victory3.cost}\n+{Form1.victory3.victoryP} Victory Points", font1, Brushes.Black, Form1.cardRectangles[13]);
                        e.Graphics.DrawString($"{Form1.negVictory.name}\nCost:{Form1.negVictory.cost}\n{Form1.negVictory.victoryP} Victory Points", font1, Brushes.Black, Form1.cardRectangles[14]);
                    }
                }
            }

            Rectangle statsDispaly = new Rectangle(675, 368, 125, 150);
            e.Graphics.FillRectangle(Brushes.Black, statsDispaly);
            for (int i = 0; i < Form1.playerHand.Count; i++)
            {
                using (Font font1 = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point))
                {
                    e.Graphics.DrawString("Player Stats", font1, Brushes.White, statsDispaly);
                    e.Graphics.DrawString($"\nCoins: {Form1.player.roundCoins}", font1, Brushes.White, statsDispaly);
                    e.Graphics.DrawString($"\n\nActions: {Form1.playerHand[0].actions + Form1.playerHand[1].actions + Form1.playerHand[2].actions + Form1.playerHand[3].actions + Form1.playerHand[4].actions}", font1, Brushes.White, statsDispaly);
                    e.Graphics.DrawString($"\n\n\nBuys: {Form1.player.roundBuys}", font1, Brushes.White, statsDispaly);
                    e.Graphics.DrawString($"\n\n\n\nCards Playable: {Form1.playerHand[0].cards + Form1.playerHand[1].cards + Form1.playerHand[2].cards + Form1.playerHand[3].cards + Form1.playerHand[4].cards}", font1, Brushes.White, statsDispaly);
                    e.Graphics.DrawString($"\n\n\n\n\nTotal Victory: {Form1.player.TotalVictory}", font1, Brushes.White, statsDispaly);
                }
            }
            //Refresh();
        }
    }
}
