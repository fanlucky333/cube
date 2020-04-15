using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeApp
{
    class CubeUtil
    {

        public static int CalIntersectionVolume(IList<Cube> cubeList)
        {
            if(cubeList == null || cubeList.Count <= 1)
            {
                return 0;
            }
            var leftBottomMaxX = cubeList.Select(x => x.LeftBottom).Select(x => x.X).Max();
            var leftBottomMaxY = cubeList.Select(x => x.LeftBottom).Select(x => x.Y).Max();
            var leftBottomMaxZ = cubeList.Select(x => x.LeftBottom).Select(x => x.Z).Max();

            var rightTopMinX = cubeList.Select(x => x.RightTop).Select(x => x.X).Min();
            var rightTopMinY = cubeList.Select(x => x.RightTop).Select(x => x.Y).Min();
            var rightTopMinZ = cubeList.Select(x => x.RightTop).Select(x => x.Z).Min();

            Console.WriteLine($"max left bottom point is: x {leftBottomMaxX},y {leftBottomMaxY},z {leftBottomMaxZ}");
            Console.WriteLine($"max right top point is: x {rightTopMinX},y {rightTopMinY},z {rightTopMinZ}");

            if (rightTopMinX > leftBottomMaxX && rightTopMinY > leftBottomMaxY && rightTopMinZ > leftBottomMaxZ)
            {
                return (rightTopMinX - leftBottomMaxX) * (rightTopMinY - leftBottomMaxY) * (rightTopMinZ - leftBottomMaxZ);
            }
            return 0;
        }

        public static IList<Cube> GenerateRandomCubes(int count)
        {
            if (count <= 0)
            {
                return null;
            }
            var list = new List<Cube>();
            Cube currentCube;
            for (int i = 1; i <= count; i++)
            {
                currentCube = Cube.GenerateRandomCube(i);
                Console.WriteLine($"generate {i} cube:{currentCube.ToString()}");
                list.Add(currentCube);
            }
            return list;
        }
    }
}
