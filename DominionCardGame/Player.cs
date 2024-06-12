using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionCardGame
{
    public class Player
    {
        public int roundCoins, roundCards, roundActions, roundBuys, TotalVictory, TotalCards;

        public Player(int _roundCoins, int _roundCards, int _roundActions, int _roundBuys, int _TotalVictory, int _TotalCards)
        {
            roundCoins = _roundCoins;
            roundCards = _roundCards;
            roundActions = _roundActions;
            roundBuys = _roundBuys;
            TotalVictory = _TotalVictory;
            TotalCards = _TotalCards;
        }
    } 
}
