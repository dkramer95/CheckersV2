using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Controller
{
    class Game
    {
        List<Player> players;
        public void Start()
        {
            TypeMenu types = new TypeMenu();
            players = types.Type();
            GamePlay();
        }
        private void GamePlay()
        {
            int pturn = 0;
            bool win = false;
            while (win)
            {
                Move m = players[pturn].GetMove();
                if (pturn > players.Count)
                {
                    pturn++;
                }
                else
                {
                    pturn = 0;
                }
            }
        }
    }
}
