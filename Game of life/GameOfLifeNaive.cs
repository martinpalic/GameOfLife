using System;
using System.ComponentModel;

namespace GOLConsole
{
    //Naive implementation of GOL
    //usage of arrays doesnt suffice the input size needs
    public class GameOfLifeNaive : IGameOfLife
    {
        public int Size { get; set; }
        public bool[,] ActualGeneration;
        public bool[,] FutureGeneration;

        public bool[,] GetActualGeneration()
        {
            return this.ActualGeneration;
        }

        public bool[,] NewGame(int size, bool[,] initConfig)
        {
            if (initConfig.GetLength(0) != size || initConfig.GetLength(1) != size)
            {
                throw new ArgumentException("Size of field is not uniform in both dimensions or Size does not match the field size");
            }

            this.ActualGeneration = initConfig;
            FutureGeneration = new bool[size,size];
            this.Size = size;

            return this.ActualGeneration;
        }

        public bool[,] GetNextGeneration()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    AgeOneCell(i, j);
                }
            }

            ActualGeneration = FutureGeneration;
            return ActualGeneration;
        }

        private void AgeOneCell(int i, int j)
        {
            int liveNeighbours = 0;

            int lowerX = i > 0 ? i - 1 : 0;
            int lowerY = j > 0 ? j - 1 : 0;
            int upperX = i < Size - 1 ? i + 1 : Size - 1;
            int upperY = j < Size - 1 ? j + 1 : Size - 1;

            for (int k = lowerX; k < upperX+1; k++)
            {
                for (int l = lowerY; l < upperY+1; l++)
                {
                    if(k==i && l==j) continue;
                    if (ActualGeneration[k, l]) liveNeighbours++;
                }
            }

            if (ActualGeneration[i, j])
            {
                if (liveNeighbours == 2 || liveNeighbours == 3)
                {
                    return;
                }
                FutureGeneration[i, j] = false;
                return;
            }
            else
            {
                if (liveNeighbours == 3) FutureGeneration[i, j] = true;
                return;
            }

        }
    }
}