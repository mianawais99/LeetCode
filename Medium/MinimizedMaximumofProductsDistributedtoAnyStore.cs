
    public int MinimizedMaximum(int n, int[] quantities) {
        int left = 1; // Minimum possible value of maximum products per store
        int right = quantities.Max(); // Maximum possible value of maximum products per store
        int result = right;

        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (CanDistribute(mid, n, quantities)) {
                result = mid; // Update result if it's feasible
                right = mid - 1; // Try for smaller values
            } else {
                left = mid + 1; // Increase the maximum value
            }
        }

        return result;
    }

    private bool CanDistribute(int maxProductsPerStore, int n, int[] quantities) {
        int requiredStores = 0;
        foreach (var quantity in quantities) {
            requiredStores += (quantity + maxProductsPerStore - 1) / maxProductsPerStore; // Ceiling division
            if (requiredStores > n) {
                return false; // Not feasible
            }
        }
        return true;
    }
