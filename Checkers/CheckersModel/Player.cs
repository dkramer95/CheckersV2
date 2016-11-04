using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public abstract class Player
    {
        public Color PiecesColor { get; set; }

        public Move GetMove(IEnumerable<Move> moves);


    }
}
