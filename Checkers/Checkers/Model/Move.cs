using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Model
{
    public class Move
    {
        public Piece Piece { get; set; }
        public Position StartPosition { get; set; }
        public Position EndPosition { get; set; }
        public List<Piece> CapturedPieces { get; set; }

        public Move(Piece piece, Position  startPosition, Position endPosition, List<Piece> capturedPieces)
        {
            this.Piece = piece;
            this.StartPosition = startPosition;
            this.EndPosition = endPosition;
            this.CapturedPieces = capturedPieces;
        }

        public override string ToString()
        {
            string s = "Move piece at " + StartPosition + " to " + EndPosition;
            if (CapturedPieces != null)
            {
                s += " and captures " + CapturedPieces.Count() + " piece(s)";                
            }
            return s;
        }

    }
}
