namespace GOLConsole
{
    public interface IGameOfLife
    {
        /// <summary>
        /// Start New Game of Life
        /// </summary>
        /// <param name="size">Size of square game field</param>
        /// <param name="initConfig">initial configuration of game, true == life present</param>
        /// <returns>Configuration of initial generation</returns>
        bool[,] NewGame(int size, bool[,] initConfig);

        /// <summary>
        /// Get next generation for actual game, this generation becomes actual one
        /// </summary>
        /// <returns>Configuration of new generation</returns>
        bool[,] GetNextGeneration();

        /// <summary>
        /// gets current generation for actual game, no modifications are done
        /// </summary>
        /// <returns>Actual game Configuration</returns>
        bool[,] GetActualGeneration();
    }
}