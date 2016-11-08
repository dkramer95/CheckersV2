using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Model
{
    /// <summary>
    /// This class is used in conjunction with the Undo/RedoStack classes which
    /// allows the player to go back in time to undo their past moves. This 
    /// class maintains a list of positions for every piece, at a specific point
    /// in the game.
    /// </summary>
    public class GameState
    {
        public Dictionary<Position, Piece> PieceLayout { get; private set; }

        // private constructor -- use Export() method for creating instances
        private GameState()
        {
            PieceLayout = new Dictionary<Position, Piece>();
        }

        /// <summary>
        /// Creates a GameState object by passing it a reference
        /// to a Dictionary of squares. For every square that has a piece,
        /// an entry is created into this PieceLayout dictionary of the position
        /// and the piece.
        /// </summary>
        /// <param name="squares">Squares of the board</param>
        /// <returns>GameState</returns>
        public static GameState ExportFromBoardSquares(Dictionary<Position, Square> squares)
        {
            GameState exportedState = new GameState();

            foreach (Position pos in squares.Keys)
            {
                Square square = squares[pos];
                if (square.HasPiece())
                {
                    Piece piece = square.Piece;
                    exportedState.PieceLayout.Add(pos, piece);
                }
            }
            return exportedState;
        }


    }
}
