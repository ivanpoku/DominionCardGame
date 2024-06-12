using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DominionCardGame
{
    public partial class Form1 : Form
    {
        public static int decideCards;
        public static List<Rectangle> cardRectangles = new List<Rectangle>();

        public static List<Card> allCards = new List<Card>();
        public static List<Card> roundCards = new List<Card>();
        public static List<Card> playerHand = new List<Card>();
        public static List<Card> computerhand = new List<Card>();

        public static Card coins1 = new Card(1, 0, 0, 0, 0, "Copper", 0, "Treasure", "Properties/Resources/372px-Copper.jpg");
        public static Card coins2 = new Card(2, 0, 0, 0, 0, "Silver", 3, "Treasure", "Properties/Resources/375px-Silver.jpg");
        public static Card coins3 = new Card(3, 0, 0, 0, 0, "Gold", 6, "Treasure", "Properties/Resources/375px-Gold.jpg");
        public static Card victory1 = new Card(0, 0, 0, 0, 1, "Estate", 2, "Victory", "Properties/Resources/373px-Estate.jpg");
        public static Card victory2 = new Card(0, 0, 0, 0, 3, "Dutchy", 5, "Victory", "Properties/Resources/372px-Dutchy.jpg");
        public static Card victory3 = new Card(0, 0, 0, 0, 6, "Province", 8, "Victory", "Properties/Resources/375px-Province.jpg");
        public static Card negVictory = new Card(0, 0, 0, 0, -1, "Curse", 0, "Curse", "Properties/Resources/372px-Curse.jpg");

        public static Player player = new Player(0, 0, 1, 1, 0, 0);
        public static Player CPU = new Player(0, 0, 0, 0, 0, 0);
        public Form1()
        {
            InitializeComponent();
            initializeCards();
            Form f = this.FindForm();
            playerHandScreen ps = new playerHandScreen();
            GameScreen gs = new GameScreen();
            ChangeScreen(f, ps);

            playerHandScreen.playerActionTurn();
            GameScreen.updateStats();

            //ChangeScreen(ps, gs);
            //GameScreen.playerBuyTurn();
            GameScreen.updateStats();

            //ChangeScreen(gs, ps);
            //playerHandScreen.CPUActionTurn();
            Thread.Sleep(1000);

            //ChangeScreen(ps, gs);
            //GameScreen.CpuBuyTurn();

        }

        public static void ChangeScreen(object sender, UserControl next)
        {
            Form f; // will either be the sender or parent of sender 
            if (sender is Form)
            {
                f = (Form)sender;
            }
            else
            {
                UserControl current = (UserControl)sender;
                f = current.FindForm();
                f.Controls.Remove(current);
            }
            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,

                (f.ClientSize.Height - next.Height) / 2);
            f.Controls.Add(next);
            next.Focus();
        }

        public void initializeCards()
        {
            int cardCoins;
            int cardActions;
            int cardBuys;
            int cardCards;
            int cardVictoryP;
            int cardCost;
            string cardName;
            string cardType;
            string cardImage;

            int recX;
            int recY;
            int recWidth;
            int recHeight;
            string recName;

            //Loads Cards from XML
            XmlReader reader = XmlReader.Create("Resources/allCards.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    cardCoins = Convert.ToInt16(reader.ReadString());

                    reader.ReadToNextSibling("actions");
                    cardActions = Convert.ToInt16(reader.ReadString());

                    reader.ReadToNextSibling("buys");
                    cardBuys = Convert.ToInt16(reader.ReadString());

                    reader.ReadToNextSibling("cards");
                    cardCards = Convert.ToInt16(reader.ReadString());

                    reader.ReadToNextSibling("victoryP");
                    cardVictoryP = Convert.ToInt16(reader.ReadString());

                    reader.ReadToNextSibling("name");
                    cardName = reader.ReadString();

                    reader.ReadToNextSibling("cost");
                    cardCost = Convert.ToInt16(reader.ReadString());

                    reader.ReadToNextSibling("type");
                    cardType = reader.ReadString();

                    reader.ReadToNextSibling("image");
                    cardImage = reader.ReadString();

                    Card newCard = new Card(cardCoins, cardActions, cardBuys, cardCards, cardVictoryP, cardName, cardCost, cardType, cardImage);

                    allCards.Add(newCard);
                }
            }

            //Loads rectangles for card display
            XmlReader reader2 = XmlReader.Create("Resources/cardRectangles.xml");

            while (reader2.Read())
            {
                if (reader2.NodeType == XmlNodeType.Text)
                {
                    recX = Convert.ToInt32(reader2.ReadString());

                    reader2.ReadToNextSibling("y");
                    recY = Convert.ToInt32(reader2.ReadString());

                    reader2.ReadToNextSibling("width");
                    recWidth = Convert.ToInt32(reader2.ReadString());

                    reader2.ReadToNextSibling("height");
                    recHeight = Convert.ToInt32(reader2.ReadString());

                    reader2.ReadToNextSibling("name");
                    recName = reader2.ReadString();

                    Rectangle cardRec = new Rectangle(recX, recY, recWidth, recHeight);

                    cardRectangles.Add(cardRec);
                }
            }

            //Decides cards in current round
            for (int i = 0; i < 8; i++)
            {
                decideCards = new Random().Next(0, allCards.Count);
                roundCards.Add(allCards[decideCards]);
                allCards.Remove(allCards[decideCards]);
            }

            //Adds deafult starting cards in player and CPU hand
            for (int i = 0; i < 6; i++)
            {
                playerHand.Add(coins1);
                computerhand.Add(coins1);
            }
            for (int i = 0; i < 4; i++)
            {
                playerHand.Add(victory1);
                computerhand.Add(victory1);
            }
        }
    }
}
