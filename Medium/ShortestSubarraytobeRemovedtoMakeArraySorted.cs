public class Solution {
    public int FindLengthOfShortestSubarray(int[] arr) {
        int n = arr.Length;

        // Find the longest non-decreasing prefix
        int left = 0;
        while (left < n - 1 && arr[left] <= arr[left + 1]) {
            left++;
        }

        // If the entire array is already non-decreasing
        if (left == n - 1) return 0;

        // Find the longest non-decreasing suffix
        int right = n - 1;
        while (right > 0 && arr[right - 1] <= arr[right]) {
            right--;
        }

        // Initialize the result as the minimum of removing prefix or suffix
        int result = Math.Min(n - left - 1, right);

        // Try to merge the prefix and suffix
        int i = 0, j = right;
        while (i <= left && j < n) {
            if (arr[i] <= arr[j]) {
                result = Math.Min(result, j - i - 1);
                i++;
            } else {
                j++;
            }
        }

        return result;
    }
}
