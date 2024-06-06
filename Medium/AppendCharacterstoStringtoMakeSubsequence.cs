public class Solution {
    public int AppendCharacters(string s, string t) {
        int sIndex = 0;
        int tIndex = 0;
        
        // Traverse both strings with two pointers
        while (sIndex < s.Length && tIndex < t.Length) {
            if (s[sIndex] == t[tIndex]) {
                tIndex++; // If characters match, move t's pointer
            }
            sIndex++; 
        }
        return t.Length - tIndex;
    }
}
