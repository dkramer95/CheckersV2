using Checkers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGUI
{
    /// <summary>
    /// Player that will handle interactions with the GUI Checkers game.
    /// </summary>
    public class GUIHumanPlayer : Player
    {
        public override Move GetMove(List<Move> moves)
        {
            Square startSquare = GameController.ViewController.StartSquare.DataContext as Square;
            Square endSquare = GameController.ViewController.EndSquare.DataContext as Square;

            Move move = GameController.CheckMove(startSquare, endSquare);

            return move;
        }

        public override void TakeTurn() { }
    }
}
