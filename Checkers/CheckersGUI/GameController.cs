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
            TypeMenu t = new TypeMenu();
            t.ShowDialog();
            Players = t.m;
            curPlayerIndex = 0;
            CurPlayerMadeMove = false;
        }

        public void ResetGame()
        {
            InitPlayers();
            InitBoard();
            InitView();
            StartGame();
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
            List<Piece> jumps = PieceController.GetPiecesThatCanJump(CurPlayer);
            if (jumps.Count != 0)
            {
                possibleMoves=ForceJump(jumps);
            }
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
                
                    CurPlayer = NextPlayer();
                    UpdateView();
                    PieceController.UpdateMoves(CurPlayer);
                if (CheckWin())
                {
                    CurPlayer = NextPlayer();
                    MessageBox.Show(CurPlayer.PiecesColor+" Player Wins!");
                }
            } else
            {
                // update view controller
                MessageBox.Show("Invalid move!");
                ViewController.ClearSquares();
            }
        }
        public List<Move> ForceJump(List<Piece> jumps)
        {
            List<Move> m = new List<Move>();
            foreach (Move s in PieceController.PossibleMoves)
            {
                if (s.CapturedPieces.Count > 0)
                {
                    m.Add(s);
                }
            }
            return m;
        }


        private void UpdateView()
        {
            ViewController.UpdateView(Board.GridSquares);
            ViewController.ClearSquares();
        }

        private bool CheckWin()
        {
            bool win = false;
            if (PieceController.PossibleMoves.Count == 0)
            {
                win = true;
            }
            return win;
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
            return curPlayer;
        }

    }
}
