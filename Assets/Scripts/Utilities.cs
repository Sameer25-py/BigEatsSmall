using System.Collections.Generic;
using System.Linq;

namespace BigEatsSmall
{
    public static class Utilities
    {
        public static (int, int) FlatTo2DIndex(int flatIndex, int rows = 3, int columns = 3)
        {
            return (flatIndex / rows, flatIndex % columns);
        }

        public static int _2DToFlatIndex(int row, int column, int rows = 3, int columns = 3)
        {
            return row * rows + column;
        }

        public static List<int> _2DToFlatIndices(int[][] indices, int rows = 3, int columns = 3)
        {
            return indices.ToList().Select(x => _2DToFlatIndex(x[0], x[1])).ToList();
        }
    }
}