public class Solution
{
    public bool CanSortArray(int[] nums)
    {
        int prevMax = int.MinValue;
        int currMax = nums[0];
        int currMin = nums[0];
        int setBits = CountBits(nums[0]);

        for (int i = 1; i < nums.Length; i++)
        {
            if (setBits == CountBits(nums[i]))
            {
                currMax = Math.Max(currMax, nums[i]);
                currMin = Math.Min(currMin, nums[i]);
            }
            else
            {
                if (currMin < prevMax)
                    return false;

                prevMax = currMax;
                setBits = CountBits(nums[i]);
                currMin = nums[i];
                currMax = nums[i];
            }
        }

        return currMin > prevMax;
    }

    private int CountBits(int num)
    {
        return Convert.ToString(num, 2).Replace("0", "").Length;
    }
}