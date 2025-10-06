public class Solution
{
    public int SwimInWater(int[][] grid)
    {
        int n = grid.Length;
        int[,] directions = new int[,] { {1,0}, {-1,0}, {0,1}, {0,-1} };
        bool[,] visited = new bool[n, n];

        // Min-Heap (priority queue): stores (time, x, y)
        PriorityQueue<(int time, int x, int y), int> pq = new();
        pq.Enqueue((grid[0][0], 0, 0), grid[0][0]);

        while (pq.Count > 0)
        {
            var (time, x, y) = pq.Dequeue();
            if (x == n - 1 && y == n - 1)
                return time; // reached destination

            if (visited[x, y])
                continue;
            visited[x, y] = true;

            for (int i = 0; i < 4; i++)
            {
                int nx = x + directions[i, 0];
                int ny = y + directions[i, 1];

                if (nx >= 0 && ny >= 0 && nx < n && ny < n && !visited[nx, ny])
                {
                    int newTime = Math.Max(time, grid[nx][ny]);
                    pq.Enqueue((newTime, nx, ny), newTime);
                }
            }
        }

        return -1; // should never reach here
    }
}
