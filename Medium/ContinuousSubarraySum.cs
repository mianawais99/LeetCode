public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        // Dictionary to store the remainder when cumulative sum is divided by k
        Dictionary<int, int> remainderIndexMap = new Dictionary<int, int>();
        remainderIndexMap[0] = -1;  // To handle the case when the subarray starts from index 0
        
        int cumulativeSum = 0;
        
        for (int i = 0; i < nums.Length; i++) {
            cumulativeSum += nums[i];
            int remainder = cumulativeSum % k;
            
            // Handle negative remainders to ensure they are positive
            if (remainder < 0) {
                remainder += k;
            }
            
            if (remainderIndexMap.ContainsKey(remainder)) {
                if (i - remainderIndexMap[remainder] > 1) {
                    return true;
                }
            } else {
                remainderIndexMap[remainder] = i;
            } 
        }
        
        return false;
    }
}
