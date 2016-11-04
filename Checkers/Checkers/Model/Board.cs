using Checkers;
using Checkers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Model
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

        public static Square SquareAt(Position pos)
        {
            Square square = SquareAt(pos.Column, pos.Row);
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
        }

        private static void AddSquare(Position pos, Square square)
        {
            _gridSquares.Add(pos, square);
        }

        /// <summary>
        /// Populates the board with the pieces
        /// </summary>
        /// <param name="darkPieces">Dark pieces</param>
        /// <param name="lightPieces">Light pieces</param>
        public static void Populate(List<Piece> darkPieces, List<Piece> lightPieces)
        {
            string[] darkPositions = new string[]
            {
                "B8", "D8", "F8", "H8",
                "A7", "C7", "E7", "G7",
                "B6", "D6", "F6", "H6",
            };

            string[] lightPositions = new string[]
            {
                "A3", "C3", "E3", "G3",
                "B2", "D2", "F2", "H2",
                "A1", "C1", "E1", "G1"
            };

            const int PIECE_COUNT = 12;

            for (int j = 0; j < PIECE_COUNT; ++j)
            {
                // dark pieces
                Piece darkPiece = darkPieces[j];
                Position darkPos = PositionFromString(darkPositions[j]);
                SquareAt(darkPos).AddPiece(darkPiece);


                // light pieces
                Piece lightPiece = lightPieces[j];
                Position lightPos = PositionFromString(lightPositions[j]);
                SquareAt(lightPos).AddPiece(lightPiece);
            }
        }

        private static Position PositionFromString(string str)
        {
            char col = str[0];
            int row = str[1];
            Position pos = new Position(col, row);

            return pos;
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
