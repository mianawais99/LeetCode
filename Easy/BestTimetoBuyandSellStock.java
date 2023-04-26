class Solution {
    public int maxProfit(int[] prices) {

        int l = 0 , r = 1;
        int maxp = 0;
        int profit = 0;
        while (r < prices.length){
            if(prices[l] < prices[r]){
                profit = prices[r] - prices[l];
                maxp = Math.max(maxp,profit);
            }
            else{
                l = r;
            }
            r++;
        }
        return maxp;
        
    }
}