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
            Dictionary<Piece, Position> piecePositions = GetPiecePositions(p);
            foreach (var item in piecePositions)
            {
                List<Move> tempMoves = GetPieceMovementOptions(item.Key, item.Value);
                foreach (var move in tempMoves)
                {
                    PossibleMoves.Add(move);
                }
            }



            // Default Move thing
        }

        private List<Move> GetPieceMovementOptions(Piece key, Position value)
        {
            List<Move> tempMoves = new List<Move>();
            int direction = 1;
            if (key.Color == Color.Red)
            {
                direction = -1;
            }
            Position pos =new Position((char)(Convert.ToInt32(value.Column) + 1), value.Row + direction);

            Square square = Board.SquareAt(pos);
            if (square != null)
            {
                if (square.Piece != null)
                {
                    if (square.Piece.Color != key.Color)
                    {
                        Square square2 = Board.SquareAt(new Position((char)(Convert.ToInt32(value.Column) + 2), value.Row + direction * 2));
                        if (square != null)
                        {
                            if (square.Piece == null)
                            {
                                tempMoves.Add(new Move(key, value, new Position((char)(Convert.ToInt32(value.Column) + 2), value.Row + direction * 2), new List<Piece>()));
                            }
                        }
                    }
                }
                else
                {
                    tempMoves.Add(new Move(key, value, new Position((char)(Convert.ToInt32(value.Column) + 1), value.Row + direction), new List<Piece>()));
                }
            }
            square = Board.SquareAt(new Position((char)(Convert.ToInt32(value.Column) - 1), value.Row + direction));

            if (square != null)
            {
                if (square.Piece != null)
                {
                    if (square.Piece.Color != key.Color)
                    {
                        Square square2 = Board.SquareAt(new Position((char)(Convert.ToInt32(value.Column) - 2), value.Row + direction * 2));
                        if (square != null)
                        {
                            if (square.Piece == null)
                            {
                                tempMoves.Add(new Move(key, value, new Position((char)(Convert.ToInt32(value.Column) - 2), value.Row + direction * 2), new List<Piece>()));
                            }
                        }
                    }
                }
                else
                {
                    tempMoves.Add(new Move(key, value, new Position((char)(Convert.ToInt32(value.Column) - 1), value.Row + direction), new List<Piece>()));
                }
            }
            return tempMoves;
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
