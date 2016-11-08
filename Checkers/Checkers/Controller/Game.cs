using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Model;
using Checkers.View;

namespace Checkers.Controller
{
    class Game
    {
        private UndoStack undoStack;
        PieceController p = new PieceController();
        List<Player> players;

        public Game()
        {
            Init();
        }

        private void Init()
        {
            undoStack = new UndoStack();
        }

        public void Start()
        {
            TypeMenu types = new TypeMenu();
            players = types.Type();
            Board.Reset();
            Board.Populate(players[0].Pieces, players[1].Pieces);
            // testing
            Console.WriteLine(Board.ToString());
            GamePlay();
        }

        private void ExportState()
        {
            undoStack.Push(GameState.ExportFromBoardSquares(Board.GridSquares));
        }

        private void GamePlay()
        {
            int pturn = 0;
            bool win = false;
            while (!win)
            {
                p.UpdateMoves(players[pturn]);
                List<Move> moves = p.PossibleMoves;
                Move m = players[pturn].GetMove(moves);
                if (pturn > players.Count)
                {
                    pturn++;
                }
                else
                {
                    pturn = 0;
                }
                // TODO:: after every turn export the state of the board
            }
        }
        private void MovePiece(Move m)
        {
            Piece p=Board.SquareAt(m.StartPosition.Column, m.StartPosition.Column).Piece;
            Board.SquareAt(m.EndPosition.Column, m.EndPosition.Row).AddPiece(p);
            Board.SquareAt(m.StartPosition.Column, m.StartPosition.Column).RemovePiece();
            if((m.EndPosition.Row==1&&p.Color==Color.Black)||(m.EndPosition.Row == 8 && p.Color == Color.Red))
            {

                Board.SquareAt(m.EndPosition.Column, m.EndPosition.Row).Piece.IsKing = true;
            }
        }

        private void UndoMove()
        {
            // can't undo if we have nothing to fall back to
            if (undoStack.Size() > 0)
            {
                // clear out the board and just have empty squares
                Board.Reset();

                GameState undoState = undoStack.Pop();

                // for every piece in the state, add place it on the board
                foreach(Position pos in undoState.PieceLayout.Keys)
                {
                    Piece piece = undoState.PieceLayout[pos];
                    Board.SquareAt(pos).AddPiece(piece);
                }
            }
        }
    }
}
