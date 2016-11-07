using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Checkers.Model
{
    public class Piece
    {
        public Color Color { get; set; }
        public char AsciiValue { get; set; }
        public bool IsKing { get; set; }
        public int MyProperty { get; set; }
        public BitmapImage Image { get; set; }

        public static Piece CreatePiece()
        {
            return new Piece();
        }
        public static Piece CreatePiece(Color color)
        {
            Piece piece = CreatePiece();
            piece.Color = color;
            piece.AsciiValue = color.ToString()[0];
            return piece;
        }

        public static Piece CreatePiece(Color color, char asciiValue)
        {
            Piece piece = CreatePiece(color);
            piece.AsciiValue = asciiValue;
            return piece;
        }

    }
}
