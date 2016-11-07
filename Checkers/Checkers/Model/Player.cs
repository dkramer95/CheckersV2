using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Model
{
    public abstract class Player
    {
        public Color PiecesColor { get; set; }

        public List<Piece> Pieces { get; set; }

        public abstract Move GetMove(List<Move> moves);


    }
}
