public class Solution {
    public int MinIncrementForUnique(int[] nums) {
        // Step 1: Sort the array
        Array.Sort(nums);
        
        int moves = 0;  // to keep track of the number of moves required
        for (int i = 1; i < nums.Length; i++) {
            // If the current number is not greater than the previous number
            if (nums[i] <= nums[i - 1]) {
                // Calculate the increment needed
                int increment = nums[i - 1] - nums[i] + 1;
                // Increment the current number
                nums[i] += increment;
                // Add the increment to the total moves
                moves += increment;
            }
        }
        
        return moves;
    }
}
