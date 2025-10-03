public class Solution {
    public int TrapRainWater(int[][] heightMap) {
        if (heightMap == null || heightMap.Length == 0 || heightMap[0].Length == 0)
            return 0;

        int m = heightMap.Length, n = heightMap[0].Length;
        bool[,] visited = new bool[m, n];

        // Min-Heap (priority queue) stores (height, x, y)
        PriorityQueue<(int h, int x, int y), int> pq = new();

        // Push boundary cells into heap
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (i == 0 || j == 0 || i == m - 1 || j == n - 1) {
                    pq.Enqueue((heightMap[i][j], i, j), heightMap[i][j]);
                    visited[i, j] = true;
                }
            }
        }

        int trappedWater = 0;
        int[][] dirs = new int[][] {
            new int[] {1, 0},
            new int[] {-1, 0},
            new int[] {0, 1},
            new int[] {0, -1}
        };

        while (pq.Count > 0) {
            var cell = pq.Dequeue();
            int h = cell.h, x = cell.x, y = cell.y;

            foreach (var dir in dirs) {
                int nx = x + dir[0], ny = y + dir[1];
                if (nx < 0 || ny < 0 || nx >= m || ny >= n || visited[nx, ny])
                    continue;

                visited[nx, ny] = true;

                // If neighbor is lower, water is trapped
                trappedWater += Math.Max(0, h - heightMap[nx][ny]);

                // Update height to max of current boundary or neighbor’s height
                pq.Enqueue((Math.Max(h, heightMap[nx][ny]), nx, ny), Math.Max(h, heightMap[nx][ny]));
            }
        }

        return trappedWater;
    }
}
