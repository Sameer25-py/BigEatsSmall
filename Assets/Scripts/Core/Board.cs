namespace BigEatsSmall.Core
{
    public class Board
    {
        private const int _columns = 3;
        private const int _rows = 3;

        public Board()
        {
            Grid = new int[3][];
            for (var i = 0; i < 3; i++) Grid[i] = new[] { -1, -1, -1 };
        }

        public int[][] Grid { get; }

        public void ResetGrid()
        {
            for (var i = 0; i < _rows; i++)
            for (var j = 0; j < _columns; j++)
                Grid[i][j] = -1;
        }

        public void MarkGridBox(int row, int column, int playerValue)
        {
            if (IsIndexEmpty(row, column)) Grid[row][column] = playerValue;
        }

        public bool IsIndexEmpty(int row, int column)
        {
            return Grid[row][column] == -1;
        }


        public (bool, (int, int)[]) CheckForWin(int playerValue)
        {
            var tempResult = (false, new (int, int)[3]);
            for (var i = 0; i < 3; i++)
            for (var j = 0; j < 3; j++)
            {
                var val = Grid[i][j];
                if (val != playerValue) continue;
                if (j == 0 && val == Grid[i][j + 1] && val == Grid[i][j + 2])
                {
                    tempResult.Item1 = true;
                    tempResult.Item2 = new[] { (i, j), (i, j + 1), (i, j + 2) };
                }
                else if (i == 0 && val == Grid[i + 1][j] && val == Grid[i + 2][j])
                {
                    tempResult.Item1 = true;
                    tempResult.Item2 = new[] { (i, j), (i + 1, j), (i + 2, j) };
                }
                else if (i == 0 && j == 0 && val == Grid[i + 1][j + 1] && val == Grid[i + 2][j + 2])
                {
                    tempResult.Item1 = true;
                    tempResult.Item2 = new[] { (i, j), (i + 1, j + 1), (i + 2, j + 2) };
                }
                else if (i == 0 && j == 2 && val == Grid[i + 1][j - 1] && val == Grid[i + 2][j - 2])
                {
                    tempResult.Item1 = true;
                    tempResult.Item2 = new[] { (i, j), (i + 1, j - 1), (i + 2, j - 2) };
                }
            }

            return (tempResult.Item1,
                tempResult.Item2);
        }
    }
}