public class RedBlackTree {
    private Node root;

    public RedBlackTree() {
        root = null;
    }

    private void rotateLeft(Node x) {
        Node y = x.right;
        x.right = y.left;
        if (y.left != null) {
            y.left.parent = x;
        }
        y.parent = x.parent;
        if (x.parent == null) {
            root = y;
        } else if (x == x.parent.left) {
            x.parent.left = y;
        } else {
            x.parent.right = y;
        }
        y.left = x;
        x.parent = y;
    }

    private void rotateRight(Node x) {
        Node y = x.left;
        x.left = y.right;
        if (y.right != null) {
            y.right.parent = x;
        }
        y.parent = x.parent;
        if (x.parent == null) {
            root = y;
        } else if (x == x.parent.right) {
            x.parent.right = y;
        } else {
            x.parent.left = y;
        }
        y.right = x;
        x.parent = y;
    }

    private void fixViolation(Node node) {
        Node parent = null;
        Node grandparent = null;
        while (node != root && node.color != Color.BLACK && node.parent.color == Color.RED) {
            parent = node.parent;
            grandparent = node.parent.parent;
            if (parent == grandparent.left) {
                Node uncle = grandparent.right;
                if (uncle != null && uncle.color == Color.RED) {
                    grandparent.color = Color.RED;
                    parent.color = Color.BLACK;
                    uncle.color = Color.BLACK;
                    node = grandparent;
                } else {
                    if (node == parent.right) {
                        rotateLeft(parent);
                        node = parent;
                        parent = node.parent;
                    }
                    rotateRight(grandparent);
                    Color temp = parent.color;
                    parent.color = grandparent.color;
                    grandparent.color = temp;
                    node = parent;
                }
            } else {
                Node uncle = grandparent.left;
                if (uncle != null && uncle.color == Color.RED) {
                    grandparent.color = Color.RED;
                    parent.color = Color.BLACK;
                    uncle.color = Color.BLACK;
                    node = grandparent;
                } else {
                    if (node == parent.left) {
                        rotateRight(parent);
                        node = parent;
                        parent = node.parent;
                    }
                    rotateLeft(grandparent);
                    Color temp = parent.color;
                    parent.color = grandparent.color;
                    grandparent.color = temp;
                    node = parent;
                }
            }
        }
        root.color = Color.BLACK;
    }

    public void insert(int value) {
        Node node = new Node(value);
        Node parent = null, current = root;
        while (current != null) {
            parent = current;
            if (node.value < current.value) {
                current = current.left;
            } else {
                current = current.right;
            }
        }
        node.parent = parent;
        if (parent == null) {
            root = node;
        } else if (node.value < parent.value) {
            parent.left = node;
        } else {
            parent.right = node;
        }
        fixViolation(node);
        if (node.parent == null) {
            node.color = Color.BLACK;
        }
    }

    public Node search(int value) {
        Node current = root;
        while (current != null && current.value != value) {
            if (value < current.value) {
                current = current.left;
            } else {
                current = current.right;
            }
        }
        return current;
    }
}