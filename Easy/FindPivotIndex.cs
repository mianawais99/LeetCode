public class Solution {
    public int PivotIndex(int[] nums) {
        if (nums == null || nums.Length == 0) return -1;

        // Calculate the total sum of the array
        int totalSum = 0;
        for (int i = 0; i < nums.Length; i++) {
            totalSum += nums[i];
        }

        // Initialize left sum
        int leftSum = 0;

        // Iterate through the array and check for pivot index
        for (int i = 0; i < nums.Length; i++) {
            // rightSum for index i is totalSum - leftSum - nums[i]
            int rightSum = totalSum - leftSum - nums[i];
            
            // Check if left sum equals right sum
            if (leftSum == rightSum) {
                return i;
            }
            
            // Update left sum
            leftSum += nums[i];
        }

        // Return -1 if no pivot index is found
        return -1;
    }
}
