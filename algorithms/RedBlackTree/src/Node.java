class Node {
    int value;
    Color color;
    Node left, right, parent;

    public Node(int value) {
        this.value = value;
        color = Color.RED;
        left = right = parent = null;
    }
}