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
                var rand = new Random();

                game.NewGame(size);

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        game.SetPosition(i,j,rand.Next(100) > 75);
                    }
                }

                OutputField(size, game);

                while (true)
                {
                    Console.WriteLine("Press Enter To Next Generation");
                    Console.ReadLine();
                    game.GetNextGeneration();
                    OutputField(size, game);
                }
            }
        }

        private static void OutputField(int size, IGameOfLife game)
        {
            string line;
            for (int i = 0; i < size; i++)
            {
                line = "";
                for (int j = 0; j < size; j++)
                {
                    line = line + (game.GetActualGeneration(i,j) ? "X" : "_");
                }
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }
    }
}
