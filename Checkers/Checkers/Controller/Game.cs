using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Model;
using Checkers.View;

namespace Checkers.Controller
{
    public class Game
    {
        protected UndoStack undoStack;
        protected PieceController pieceController = new PieceController();
        protected List<Player> players;


        public Game()
        {
            Init();
        }

        protected void Init()
        {
            undoStack = new UndoStack();
        }

        public void Start()
        {
            TypeMenu types = new TypeMenu();
            players = types.Type();
            players[0].PiecesColor = Color.Black;
            Board.Reset();
            Board.Populate(players[0].Pieces, players[1].Pieces);
            // testing
            Player winner = GamePlay();
            Console.WriteLine(winner.PiecesColor + " Player Wins");
        }

        protected void ExportState()
        {
            undoStack.Push(GameState.ExportFromBoardSquares(Board.GridSquares));
        }

        protected Player GamePlay()
        {
            int pturn = 0;
            bool win = false;
            while (!win)
            {
                pieceController.UpdateMoves(players[pturn]);
                Console.WriteLine(Board.ToString());
                if (pieceController.PossibleMoves.Count == 0)
                {
                    win = true;
                }
                else {
                    List<Move> moves = new List<Move>();
                    List<Piece> jumps = pieceController.GetPiecesThatCanJump(players[pturn]);
                    if (jumps.Count != 0)
                    {
                        moves = ForceJump(jumps);
                    }
                    else
                    {
                        moves = pieceController.PossibleMoves;
                    }
                    foreach (Move move in pieceController.PossibleMoves)
                    {
                        Console.WriteLine("[" + move.StartPosition.Column + "" + move.StartPosition.Row + "]" + "[" + move.EndPosition.Column + "" + move.EndPosition.Row + "]");
                    }
                    Console.WriteLine(players[pturn].PiecesColor + "'s turn");

                    Move m = players[pturn].GetMove(moves);
                    MovePiece(m);
                }
                if (pturn < players.Count - 1)
                {
                    pturn++;
                }
                else
                {
                    pturn = 0;
                }
                ExportState();
                // TODO:: after every turn export the state of the board

            }
            return players[pturn];
        }
        public List<Move> ForceJump(List<Piece> jumps)
        {
            List<Move> m = new List<Move>();
            foreach (Move s in pieceController.PossibleMoves)
            {
                foreach (Piece c in jumps)
                {
                    if (s.Piece != null)
                    {
                        if (s.Piece == c)
                        {
                            m.Add(s);
                        }
                    }
                }
            }
            return m;
        }
        protected void MovePiece(Move m)
        {
            Piece piece = Board.SquareAt(m.StartPosition.Column, m.StartPosition.Row).Piece;
            Board.SquareAt(m.EndPosition.Column, m.EndPosition.Row).AddPiece(piece);
            Board.SquareAt(m.StartPosition.Column, m.StartPosition.Row).RemovePiece();
            if (m.CapturedPieces.Count > 0)
            {
                RemoveinBoard(m.CapturedPieces);
            }
            if ((m.EndPosition.Row == 8 && piece.Color == Color.Black) || (m.EndPosition.Row == 1 && piece.Color == Color.Red))
            {

                pieceController.KingPiece(Board.SquareAt(m.EndPosition.Column, m.EndPosition.Row).Piece);
            }
        }
        protected void RemoveinBoard(List<Piece> m)
        {
            foreach (KeyValuePair<Position, Square> s in Board.GridSquares)
            {
                foreach (Piece c in m)
                {
                    if (s.Value.Piece != null)
                    {
                        if (s.Value.Piece == c)
                        {
                            Board.SquareAt(s.Key.Column, s.Key.Row).RemovePiece();
                        }
                    }
                }
            }
        }
        protected void UndoMove()
        {
            // can't undo if we have nothing to fall back to
            if (undoStack.Size() > 0)
            {
                // clear out the board and just have empty squares
                Board.Reset();

                GameState undoState = undoStack.Pop();

                // for every piece in the state, add place it on the board
                foreach (Position pos in undoState.PieceLayout.Keys)
                {
                    Piece piece = undoState.PieceLayout[pos];
                    Board.SquareAt(pos).AddPiece(piece);
                }
            }
        }
    }
}
