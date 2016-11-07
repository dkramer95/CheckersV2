using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Model
{
    public class Position
    {
        public char Column { get; set; }
        public int Row { get; set; }

        public Position(char column, int row)
        {
            this.Column = column;
            this.Row = row;
        }

        public override bool Equals(object obj)
        {
            Position other = obj as Position;
            bool isEqual = (Column == other.Column) && (Row == other.Row);
            return isEqual;
        }
    }
}
