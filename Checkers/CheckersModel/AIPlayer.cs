using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersModel
{
    public class AIPlayer : Player
    {
        Random rnd = new Random();
        public override Move GetMove(IEnumerable<Move> moves)
        {
            throw new NotImplementedException();
        }

    }
}
