public class Solution {
    public int[] RelativeSortArray(int[] arr1, int[] arr2) {
        // Create a dictionary to map the value in arr2 to its order
        Dictionary<int, int> orderMap = new Dictionary<int, int>();
        for (int i = 0; i < arr2.Length; i++) {
            orderMap[arr2[i]] = i;
        }

        // Custom comparer to sort arr1
        Array.Sort(arr1, (x, y) => {
            // Check if both elements are in arr2
            if (orderMap.ContainsKey(x) && orderMap.ContainsKey(y)) {
                return orderMap[x] - orderMap[y];
            }
            // If only x is in arr2
            if (orderMap.ContainsKey(x)) {
                return -1;
            }
            // If only y is in arr2
            if (orderMap.ContainsKey(y)) {
                return 1;
            }
            // If neither x nor y are in arr2, sort them naturally
            return x - y;
        });

        return arr1;
    }
}

/* Shorter version of the same logic

public class Solution {
    // Time O(Max(nlogn,m)) | Space O(m), n, m = length of arr1 and arr2 respectively
    public int[] RelativeSortArray(int[] arr1, int[] arr2) {
        Dictionary<int,int> numPriority = [];
        for(int i=0;i<arr2.Length;i++)  // O(m)
            numPriority[arr2[i]]=i;
        // sort the first array // O(nlogn)
        Array.Sort(arr1, (a,b) => numPriority.TryGetValue(a, out int p1) && numPriority.TryGetValue(b, out int p2) ? p1.CompareTo(p2) : (numPriority.ContainsKey(a) ? -1 : (numPriority.ContainsKey(b) ? 1 : (a.CompareTo(b)))));
        return arr1;
    }
}

*/