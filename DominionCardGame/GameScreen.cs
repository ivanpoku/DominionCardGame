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
        int timerValue;

        public static bool playerCanPlayCard = false;
        bool playerCanBuy = false;
        bool cpuCanBuy = false;
        public static bool mouseClicked = false;
        public GameScreen()
        {
            InitializeComponent();
            handButton.Visible = false;
            cardSlotCount.Text = $"{Form1.emptyPile.Count} Empty Card Slots";
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            timerValue++;
            Refresh();

        }

        private void handButton_Click(object sender, EventArgs e)
        {
            checkForEnd();
            Form1.playerTurn = "CPU";
            playerCanBuy = false;
            if (Form1.emptyPile.Count == 3)
            {
                Form1.ChangeScreen(this, new endScreen());
            }
            else
            {
                Form1.ChangeScreen(this, new playerHandScreen());
            }
        }

        #region Player Buy System
        public void playerBuyTurn()
        {
            playerCanBuy = true;
        }

        public void CpuBuyTurn()
        {

            cpuCanBuy = true;
            for (int i = 0; i < 16; i++)
            {
                //Creates Random Decision
                playerHandScreen.cpuDecision = new Random().Next(0, i);
                Console.WriteLine($"{playerHandScreen.cpuDecision}");
            }
            if (Form1.roundCards[playerHandScreen.cpuDecision].cost <= Form1.CPU.roundCoins && Form1.CPU.roundBuys >= 1)
            {
                Form1.computerhand.Add(Form1.roundCards[playerHandScreen.cpuDecision]);
                Form1.CPU.roundCoins -= Form1.roundCards[playerHandScreen.cpuDecision].cost;
                Form1.roundCards[playerHandScreen.cpuDecision].cardsAmount--;
                Console.WriteLine($"{Form1.roundCards[playerHandScreen.cpuDecision].name} bought");
                Form1.CPU.TotalVictory += Form1.roundCards[playerHandScreen.cpuDecision].victoryP;
                Form1.CPU.roundBuys = 0;
                Form1.playerTurn = "Player";
                Thread.Sleep(1000);
                Form1.ChangeScreen(this, new playerHandScreen());
            }
            else
            {
                Console.WriteLine("Card was too expensive");
                Form1.computerhand.Add(Form1.coins1);
                Form1.CPU.roundCoins -= Form1.coins1.cost;
                Form1.coins1.cardsAmount--;
                Console.WriteLine($"Copper bought");
                Form1.CPU.roundBuys = 0;
                Form1.playerTurn = "Player";
                Thread.Sleep(1000);
                Form1.ChangeScreen(this, new playerHandScreen());
            }

        }
        private void GameScreen_MouseClick(object sender, MouseEventArgs e)
        {

            //Adds card object to player hand list based off which card was clicked
            Rectangle mouseRec = new Rectangle(e.X, e.Y, 1, 1);
            timerValue = 0;
            if (mouseRec.IntersectsWith(Form1.cardRectangles[0]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
            {
                if (Form1.player.roundCoins >= Form1.coins1.cost && Form1.coins1.cardsAmount > 0)
                {
                    Form1.playerHand.Add(Form1.coins1);
                    Form1.player.roundCoins = Form1.player.roundCoins - Form1.coins1.cost;
                    Form1.player.roundBuys--;
                    Form1.coins1.cardsAmount--;
                }
            }
            else if (mouseRec.IntersectsWith(Form1.cardRectangles[1]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
            {
                if (Form1.player.roundCoins >= Form1.coins2.cost && Form1.coins2.cardsAmount > 0)
                {
                    Form1.playerHand.Add(Form1.coins2);
                    Form1.player.roundCoins -= Form1.coins2.cost;
                    Form1.player.roundBuys--;
                    Form1.coins2.cardsAmount--;
                }
            }
            else if (mouseRec.IntersectsWith(Form1.cardRectangles[2]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
            {
                if (Form1.player.roundCoins >= Form1.coins3.cost && Form1.coins3.cardsAmount > 0)
                {
                    Form1.playerHand.Add(Form1.coins3);
                    Form1.player.roundCoins -= Form1.coins3.cost;
                    Form1.player.roundBuys--;
                    Form1.coins3.cardsAmount--;
                }
            }
            else if (mouseRec.IntersectsWith(Form1.cardRectangles[3]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
            {
                if (Form1.player.roundCoins >= Form1.roundCards[7].cost && Form1.roundCards[7].cardsAmount > 0)
                {
                    Form1.playerHand.Add(Form1.roundCards[7]);
                    Form1.player.roundCoins -= Form1.roundCards[7].cost;
                    Form1.player.roundBuys--;
                    Form1.roundCards[7].cardsAmount--;
                }
            }
            else if (mouseRec.IntersectsWith(Form1.cardRectangles[4]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
            {
                if (Form1.player.roundCoins >= Form1.roundCards[8].cost && Form1.roundCards[8].cardsAmount > 0)
                {
                    Form1.playerHand.Add(Form1.roundCards[8]);
                    Form1.player.roundCoins -= Form1.roundCards[8].cost;
                    Form1.player.roundBuys--;
                    Form1.roundCards[8].cardsAmount--;
                }
            }
            else if (mouseRec.IntersectsWith(Form1.cardRectangles[5]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
            {
                if (Form1.player.roundCoins >= Form1.roundCards[9].cost && Form1.roundCards[9].cardsAmount > 0)
                {
                    Form1.playerHand.Add(Form1.roundCards[9]);
                    Form1.player.roundCoins -= Form1.roundCards[9].cost;
                    Form1.player.roundBuys--;
                    Form1.roundCards[9].cardsAmount--;
                }
            }
            else if (mouseRec.IntersectsWith(Form1.cardRectangles[6]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
            {
                if (Form1.player.roundCoins >= Form1.roundCards[10].cost && Form1.roundCards[10].cardsAmount > 0)
                {
                    Form1.playerHand.Add(Form1.roundCards[10]);
                    Form1.player.roundCoins -= Form1.roundCards[10].cost;
                    Form1.player.roundBuys--;
                    Form1.roundCards[10].cardsAmount--;
                }
            }
            else if (mouseRec.IntersectsWith(Form1.cardRectangles[7]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
            {
                if (Form1.player.roundCoins >= Form1.roundCards[11].cost && Form1.roundCards[11].cardsAmount > 0)
                {
                    Form1.playerHand.Add(Form1.roundCards[11]);
                    Form1.player.roundCoins -= Form1.roundCards[11].cost;
                    Form1.player.roundBuys--;
                    Form1.roundCards[11].cardsAmount--;
                }
            }
            else if (mouseRec.IntersectsWith(Form1.cardRectangles[8]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
            {
                if (Form1.player.roundCoins >= Form1.roundCards[12].cost && Form1.roundCards[12].cardsAmount > 0)
                {
                    Form1.playerHand.Add(Form1.roundCards[12]);
                    Form1.player.roundCoins -= Form1.roundCards[12].cost;
                    Form1.player.roundBuys--;
                    Form1.roundCards[12].cardsAmount--;
                }
            }
            else if (mouseRec.IntersectsWith(Form1.cardRectangles[9]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
            {
                if (Form1.player.roundCoins >= Form1.roundCards[13].cost && Form1.roundCards[13].cardsAmount > 0)
                {
                    Form1.playerHand.Add(Form1.roundCards[13]);
                    Form1.player.roundCoins -= Form1.roundCards[13].cost;
                    Form1.player.roundBuys--;
                    Form1.roundCards[13].cardsAmount--;
                }
            }
            else if (mouseRec.IntersectsWith(Form1.cardRectangles[10]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
            {
                if (Form1.player.roundCoins >= Form1.roundCards[14].cost && Form1.roundCards[14].cardsAmount > 0)
                {
                    Form1.playerHand.Add(Form1.roundCards[14]);
                    Form1.player.roundCoins -= Form1.roundCards[14].cost;
                    Form1.player.roundBuys--;
                    Form1.roundCards[14].cardsAmount--;
                }
            }
            else if (mouseRec.IntersectsWith(Form1.cardRectangles[11]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
            {
                if (Form1.player.roundCoins >= Form1.victory1.cost && Form1.victory1.cardsAmount > 0)
                {
                    Form1.playerHand.Add(Form1.victory1);
                    Form1.player.roundCoins -= Form1.victory1.cost;
                    Form1.player.roundBuys--;
                    Form1.victory1.cardsAmount--;
                    Form1.player.TotalVictory += Form1.victory1.victoryP;
                }
            }
            else if (mouseRec.IntersectsWith(Form1.cardRectangles[12]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
            {
                if (Form1.player.roundCoins >= Form1.victory2.cost && Form1.victory2.cardsAmount > 0)
                {
                    Form1.playerHand.Add(Form1.victory2);
                    Form1.player.roundCoins -= Form1.victory2.cost;
                    Form1.player.roundBuys--;
                    Form1.victory2.cardsAmount--;
                    Form1.player.TotalVictory += Form1.victory2.victoryP;
                }
            }
            else if (mouseRec.IntersectsWith(Form1.cardRectangles[13]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
            {
                if (Form1.player.roundCoins >= Form1.victory3.cost && Form1.coins3.cardsAmount > 0)
                {
                    Form1.playerHand.Add(Form1.victory3);
                    Form1.player.roundCoins -= Form1.victory3.cost;
                    Form1.player.roundBuys--;
                    Form1.victory3.cardsAmount--;
                    Form1.player.TotalVictory += Form1.victory3.victoryP;
                }
            }
            else if (mouseRec.IntersectsWith(Form1.cardRectangles[14]) && Form1.player.roundBuys >= 1 && playerCanBuy == true)
            {
                if (Form1.player.roundCoins >= Form1.negVictory.cost && Form1.negVictory.cardsAmount > 0)
                {
                    Form1.playerHand.Add(Form1.negVictory);
                    Form1.player.roundCoins -= Form1.negVictory.cost;
                    Form1.player.roundBuys--;
                    Form1.negVictory.cardsAmount--;
                    Form1.player.TotalVictory += Form1.negVictory.victoryP;
                }
            }
            if (Form1.player.roundBuys == 0)
            {
                handButton.Visible = true;
            }
            cardSlotCount.Text = $"{Form1.emptyPile.Count} Empty Card Slots";
            Refresh();

        }
        #endregion

        public void checkForEnd()
        {
            for (int i = 0; i < Form1.roundCards.Count; i++)
            {
                if (Form1.roundCards[i].cardsAmount == 0)
                {
                    Form1.emptyPile.Add(Form1.roundCards[i]);
                    Form1.roundCards[i].cardsAmount = -1;
                }
            }

        }
        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //Draws all rectangles and displays card stats
            foreach (Rectangle rectangle in Form1.cardRectangles)
            {
                e.Graphics.FillRectangle(Brushes.White, rectangle);
                foreach (Card card in Form1.allCards)
                {
                    using (Font font1 = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point))
                    {
                        e.Graphics.DrawString($"{Form1.coins1.name}\nCost:{Form1.coins1.cost}\n+{Form1.coins1.coins} Coins", font1, Brushes.Black, Form1.cardRectangles[0]);
                        e.Graphics.DrawString($"{Form1.coins2.name}\nCost:{Form1.coins2.cost}\n+{Form1.coins2.coins} Coins", font1, Brushes.Black, Form1.cardRectangles[1]);
                        e.Graphics.DrawString($"{Form1.coins3.name}\nCost:{Form1.coins3.cost}\n+{Form1.coins3.coins} Coins", font1, Brushes.Black, Form1.cardRectangles[2]);
                        e.Graphics.DrawString($"{Form1.roundCards[7].name}\nCost:{Form1.roundCards[7].cost}\nActions +{Form1.roundCards[7].actions}\nBuys +{Form1.roundCards[7].buys}\nCards +{Form1.roundCards[7].cards}\n+{Form1.roundCards[7].coins} Coins", font1, Brushes.Black, Form1.cardRectangles[3]);
                        e.Graphics.DrawString($"{Form1.roundCards[8].name}\nCost:{Form1.roundCards[8].cost}\nActions +{Form1.roundCards[8].actions}\nBuys +{Form1.roundCards[8].buys}\nCards +{Form1.roundCards[8].cards}\n+{Form1.roundCards[8].coins} Coins", font1, Brushes.Black, Form1.cardRectangles[4]);
                        e.Graphics.DrawString($"{Form1.roundCards[9].name}\nCost:{Form1.roundCards[9].cost}\nActions +{Form1.roundCards[9].actions}\nBuys +{Form1.roundCards[9].buys}\nCards +{Form1.roundCards[9].cards}\n+{Form1.roundCards[9].coins} Coins", font1, Brushes.Black, Form1.cardRectangles[5]);
                        e.Graphics.DrawString($"{Form1.roundCards[10].name}\nCost:{Form1.roundCards[10].cost}\nActions +{Form1.roundCards[10].actions}\nBuys +{Form1.roundCards[10].buys}\nCards +{Form1.roundCards[10].cards}\n+{Form1.roundCards[10].coins} Coins", font1, Brushes.Black, Form1.cardRectangles[6]);
                        e.Graphics.DrawString($"{Form1.roundCards[11].name}\nCost:{Form1.roundCards[11].cost}\nActions +{Form1.roundCards[11].actions}\nBuys +{Form1.roundCards[11].buys}\nCards +{Form1.roundCards[11].cards}\n+{Form1.roundCards[11].coins} Coins", font1, Brushes.Black, Form1.cardRectangles[7]);
                        e.Graphics.DrawString($"{Form1.roundCards[12].name}\nCost:{Form1.roundCards[12].cost}\nActions +{Form1.roundCards[12].actions}\nBuys +{Form1.roundCards[12].buys}\nCards +{Form1.roundCards[12].cards}\n+{Form1.roundCards[12].coins} Coins", font1, Brushes.Black, Form1.cardRectangles[8]);
                        e.Graphics.DrawString($"{Form1.roundCards[13].name}\nCost:{Form1.roundCards[13].cost}\nActions +{Form1.roundCards[13].actions}\nBuys +{Form1.roundCards[13].buys}\nCards +{Form1.roundCards[13].cards}\n+{Form1.roundCards[13].coins} Coins", font1, Brushes.Black, Form1.cardRectangles[9]);
                        e.Graphics.DrawString($"{Form1.roundCards[14].name}\nCost:{Form1.roundCards[14].cost}\nActions +{Form1.roundCards[14].actions}\nBuys +{Form1.roundCards[14].buys}\nCards +{Form1.roundCards[14].cards}\n+{Form1.roundCards[14].coins} Coins", font1, Brushes.Black, Form1.cardRectangles[10]);
                        e.Graphics.DrawString($"{Form1.victory1.name}\nCost:{Form1.victory1.cost}\n+{Form1.victory1.victoryP} Victory Points", font1, Brushes.Black, Form1.cardRectangles[11]);
                        e.Graphics.DrawString($"{Form1.victory2.name}\nCost:{Form1.victory2.cost}\n+{Form1.victory2.victoryP} Victory Points", font1, Brushes.Black, Form1.cardRectangles[12]);
                        e.Graphics.DrawString($"{Form1.victory3.name}\nCost:{Form1.victory3.cost}\n+{Form1.victory3.victoryP} Victory Points", font1, Brushes.Black, Form1.cardRectangles[13]);
                        e.Graphics.DrawString($"{Form1.negVictory.name}\nCost:{Form1.negVictory.cost}\n{Form1.negVictory.victoryP} Victory Points", font1, Brushes.Black, Form1.cardRectangles[14]);
                    }
                }
            }

            //Draws player and cpu stats
            Rectangle statsDispaly = new Rectangle(675, 368, 125, 150);
            e.Graphics.FillRectangle(Brushes.Black, statsDispaly);
            if (playerCanBuy == true)
            {
                for (int i = 0; i < Form1.playerHand.Count; i++)
                {
                    using (Font font1 = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point))
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
            if (cpuCanBuy == true)
            {
                for (int i = 0; i < Form1.computerhand.Count; i++)
                {
                    using (Font font1 = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point))
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
    }
}
