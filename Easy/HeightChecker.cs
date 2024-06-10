public class Solution {
    public int HeightChecker(int[] heights) {
        int[] expected = new int[heights.Length];

        Array.Copy(heights, expected, heights.Length);
        Array.Sort(expected);

        int count = 0;
        int index = 0;

        foreach (int height in heights){
            if(height != expected[index]){
                count++;
            }
            index++;
        }
        
        return count;
    }
}