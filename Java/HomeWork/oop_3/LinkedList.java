package homework.oop_3;

import java.util.Iterator;

public class LinkedList<E> implements Iterable<E> {

    private Node<E> head;
    private Node<E> tail;

    public LinkedList() {
        head = null;
        tail = null;
    }

    private boolean isEmpty() {
        return head == null;
    }

    void addFirst(E element) {
        Node<E> newNode = new Node<>(element);

        if (isEmpty()) tail = newNode;
        else head.prev = newNode;

        newNode.next = head;
        head = newNode;
    }

    void addLast(E element) {
        Node<E> newNode = new Node<>(element);

        if (isEmpty()) head = newNode;
        else tail.next = newNode;

        newNode.prev = tail;
        tail = newNode;
    }

    void addByIndex(E element, int index) {
        Node<E> currentNode = head;

        int c = 0;

        while (currentNode != null && c != index) {
            currentNode = currentNode.next;
            c++;
        }

        Node<E> newNode = new Node<>(element);
        if (currentNode != null) {
            currentNode.prev.next = newNode;
        }
        if (currentNode != null) {
            newNode.prev = currentNode.prev;
        }
        if (currentNode != null) {
            currentNode.prev = newNode;
        }
        newNode.next = currentNode;

    }

    void removeFirst() {

        if (head.next == null) tail = null;
        else head.next.prev = null;

        head = head.next;
    }

    void removeLast() {
        if (head.next == null) tail = null;
        else tail.prev.next = null;

        tail = tail.prev;
    }

    void removeByAt(E key) {
        Node<E> currentNode = head;

        while (currentNode.element != key) {
            currentNode = currentNode.next;

            if (currentNode == null) return;
        }

        if (currentNode == head) removeFirst();
        else currentNode.prev.next = currentNode.next;

        if (currentNode == tail) removeLast();
        else currentNode.next.prev = currentNode.prev;
    }

    void print() {
        Node<E> node = head;

        while (node != null) {
            System.out.println(node.element);
            node = node.next;
        }
    }

    @Override
    public Iterator iterator() {
        return new Iterator<E>() {
            Node<E> currentNode = head;

            @Override
            public boolean hasNext() {
                return currentNode != null;
            }

            @Override
            public E next() {
                var result = currentNode.element;
                currentNode = currentNode.next;
                return result;
            }
        };
    }

    public static class Node<E> {
        public E element;

        public Node<E> next;

        public Node<E> prev;

        public Node(E element) {
            this.element = element;
        }
    }
}
