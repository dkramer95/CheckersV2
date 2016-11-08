using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Model
{
    /// <summary>
    /// Simple class that allows us to preserve a GameState. Simply
    /// push onto the Stack a GameState object to add, and pop to
    /// return and remove the last GameState object.
    /// </summary>
    public class UndoStack
    {
        private Stack<GameState> _states;

        public UndoStack()
        {
            _states = new Stack<GameState>();
        }

        public void Push(GameState state)
        {
            _states.Push(state);
        }

        public GameState Pop()
        {
            GameState state = _states.Pop();
            return state;
        }

        public int Size()
        {
            int size = _states.Count;
            return size;
        }
    }
}
