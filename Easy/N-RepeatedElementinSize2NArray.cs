public class Solution {
    public int RepeatedNTimes(int[] nums) {
        HashSet<int> UniqueNums = new HashSet<int>();
        int Repeated = 0;
        foreach(int num in nums){
            if(!UniqueNums.Add(num)){
                Repeated = num;
            }
        }
        return Repeated;  
    }
}