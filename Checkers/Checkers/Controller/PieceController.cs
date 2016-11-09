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
            PossibleMoves.Clear();
            Dictionary<Piece, Position> piecePositions = GetPiecePositions(p);
            foreach (var item in piecePositions)
            {
                PossibleMoves.AddRange(GetPieceMovementOptions(item.Key, item.Value));
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

            tempMoves = CheckJumps(key, value, direction);
            tempMoves.AddRange(CheckMoves(key, value, direction));

            
            return tempMoves;
        }

        private List<Move> CheckMoves(Piece piece, Position position, int direction)
        {
            List<Move> tempMoves = new List<Move>();
            Square square = Board.SquareAt(new Position((char)(Convert.ToInt32(position.Column) + 1), position.Row + direction));
            if (square != null)
            {
                if (square.Piece == null)
                {
                    tempMoves.Add(new Move(piece, position, new Position((char)(Convert.ToInt32(position.Column) + 1), position.Row + direction), new List<Piece>()));
                }
            }
            square = Board.SquareAt(new Position((char)(Convert.ToInt32(position.Column) - 1), position.Row + direction));
            if (square != null)
            {
                if (square.Piece == null)
                {
                    tempMoves.Add(new Move(piece, position, new Position((char)(Convert.ToInt32(position.Column) - 1), position.Row + direction), new List<Piece>()));
                }
            }
            return tempMoves;
        }

        private List<Move> CheckJumps(Piece piece, Position position, int direction)
        {
            List<Move> tempMoves = new List<Move>();
            Square square = Board.SquareAt(new Position((char)(Convert.ToInt32(position.Column) - 1), position.Row + direction));

            if (square != null)
            {
                if (square.Piece != null)
                {
                    if (square.Piece.Color != piece.Color)
                    {
                        Square square2 = Board.SquareAt(new Position((char)(Convert.ToInt32(position.Column) - 2), position.Row + direction * 2));
                        if (square2 != null)
                        {
                            if (square2.Piece == null)
                            {
                                tempMoves.Add(new Move(piece, position, new Position((char)(Convert.ToInt32(position.Column) - 2), position.Row + direction * 2), new List<Piece> { square.Piece }));
                            }
                        }
                    }
                }
            }

            square = Board.SquareAt(new Position((char)(Convert.ToInt32(position.Column) + 1), position.Row + direction));

            if (square != null)
            {
                if (square.Piece != null)
                {
                    if (square.Piece.Color != piece.Color)
                    {
                        Square square2 = Board.SquareAt(new Position((char)(Convert.ToInt32(position.Column) + 2), position.Row + direction * 2));
                        if (square2 != null)
                        {
                            if (square2.Piece == null)
                            {
                                tempMoves.Add(new Move(piece, position, new Position((char)(Convert.ToInt32(position.Column) + 2), position.Row + direction * 2), new List<Piece> { square.Piece }));
                            }
                        }
                    }
                }
            }
            //if (tempMoves.Count != 0)
            //{
            //    List<Move> removedMoves = new List<Move>();
            //    foreach (Move move in tempMoves)
            //    {
            //        tempMoves.AddRange(CheckJumps(move.Piece, move.EndPosition, direction));
            //        removedMoves.Add(move);
            //    }
            //}
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
