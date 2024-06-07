public class Solution {
    // TrieNode class to represent each node in the Trie
    public class TrieNode {
        public Dictionary<char, TrieNode> Children { get; set; } = new Dictionary<char, TrieNode>();
        public string Word { get; set; }
    }

    // Trie class to manage the Trie operations
    public class Trie {
        private readonly TrieNode _root = new TrieNode();
        
        // Method to insert a word into the Trie
        public void Insert(string word) {
            var node = _root;
            foreach (var ch in word) {
                if (!node.Children.ContainsKey(ch)) {
                    node.Children[ch] = new TrieNode();
                }
                node = node.Children[ch];
            }
            node.Word = word;
        }
        
        // Method to search for the shortest root of a given word in the Trie
        public string SearchRoot(string word) {
            var node = _root;
            foreach (var ch in word) {
                if (node.Children.ContainsKey(ch)) {
                    node = node.Children[ch];
                    if (node.Word != null) {
                        return node.Word;
                    }
                } else {
                    break;
                }
            }
            return null;
        }
    }

    // Method to replace words in the sentence with the shortest root from the dictionary
    public string ReplaceWords(IList<string> dictionary, string sentence) {
        var trie = new Trie();
        
        // Insert all roots into the Trie
        foreach (var root in dictionary) {
            trie.Insert(root);
        }
        
        var words = sentence.Split(' ');
        var result = new StringBuilder();
        
        // Replace each word in the sentence with the shortest root
        foreach (var word in words) {
            var replacement = trie.SearchRoot(word);
            if (replacement != null) {
                result.Append(replacement);
            } else {
                result.Append(word);
            }
            result.Append(' ');
        }
        
        // Remove the trailing space
        if (result.Length > 0) {
            result.Length--;
        }
        
        return result.ToString();
    }
}
