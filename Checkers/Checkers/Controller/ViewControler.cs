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
        public void validate(List<Move> PossibleMoves)
        {
            bool valid = false;
            ConsoleIO view = new ConsoleIO();
            while(!valid){
                String move=view.Prompt();
                String[] moves = move.Split(',');
                    foreach (Move m in PossibleMoves)
                {
                    if (m.StartPosition.Column==moves[0][0]&& m.StartPosition.Row == int.Parse(moves[0][1].ToString())&&
                    m.EndPosition.Column==moves[1][0]&& m.EndPosition.Row == int.Parse(moves[1][1].ToString()))
                    {
                        valid = true;
                    }
                }
                if (!valid)
                {
                    Console.WriteLine("INVALID MOVE");
                }
                    
            }
        }
    }
}
