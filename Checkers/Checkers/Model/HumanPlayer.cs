using Checkers.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Model
{
    public class HumanPlayer : Player
    {
        public override Move GetMove(IEnumerable<Move> moves)
        {
            ConsoleIO io = new ConsoleIO();
            Move move = io.SelectMoveFromList(moves);
            return move;
        }
    }
}
