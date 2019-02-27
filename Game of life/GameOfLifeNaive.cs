using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GOLConsole
{
    //Naive implementation of GOL
    public class GameOfLifeNaive : IGameOfLife
    {
        public int Size { get; set; }
        public IList<IList<bool>> ActualGeneration;
        public IList<IList<bool>> FutureGeneration;

        public void NewGame(int size)
        {
            this.ActualGeneration = new List<IList<bool>>();
            this.FutureGeneration = new List<IList<bool>>();
            this.Size = size;
            for (int i = 0; i < size; i++)
            {
                this.ActualGeneration.Add(new List<bool>()); 
                this.FutureGeneration.Add(new List<bool>());
                for (int j = 0; j < size; j++)
                {
                    ActualGeneration[i].Add(false);
                    FutureGeneration[i].Add(false);
                }
            }

        }

        public void SetPosition(int x, int y, bool alive)
        {
            ActualGeneration[x][y] = alive;
        }

        public void GetNextGeneration()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    AgeCell(i,  j);
                }
            }

            var tmp = ActualGeneration;
            ActualGeneration = FutureGeneration;
            FutureGeneration = tmp;
        }

        private void AgeCell(int x, int y)
        {
            int liveNeighbors = 0;

            int lowX = x > 0 ? x - 1 : x;
            int lowY = y > 0 ? y - 1 : y;
            int uppX = x < Size - 1 ? x + 1 : Size - 1;
            int uppY = y < Size - 1 ? y + 1 : Size - 1;

            for (int i = lowX; i < uppX+1; i++)
            {
                for (int j = lowY; j < uppY +1; j++)
                {
                    if (i != x && j != y && ActualGeneration[i][j])
                    {
                        liveNeighbors++;
                    }
                }
            }

            FutureGeneration[x][y] = applyRules(ActualGeneration[x][y], liveNeighbors);
        }

        private bool applyRules(bool alive, int liveNeighbours)
        {
            if (alive)
            {
                if (liveNeighbours == 2 || liveNeighbours == 3) return true;
                return false;
            }
            else
            {
                if (liveNeighbours == 3) return true;
                return false;
            }
        }

        public bool GetActualGeneration(int x, int y)
        {
            return ActualGeneration[x][y];
        }
    }
}