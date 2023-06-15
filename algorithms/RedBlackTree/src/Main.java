public class Main {
    public static void main(String[] args) {
        RedBlackTree tree = new RedBlackTree();
        tree.insert(10);
        tree.insert(20);
        tree.insert(30);
        tree.insert(15);
        tree.insert(18);
        tree.insert(25);
        Node found = tree.search(18);
        if (found != null) {
            System.out.println("Found node with value " + found.value);
        } else {
            System.out.println("Node not found");
        }
    }
}