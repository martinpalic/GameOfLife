using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter New Game Dimension");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int size))
            {
                IGameOfLife game = new GameOfLifeNaive();
                bool[,] field = new bool[size,size];
                var rand = new Random();
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        field[i, j] = rand.Next(2) != 0;
                    }
                }

                game.NewGame(size, field);
                outputField(size, field);

                while (true)
                {
                    Console.WriteLine("Press Enter To Next Generation");
                    Console.ReadLine();
                    outputField(size, game.GetNextGeneration());
                }
            }
        }

        private static void outputField(int size, bool[,] field)
        {
            string line;
            for (int i = 0; i < size; i++)
            {
                line = "";
                for (int j = 0; j < size; j++)
                {
                    line = line + (field[i, j] ? "X" : "_");
                }
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }
    }
}
