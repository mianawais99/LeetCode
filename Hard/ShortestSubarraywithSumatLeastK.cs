public class Solution {
    public int ShortestSubarray(int[] nums, int k) {
        int n = nums.Length;
        long[] prefixSum = new long[n + 1];
        for (int i = 0; i < n; i++) {
            prefixSum[i + 1] = prefixSum[i] + nums[i];
        }

        int minLength = n + 1;
        LinkedList<int> deque = new LinkedList<int>();

        for (int i = 0; i <= n; i++) {
            // Check if the current subarray meets the condition
            while (deque.Count > 0 && prefixSum[i] - prefixSum[deque.First.Value] >= k) {
                minLength = Math.Min(minLength, i - deque.First.Value);
                deque.RemoveFirst();
            }

            // Maintain deque in increasing order of prefix sums
            while (deque.Count > 0 && prefixSum[i] <= prefixSum[deque.Last.Value]) {
                deque.RemoveLast();
            }

            // Add current index to deque
            deque.AddLast(i);
        }

        return minLength == n + 1 ? -1 : minLength;
    }
}
