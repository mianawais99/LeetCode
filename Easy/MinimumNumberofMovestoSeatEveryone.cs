public class Solution {
    public int MinMovesToSeat(int[] seats, int[] students) {
        // Sort the seats and students arrays
        Array.Sort(seats);
        Array.Sort(students);

        int totalMoves = 0;

        // Calculate the total moves required
        for (int i = 0; i < seats.Length; i++) {
            totalMoves += Math.Abs(seats[i] - students[i]);
        }

        return totalMoves;
    }
}
