using Checkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.Model;

namespace Checkers.View
{
    class TypeMenu
    {
        public List<Player> Type()
        {
            List<Player> types = new List<Player>();
            int p = PromptInt("Please chose a game mode\n 1:Player vs Player\n 2:Player vs Ai\n 3:Ai vs Ai", 3, 1);
            types = ConvertToGameTypes(p);
            return types;
        }
        public int PromptInt(string prompt, int max, int min)
        {
            int t = 0;
            bool valid = false;
            while (valid)
            {
                Console.WriteLine(prompt);
                string pos = Console.ReadLine();
                if (int.TryParse(pos, out t))
                {
                    if (t > max || t < min)
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("INVALID INPUT OUT OF RANGE");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("INVALID INPUT ENTER A VALID NUM");
                }
            }
            return t;
        }
        public List<Player> ConvertToGameTypes(int num)
        {
            List<Player> p = new List<Player>();
            switch (num)
            {
                case 1:
                    p = new List<Player>{ new HumanPlayer(), new HumanPlayer() };
                    break;
                case 2:
                    p = new List<Player>{ new HumanPlayer(), new AIPlayer() };
                    break;
                case 3:
                    p = new List<Player>{ new AIPlayer(), new AIPlayer() };
                    break;
                default:
                    Console.WriteLine("ERROR OUT OF GAME TYPE RANGE");
                    break;
            }
            return p;
        }

    }

}
