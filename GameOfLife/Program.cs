using System;
using System.IO;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var gb = new Gameboard();
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            var currentTime = DateTime.Now.ToString("dd-MM-yy_HH-mm-ss");
            bool isRandom = true;
            if (isRandom)
                gb.CreateData(10, 10, 0.42);
            else
                gb.ReadData(path + @"\Test.txt");
            var game = new Game(gb);
            game.Start(path + @"\" + currentTime + "_result.txt");
            Console.ReadKey();
        }
    }
}
