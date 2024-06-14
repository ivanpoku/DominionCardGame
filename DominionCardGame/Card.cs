using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DominionCardGame
{
    
    public class Card
    {
        public int coins, actions, buys, cards, victoryP, cost;
        public string name, type;

        public Card(int _coins, int _actions, int _buys, int _cards, int _victoryP, string _name, int _cost, string _type)
        {
            coins = _coins;
            actions = _actions;
            buys = _buys;
            cards = _cards;
            victoryP = _victoryP;
            name = _name;
            cost = _cost;
            type = _type;
        }
    }
}
