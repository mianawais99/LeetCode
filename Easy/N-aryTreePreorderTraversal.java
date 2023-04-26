class Solution {
    List<Integer> arr = new ArrayList<>();
    public List<Integer> preorder(Node root) {
        if (root==null) return arr;
        arr.add(root.val);
        for (Node i : root.children) {
            preorder(i);
        }
        return arr;
    }
}