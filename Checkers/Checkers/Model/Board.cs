using Checkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersModel
{
    /// <summary>
    /// This class represents a Checkers board which is made up of an
    /// 8 x 8 Grid of Squares. This class is static, as we should only
    /// ever need a single instance, and it makes it convenient to access
    /// elsewhere.
    /// </summary>
    public static class Board
    {
        // Horizontal Boundaries { A - H }
        public static readonly char MIN_COL = 'A';
        public static readonly char MAX_COL = 'H';

        // Vertical Boundaries { 1 - 8 }
        public static readonly int MIN_ROW = 1;
        public static readonly int MAX_ROW = 8;

        // 8 x 8 Grid of Squares
        private static IDictionary<Position, Square> _gridSquares;


        public static Square SquareAt(char col, int row)
        {
            Position pos = new Position(col, row);
            Square square = _gridSquares[pos];
            return square;
        }

        public static void Reset()
        {
            _gridSquares = new Dictionary<Position, Square>();

            // Create all the individual squares
            for (char col = MIN_COL; col <= MAX_COL; ++col)
            {
                for (int row = MAX_ROW; row >= MIN_ROW; --row)
                {
                    Position pos = new Position(col, row);
                    Square square = new Square();
                    AddSquare(pos, square);
                }
            }

            // Populate with pieces in their initial starting layout.
            Populate();
            throw new NotImplementedException();
        }

        private static void AddSquare(Position pos, Square square)
        {
            _gridSquares.Add(pos, square);
        }

        public static void Populate(List<Piece> darkPieces, List<Piece> lightPieces)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Populates the board using the specified set of pieces, as well as the
        /// initial starting location.
        /// </summary>
        /// <param name="pieceSet">Set of pieces to add to squares</param>
        /// <param name="startCol">Starting horizontal location</param>
        /// <param name="startRow">Starting vertical location</param>
        private static void PopulateWithPieces(List<Piece> pieceSet, char startCol, int startRow)
        {
        }

        public static string ToString()
        {
            StringBuilder sb = new StringBuilder();

            // go through each row, top to bottom
            for (int row = MAX_ROW; row >= MIN_ROW; --row)
            {
                sb.Append(row + " ");
                
                // go through each col left to right 
                for (char col = MIN_COL; col <= MAX_COL; ++col)
                {
                    Position pos = new Position(col, row);
                    Square square = SquareAt(pos);

                    // print piece if exists, otherwise empty space
                    string squareStr = square.HasPiece() ? "[" + square.Piece + "]" : "[ ]";
                    sb.Append(squareStr);
                }
                sb.Append("\n");
            }
            // Horizontal label
            sb.Append(GetColLabels().PadLeft(3));
            return sb.ToString();
        }

        /// <summary>
        /// Returns string of column (horizontal) labels
        /// </summary>
        /// <returns></returns>
        private static string GetColLabels()
        {
            string colLabel = "";

            for (char col = MIN_COL; col <= MAX_COL; ++col)
            {
                colLabel += col + " ";
            }
            return colLabel;
        }
    }
}
