public class Solution {
    public int MinCapability(int[] nums, int k) {
        int left = int.MaxValue, right = int.MinValue;

        // Finding the range for binary search
        foreach (int num in nums) {
            left = Math.Min(left, num);
            right = Math.Max(right, num);
        }

        // Binary search for the minimum possible capability
        while (left < right) {
            int mid = left + (right - left) / 2;

            if (CanRobAtLeastK(nums, k, mid)) {
                right = mid; // Try a smaller capability
            } else {
                left = mid + 1; // Increase capability
            }
        }

        return left;
    }

    private bool CanRobAtLeastK(int[] nums, int k, int cap) {
        int count = 0;
        int i = 0;
        while (i < nums.Length) {
            if (nums[i] <= cap) {
                count++;
                i++; // Skip adjacent house
            }
            i++; // Move to next house
        }
        return count >= k;
    }
}
