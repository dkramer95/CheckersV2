using Checkers.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Controller;

namespace Checkers.Model
{
    public class HumanPlayer : Player
    {
        public override Move GetMove(List<Move> moves)
        {
            ViewControler v = new ViewControler();
            Move move = v.validate(moves);
            return move;
        }
    }
}
