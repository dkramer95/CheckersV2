using Checkers.Controller;
using Checkers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CheckersGUI
{
    /// <summary>
    /// This class will handle controlling the flow of the game
    /// </summary>
    public class GameController
    {
        // Flag to check if the current player has made their move
        public bool CurPlayerMadeMove { get; set; }

        private int curPlayerIndex;
        public List<Player> Players { get; private set; }

        public Player CurPlayer { get; private set; }


        public ViewController ViewController { get; private set; }
        public PieceController PieceController { get; private set; }


        public GameController()
        {
            Init();
        }

        private void Init()
        {
            PieceController = new PieceController();
            InitPlayers();
            InitBoard();
            InitView();
        }

        private void InitPlayers()
        {
            Players = new List<Player>() { new HumanPlayer(), new HumanPlayer() };

            curPlayerIndex = 0;
            CurPlayerMadeMove = false;
        }

        private void InitBoard()
        {
            Board.Reset();
            Board.Populate(Players[0].Pieces, Players[1].Pieces);
        }

        private void InitView()
        {
            ViewController = new ViewController(this);
            ViewController.AddPiecesToView(Board.GridSquares);
        }

        public void StartGame()
        {
            curPlayerIndex = 0;
            CurPlayer = Players[curPlayerIndex];
            PieceController.UpdateMoves(CurPlayer);
        }

        public void CheckMove(Square start, Square end)
        {
            List<Move> possibleMoves = PieceController.PossibleMoves;

            Move move = null;
            bool isValid = false;

            foreach (Move m in possibleMoves)
            {
                if (m.Piece == start.Piece)
                {
                    int endSquareIndex = ViewController.SquareViewIndexFromPosition(m.EndPosition);
                    Square endSquare = 
                    ViewController.BoardView.Squares[endSquareIndex].DataContext as Square;

                    if (endSquare == end)
                    {
                        // check to see if end matches
                        isValid = true;
                        move = m;
                        break;
                    }
                }
            }

            if (isValid)
            {
                MakeMove(move);
                if (!CheckWin())
                {
                    CurPlayer = NextPlayer();
                    UpdateView();
                    PieceController.UpdateMoves(CurPlayer);
                } else
                {
                    // we won the game
                }
            } else
            {
                // update view controller
                MessageBox.Show("Invalid move!");
                ViewController.ClearSquares();
            }
        }

        private void UpdateView()
        {
            ViewController.UpdateView(Board.GridSquares);
        }

        private bool CheckWin()
        {
            //TODO add win checking here
            return false;
        }

        private void MakeMove(Move m)
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

                PieceController.KingPiece(Board.SquareAt(m.EndPosition.Column, m.EndPosition.Row).Piece);
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


        private Player NextPlayer()
        {
            if(++curPlayerIndex >= Players.Count)
            {
                curPlayerIndex = 0;
            }
            Player curPlayer = Players[curPlayerIndex];
            MessageBox.Show("NEXT PLAYER::" + curPlayer.PiecesColor);
            return curPlayer;
        }

    }
}
