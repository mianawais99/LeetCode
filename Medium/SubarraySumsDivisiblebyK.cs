public class Solution {
    public int SubarraysDivByK(int[] nums, int k) {
        // Dictionary to store the frequency of remainders
        Dictionary<int, int> remainderCount = new Dictionary<int, int>();
        remainderCount[0] = 1;  // To account for subarrays that start from the beginning
        
        int prefixSum = 0;
        int result = 0;
        
        foreach (int num in nums) {
            prefixSum += num;
            int remainder = prefixSum % k;
            
            // Handle negative remainders to ensure they are positive
            if (remainder < 0) {
                remainder += k;
            }
            
            // Check if this remainder has been seen before
            if (remainderCount.ContainsKey(remainder)) {
                result += remainderCount[remainder];
                remainderCount[remainder]++;
            } else {
                remainderCount[remainder] = 1;
            }
        }
        
        return result;
    }
}
