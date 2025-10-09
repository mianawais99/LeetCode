public class Solution {
    public long MinTime(int[] skill, int[] mana) {
        int n = skill.Length, m = mana.Length;
        long[] prefCurr = new long[n];

        prefCurr[0] = (long)skill[0] * mana[0];
        for (int i = 1; i < n; i++) prefCurr[i] = prefCurr[i - 1] + (long)skill[i] * mana[0];

        long start = 0L; 

        for (int j = 0; j + 1 < m; j++) {
            long[] prefNext = new long[n];
            prefNext[0] = (long)skill[0] * mana[j + 1];
            for (int i = 1; i < n; i++) prefNext[i] = prefNext[i - 1] + (long)skill[i] * mana[j + 1];

            long maxDiff = long.MinValue;
            for (int i = 0; i < n; i++) {
                long left = prefCurr[i];
                long right = (i == 0 ? 0L : prefNext[i - 1]);
                long diff = left - right;
                if (diff > maxDiff) maxDiff = diff;
            }

            start += maxDiff;     
            prefCurr = prefNext;  
        }

        
        return start + prefCurr[n - 1];
    }
}
