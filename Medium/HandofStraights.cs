public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        // Check if the total number of cards is divisible by groupSize
        if (hand.Length % groupSize != 0) {
            return false;
        }

        // Sort the hand array
        Array.Sort(hand);

        // Dictionary to count frequencies of each card value
        Dictionary<int, int> cardCount = new Dictionary<int, int>();
        foreach (int card in hand) {
            if (cardCount.ContainsKey(card)) {
                cardCount[card]++;
            } else {
                cardCount[card] = 1;
            }
        }

        // Iterate through the sorted hand
        foreach (int card in hand) {
            if (cardCount[card] == 0) {
                continue; // This card has already been used in a group
            }

            // Try to form a group starting from 'card' to 'card + groupSize - 1'
            for (int i = 0; i < groupSize; i++) {
                int currentCard = card + i;
                if (!cardCount.ContainsKey(currentCard) || cardCount[currentCard] == 0) {
                    return false; // Group cannot be formed
                }
                // Decrease the count of the current card
                cardCount[currentCard]--;
            }
        }

        // All cards have been successfully grouped
        return true;
    }
}