using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please click enter key to start cal cube volume,click ese to exit this application.");
            
            var key = Console.ReadKey();

            while(key != null)
            {
                if(key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine($"intersection volume is:{CubeUtil.CalIntersectionVolume(CubeUtil.GenerateRandomCubes(5))}");
                    key = Console.ReadKey();
                }
                if(key.Key == ConsoleKey.Escape)
                {
                    return;
                }
            }
        }
    }
}
