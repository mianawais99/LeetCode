public class Solution {
    public string[] SortPeople(string[] names, int[] heights) {
         // Combine names and heights into a list of tuples
        var people = names.Zip(heights, (name, height) => new { Name = name, Height = height }).ToList();
        
        // Sort the list by heights in descending order
        people.Sort((a, b) => b.Height.CompareTo(a.Height));
        
        // Extract the sorted names
        var sortedNames = people.Select(p => p.Name).ToArray();
        
        return sortedNames;
    }
}

/* Another Solution using Dictionary
public class Solution {
    public string[] SortPeople(string[] names, int[] heights) {
        // Create a dictionary to store heights and their corresponding names
        Dictionary<int, string> peopleDict = new Dictionary<int, string>();

        for (int i = 0; i < names.Length; i++) {
            peopleDict[heights[i]] = names[i];
        }

        // Sort the heights array in descending order
        Array.Sort(heights, (a, b) => b.CompareTo(a));

        // Create a result array to store the sorted names
        string[] sortedNames = new string[names.Length];

        for (int i = 0; i < heights.Length; i++) {
            sortedNames[i] = peopleDict[heights[i]];
        }

        return sortedNames;
    }
} */