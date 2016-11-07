using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Model
{
    /// <summary>
    /// This class represents a single individual square. A square can
    /// hold at most one piece, or it can be empty.
    /// </summary>
    public class Square
    {
        public Piece Piece { get; private set; }


        public bool AddPiece(Piece piece)
        {
            bool didAdd = false;
            if (!HasPiece())
            {
                Piece = piece;
                didAdd = true;
            }
            return didAdd;
        }

        public bool HasPiece()
        {
            bool result = (Piece != null);
            return result;
        }

        public void RemovePiece()
        {
            Piece = null;
        }
    }
}
