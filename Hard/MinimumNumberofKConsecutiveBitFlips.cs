public class Solution {
    public int MinKBitFlips(int[] nums, int k) {
        int n = nums.Length;
        int flips = 0;
        int flipCount = 0;
        int[] isFlipped = new int[n]; // To mark if a flip started at this position

        for (int i = 0; i < n; i++) {
            if (i >= k) {
                flipCount ^= isFlipped[i - k];
            }

            if (nums[i] == flipCount) { // If current element needs flipping
                if (i + k > n) {
                    return -1; // Not enough elements to flip
                }
                flips++;
                flipCount ^= 1; // Toggle flip state
                isFlipped[i] = 1; // Mark the start of a flip
            }
        }

        return flips;
    }
}
