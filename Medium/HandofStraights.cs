public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        int len = hand.Length;
        int tempgroup = len%groupSize;

        if(tempgroup == 0){
            return true;
        } else {
            return false;
        }
        
    }
}