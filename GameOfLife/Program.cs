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
            Console.WriteLine("Press \"r\", if you want to create random start gameboard.");
            Console.WriteLine("In other case it will be taken from \"Test.txt\"");
            var isRandom = Console.Read();
            if (isRandom == 'r')
                gb.CreateData(10, 10, 0.5);
            else
                gb.ReadData(path + @"\Test.txt");
            var game = new Game(gb);
            game.Start(path + @"\" + currentTime + "_result.txt");
            Console.ReadKey();
        }
    }
}
