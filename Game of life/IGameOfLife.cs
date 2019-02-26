namespace GOLConsole
{
    public interface IGameOfLife
    {
        /// <summary>
        /// Start New Game of Life
        /// </summary>
        /// <param name="size">Size of square game field</param>
        /// <param name="initConfig">initial configuration of game, true == life present</param>
        void NewGame(int size);

        /// <summary>
        /// set cell on position to live or dead
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="alive"></param>
        void SetPosition(int x, int y, bool alive);

        /// <summary>
        /// Get next generation for actual game, this generation becomes actual one
        /// </summary>
        void GetNextGeneration();

        /// <summary>
        /// gets current generation for actual game, no modifications are done
        /// </summary>
        /// <returns>Actual game Configuration at given point</returns>
        bool GetActualGeneration(int x, int y);
    }
}