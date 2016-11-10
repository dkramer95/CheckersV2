using Checkers.Controller;
using Checkers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGUI
{
    /// <summary>
    /// GUI implementation for managing a Checkers Game
    /// </summary>
    public class GUIGame : Game
    {
        public GUIGame()
        {
            Init();
        }

        public void Start()
        {
            // TODO:: MENU SELECTION HERE, FOR CREATING PLAYER TYPES

            players = new List<Player>() { new HumanPlayer(), new HumanPlayer() };
            players[0].PiecesColor = Color.Black;
            players[1].PiecesColor = Color.Red;

            Board.Reset();
            Board.Populate(players[0].Pieces, players[1].Pieces);

            Player winner = GamePlay();
        }
    }
}
