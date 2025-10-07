public class Solution {
    public int[] AvoidFlood(int[] rains) {
        int n = rains.Length;
        int[] ans = new int[n];
        
        // Map of lake -> last day it was rained on
        Dictionary<int, int> fullLakes = new Dictionary<int, int>();
        // SortedSet of indices (dry days)
        SortedSet<int> dryDays = new SortedSet<int>();

        for (int i = 0; i < n; i++) {
            if (rains[i] == 0) {
                // We can dry any lake on this day
                dryDays.Add(i);
                ans[i] = 1; // default, may change later
            } else {
                int lake = rains[i];
                ans[i] = -1; // raining day
                
                if (fullLakes.ContainsKey(lake)) {
                    // Lake is already full -> need to dry before this rain
                    int lastRainDay = fullLakes[lake];

                    // Find a dry day after lastRainDay
                    int? dryDay = null;
                    foreach (int d in dryDays) {
                        if (d > lastRainDay) {
                            dryDay = d;
                            break;
                        }
                    }

                    if (dryDay == null)
                        return new int[0]; // No day to dry this lake, flood happens

                    ans[dryDay.Value] = lake; // dry this lake
                    dryDays.Remove(dryDay.Value);
                }

                // Update last rain day for this lake
                fullLakes[lake] = i;
            }
        }

        return ans;
    }
}
