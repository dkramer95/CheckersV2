using Checkers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Model;

namespace Checkers.View
{
    public class ConsoleIO
    {
        public string Prompt()
        {
            Console.WriteLine(Board.ToString());
            Console.WriteLine("Please enter postions in the following format l=leter n=whole number ln");
            string startpos = Postion("Please enter postion you want to move");
            string endpos = Postion("Please enter postion you want to move to");
            string s = startpos +","+ endpos;
            return s;
        }
        public Move SelectMoveFromList(IEnumerable<Move> moves)
        {
            for (int j = 0; j < moves.Count(); ++j)
            {
                Console.WriteLine((j + 1) + ": " + moves.ElementAt(j).ToString());
            }
            int moveNum = PromptForInt("Enter the number of the move you want to make", 1, moves.Count());
            Move move = moves.ElementAt(moveNum - 1);
            return move;
        }
        public string Postion(string s)
        {
            string p = "";
            bool valid = false;
            while (!valid)
            {
                Console.WriteLine(s);
                string pos = Console.ReadLine();
                if (pos.Length != 2)
                {
                    Console.WriteLine("INVALID INPUT NOT RIGHT LENGTH");
                }
                else
                {
                    if (CheckLetter(pos[0]) && CheckInt(pos[1]))
                    {
                        p = pos;
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("INVALID INPUT USE STYLE LETERNUM ");
                    }
                }
            }
            return p;
        }
        private bool CheckLetter(char l)
        {
            bool valid = false;
            if (char.ToUpper(l) > 64 || char.ToUpper(l) < 91)
            {
                valid = true;
            }
            return valid;
        }
        private bool CheckInt(char i)
        {
            int o;
            bool b = int.TryParse(i.ToString(), out o);
            return b;
        }
        private int PromptForInt(string message, int min, int max)
        {
            bool isValid = false;
            int result = 0;

            while (!isValid)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out result) && result >= min && result <= max;

                if (!isValid)
                {
                    Console.WriteLine("You must enter a valid integer value between " + min + " and " + max);
                }
            }
            return result;
        }
    }
}
