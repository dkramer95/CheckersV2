using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.View;
using Checkers.Model;
namespace Checkers.Controller
{
    class ViewControler
    {
        public Move validate(IEnumerable<Move> PossibleMoves)
        {
            bool valid = false;
            ConsoleIO view = new ConsoleIO();
            Move realmove = new Move(null,null,null,null);
            while(!valid){
                String move=view.Prompt();
                String[] moves = move.Split(',');
                    foreach (Move m in PossibleMoves)
                {
                    if (m.StartPosition.Column==Char.ToUpper(moves[0][0])&& m.StartPosition.Row == int.Parse(moves[0][1].ToString())&&
                    m.EndPosition.Column==Char.ToUpper(moves[1][0])&& m.EndPosition.Row == int.Parse(moves[1][1].ToString()))
                    {
                        realmove = m;
                        valid = true;
                    }
                }
                if (!valid)
                {
                    Console.WriteLine("INVALID MOVE");
                }
                    
            }
            return realmove;
        }
    }
}
