class Solution {
    public int NumWaterBottles(int numBottles, int numExchange) {
        int total = numBottles;   // total bottles you can drink
        int empty = numBottles;   // initially all are empty after drinking

        while (empty >= numExchange) {
            int newBottles = empty / numExchange;   // full bottles obtained
            total += newBottles;                   // drink them
            empty = newBottles + (empty % numExchange); // new empty + leftover
        }
        return total;
    }
}
