using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeApp
{
    class Cube
    {
        public const int MIN_VALUE = 0;
        private const int MAX_VALUE = 100;

        /// <summary>
        /// pointArray must contain six int numbers,first three numbers express left bottom point x1,y1,z1
        /// last three numbers express right top point x2,y2,z2
        /// last three numbers must greater than pre : x2>x1,y2>y1,z2>z1
        /// </summary>
        /// <param name="pointArray"></param>
        public Cube(int[] pointArray)
        {
            if(pointArray == null || pointArray.Length != 6)
            {
                throw new ArgumentException("argement must contain 6 int numbers.");
            }
            foreach(int val in pointArray)
            {
                if(val < MIN_VALUE || val > MAX_VALUE)
                {
                    throw new ArgumentException($"argument must between {MIN_VALUE} and {MAX_VALUE}.");
                }
            }

            if(pointArray[0] >= pointArray[3]
                || pointArray[1] >= pointArray[4]
                || pointArray[2] >= pointArray[5])
            {
                throw new ArgumentException("first point x or y or z must less than sencond point value.");
            }

            this.LeftBottom = new CubePoint(pointArray[0], pointArray[1], pointArray[2]);
            this.RightTop = new CubePoint(pointArray[3], pointArray[4], pointArray[5]);
        }

        public CubePoint LeftBottom { get; }

        public CubePoint RightTop { get; set; }
        
        public static Cube GenerateRandomCube(int seed)
        {
            Random random = new Random(int.Parse(DateTime.Now.ToString("HHmmssfff")) + seed);
            int x1 = random.Next(MIN_VALUE, MAX_VALUE);
            int y1 = random.Next(MIN_VALUE, MAX_VALUE);
            int z1 = random.Next(MIN_VALUE, MAX_VALUE);

            int x2 = random.Next(MIN_VALUE, MAX_VALUE);
            int y2 = random.Next(MIN_VALUE, MAX_VALUE);
            int z2 = random.Next(MIN_VALUE, MAX_VALUE);
            while (x2 == x1)
            {
                x2 = random.Next(MIN_VALUE, MAX_VALUE);
            }
            while (y2 == y1)
            {
                y2 = random.Next(MIN_VALUE, MAX_VALUE);
            }
            while (z2 == z1)
            {
                z2 = random.Next(MIN_VALUE, MAX_VALUE);
            }

            int[] array = new int[6];
            array[0] = Math.Min(x1, x2);
            array[1] = Math.Min(y1, y2);
            array[2] = Math.Min(z1, z2);

            array[3] = Math.Max(x1, x2);
            array[4] = Math.Max(y1, y2);
            array[5] = Math.Max(z1, z2);

            return new Cube(array);
        }

        public override string ToString()
        {
            return $"leftButtom:{this.LeftBottom.ToString()},rightTop:{this.RightTop.ToString()}";
        }
    }
}
