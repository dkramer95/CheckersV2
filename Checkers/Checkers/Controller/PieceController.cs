using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Model;

namespace Checkers.Controller
{
    class PieceController
    {
        public List<Move> PossibleMoves { get; set; }

        public bool KingPiece(Piece piece)
        {
            if (!piece.IsKing)
            {
                piece.IsKing = true;
                return true;
            }
            return false;
        }

        public List<Piece> GetPiecesThatCanMove()
        {
            return null;
        }
    }
}
