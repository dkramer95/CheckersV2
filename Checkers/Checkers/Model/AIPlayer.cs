using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Model
{
    public class AIPlayer : Player
    {
        Random rnd = new Random();
        public override Move GetMove(List<Move> moves)
        {
            Move randMove = moves.ElementAt(rnd.Next(0, moves.Count()));
            return randMove;
        }

    }
}
