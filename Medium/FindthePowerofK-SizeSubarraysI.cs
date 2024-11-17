public class Solution {
    public int[] ResultsArray(int[] nums, int k) {
        int n = nums.Length;
        int[] result = new int[n - k + 1];

        for (int i = 0; i <= n - k; i++) {
            bool isConsecutive = true;
            int maxElement = nums[i];
            
            // Check if the subarray is sorted and consecutive
            for (int j = i; j < i + k - 1; j++) {
                if (nums[j] + 1 != nums[j + 1]) {
                    isConsecutive = false;
                    break;
                }
                maxElement = Math.Max(maxElement, nums[j + 1]);
            }

            result[i] = isConsecutive ? maxElement : -1;
        }

        return result;
    }
}
