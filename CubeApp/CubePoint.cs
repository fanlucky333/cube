using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeApp
{
    class CubePoint
    {
        public int X { get; }

        public int Y { get; }

        public int Z { get; }

        public CubePoint(int x,int y,int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return $"({this.X},{this.Y},{this.Z})";
        }

        public override int GetHashCode()
        {
            return $"({this.X},{this.Y},{this.Z})".GetHashCode();
        }
    }
}
