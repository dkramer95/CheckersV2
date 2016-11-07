using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Model;

namespace Checkers.Controller
{
    public class PieceController
    {
        public List<Move> PossibleMoves { get; private set; }

        public PieceController()
        {
            PossibleMoves = new List<Move>();
        }

        public void addMove(Move move)
        {
            PossibleMoves.Add(move);
        }

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
            var temp = PossibleMoves.Where(s => s.CapturedPieces.Count() > 0).ToList();
            foreach (Piece piece in foundPieces)
            {
                if (temp.Where(s => s.Piece == piece).Count() > 0)
                {
                    piecesThatCanJump.Add(piece);
                }
            }
            return piecesThatCanJump;
        }

        public void UpdateMoves(Player p)
        {
            Dictionary<Piece, Position> piecePositions = new Dictionary<Piece, Position>();
            foreach (Piece piece in p.Pieces)
            {
                var keyvalue = Board.GridSquares.Where(s => s.Value.Piece == piece).SingleOrDefault();
                if (!keyvalue.Equals(default(KeyValuePair<Position, Square>)))
                {
                    piecePositions.Add(piece, keyvalue.Key);
                }
            }




            // Default Move thing
        }

        private Dictionary<Piece, Position> GetPiecePositions(Player p)
        {
            Dictionary<Piece, Position> piecePositions = new Dictionary<Piece, Position>();
            foreach (Piece piece in p.Pieces)
            {
                var keyvalue = Board.GridSquares.Where(s => s.Value.Piece == piece).SingleOrDefault();
                if (!keyvalue.Equals(default(KeyValuePair<Position, Square>)))
                {
                    piecePositions.Add(piece, keyvalue.Key);
                }
            }
            return piecePositions;
        }
    }
}
