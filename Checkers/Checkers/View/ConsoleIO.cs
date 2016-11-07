using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.View
{
    class ConsoleIO
    {
        public string Prompt()
        {
            Console.WriteLine("Please enter postions in the following format l=leter n=whole number ln");
            string startpos = Postion("Please enter postion you want to move");
            string endpos = Postion("Please enter postion you want to move to");
            string s = startpos + endpos;
            return s;
        }
        public string Postion(string s)
        {
            string p = "";
            bool valid = false;
            while (valid)
            {
                Console.WriteLine(s);
                string pos = Console.ReadLine();
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
            return false;
        }
    }
}
