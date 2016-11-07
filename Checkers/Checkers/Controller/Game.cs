using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Model;
using Checkers.View;
using Checkers.Model;

namespace Checkers.Controller
{
    class Game
    {
        List<Player> players;
        public void Start()
        {
            TypeMenu types = new TypeMenu();
            players = types.Type();
            Board.Reset();
            Board.Populate(players[0].Pieces.ToList(), players[1].Pieces.ToList());
            GamePlay();
        }
        private void GamePlay()
        {
            PieceController p = new PieceController();           
            int pturn = 0;
            bool win = false;
            while (!win)
            {
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
            }
        }
        private void MovePiece(Move m)
        {
            Piece p=Board.SquareAt(m.StartPosition.Column, m.StartPosition.Column).Piece;
            Board.SquareAt(m.EndPosition.Column, m.EndPosition.Row).AddPiece(p);
            Board.SquareAt(m.StartPosition.Column, m.StartPosition.Column).RemovePiece();
        }
    }
}
