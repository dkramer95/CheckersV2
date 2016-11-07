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

        public List<Piece> GetPiecesThatCanMove(Player p)
        {
            List<Piece> foundPieces = new List<Piece>();
            foreach (Piece piece in p.Pieces)
            {
                if (PossibleMoves.Where(s => s.Piece == piece).Count() > 0)
                {
                    foundPieces.Add(piece);
                }
            }
            return foundPieces;
        }

        public List<Piece> GetPiecesThatCanJump(Player p)
        {
            List<Piece> foundPieces = GetPiecesThatCanMove(p);
            List<Piece> piecesThatCanJump = new List<Piece>();
            foreach (Piece piece in foundPieces)
            {
                if (PossibleMoves.Where(s => s.CapturedPieces.Count() > 0).Count() > 0)
                {
                    piecesThatCanJump.Add(piece);
                }
            }
            return piecesThatCanJump;
        }
    }
}
