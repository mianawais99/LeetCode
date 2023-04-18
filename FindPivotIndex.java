class Solution {
    public int pivotIndex(int[] nums) {
        int sum =0;
        for (int ele : nums){
            sum += ele;
        }

        int leftSum = 0;
        for(int i=0; i<nums.length; leftSum+=nums[i++])
        {
            if(leftSum*2== sum-nums[i])
                return i;
        }
        
        return -1;    
    }
}