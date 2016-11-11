using Checkers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGUI
{
    public abstract class Player : Checkers.Model.Player
    {
        public GameController GameController { get; set; }

        //public Color PiecesColor { get; set; }

        //public List<Piece> Pieces { get; set; }

        //public abstract Move GetMove(List<Move> moves);

        //public void TakeTurn() { }
        public abstract void TakeTurn();

        public Player()
        {
            Pieces = new List<Piece>();
        }
    }
}
