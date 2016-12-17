using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Cell
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public bool IsAlive { get; set; }

        public Cell(int x = -1, int y = -1, bool isAlive = false)
        {
            this.XPosition = x;
            this.YPosition = y;
            this.IsAlive = isAlive;
        }

        public override string ToString()
        {
            return this.IsAlive ? "*" : " ";
        }

        public override int GetHashCode()
        {
            return this.XPosition.GetHashCode() ^ this.YPosition.GetHashCode() ^ this.IsAlive.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Cell c = obj as Cell;
            if (c == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (this.XPosition == c.XPosition) && (this.YPosition == c.YPosition) && (this.IsAlive == c.IsAlive);
        }
    }
}
