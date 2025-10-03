

namespace leetcode
{
    public class TrappingRainWater : DisposableBase
    {
        /// <summary>
        /// trap rain water in a 4D height map
        /// </summary>
        /// <param name="heightMap"></param>
        /// <returns></returns>
        public int TrapRainWater(int[][] heightMap)
        {
            int m = heightMap.Length;
            if (m == 0) return 0;

            int n = heightMap[0].Length;
            if (n == 0) return 0;

            bool[,] visited = new bool[m, n];
            var pq = new PriorityQueue<(int row, int col, int height), int>();


            for (int i = 0; i < m; i++)
            {
                pq.Enqueue((i, 0, heightMap[i][0]), heightMap[i][0]);
                pq.Enqueue((i, n - 1, heightMap[i][n - 1]), heightMap[i][n - 1]);
                visited[i, 0] = true;
                visited[i, n - 1] = true;
            }

            for (int j = 1; j < n - 1; j++)
            {
                pq.Enqueue((0, j, heightMap[0][j]), heightMap[0][j]);
                pq.Enqueue((m - 1, j, heightMap[m - 1][j]), heightMap[m - 1][j]);
                visited[0, j] = true;
                visited[m - 1, j] = true;
            }

            int[,] directions = new int[,] { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };
            int waterTrapped = 0;


            while (pq.Count > 0)
            {
                var (row, col, height) = pq.Dequeue();

                for (int d = 0; d < 4; d++)
                {
                    int newRow = row + directions[d, 0];
                    int newCol = col + directions[d, 1];

                    if (newRow >= 0 && newRow < m && newCol >= 0 && newCol < n && !visited[newRow, newCol])
                    {
                        visited[newRow, newCol] = true;


                        int neighborHeight = heightMap[newRow][newCol];
                        waterTrapped += Math.Max(0, height - neighborHeight);


                        pq.Enqueue((newRow, newCol, Math.Max(height, neighborHeight)), Math.Max(height, neighborHeight));
                    }
                }
            }

            return waterTrapped;
        }
        /// <summary>
        /// despose pattern implementation
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose managed resources
            }
            // No unmanaged resources, so nothing extra here
            // Call base to set _disposed flag
            base.Dispose(disposing);
        }
    }
}
