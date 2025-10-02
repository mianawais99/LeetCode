public class Solution {
    public int MaxBottlesDrunk(int numBottles, int numExchange) {
        int totalDrunk = numBottles;  // initially drink all full bottles
        int empty = numBottles;

        while (empty >= numExchange) {
            empty -= numExchange;   // use empty bottles for exchange
            numExchange++;          // next exchange requires more
            totalDrunk++;           // drink the new bottle
            empty++;                // the new bottle becomes empty
        }

        return totalDrunk;
        
    }
}