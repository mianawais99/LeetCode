public class Solution {
    public int LongestPalindrome(string s) {
        HashSet<char> h = new HashSet<char>();
        int len = 0;
        
        foreach (char e in s.ToCharArray()) {
            if (h.Contains(e)) {
                len += 2;
                h.Remove(e);
            }
            else {
                h.Add(e);
            }
        }

        if (h.Count > 0) {
            return len + 1;
        }
        return len;
    }
}
