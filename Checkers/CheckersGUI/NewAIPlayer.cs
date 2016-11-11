using Checkers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CheckersGUI
{
    public class NewAIPlayer : Player
    {
        Random rnd = new Random();
        public override Move GetMove(List<Move> moves)
        {
            Move randMove = moves.ElementAt(rnd.Next(0, moves.Count()));
            return randMove;
        }

        public override async void TakeTurn()
        {
            await Task.Delay(1000);
            GameController.Update();
        }
    }
}
