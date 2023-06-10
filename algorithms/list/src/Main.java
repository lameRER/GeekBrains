public class Main {
    public static class MyList{
        private Node Head;

        private class Node{
            private int value;
            private Node next;
        }

        void push(int value){
            Node node = new Node();
            node.value = value;
            node.next = Head;
            Head = node;
        }

        Integer pop(){
            if (Head != null) {
                Integer value = Head.value;
                Head = Head.next;
                return value;
            }
            return null;
        }

        void reverse(){
            Node prev = null;
            Node current = Head;
            Node next = null;
            while (current != null){
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            Head = prev;
        }

        void print(){
            Node current = Head;
            while (current != null){
                System.out.println(current.value);
                current = current.next;
            }
        }

        Node find(int value){
            Node current = Head;
            while (current != null){
                if(current.value == value){
                    System.out.println(current);
                    return current;
                }
                current = current.next;
            }
            return null;
        }

        public boolean contains(int value){
            Node node = Head;
            while (node != null){
                if (node.value == value){
                    return true;
                }
                node = node.next;
            }
            return false;
        }
    }
    public static void main(String[] args) throws Exception {
        MyList mylist = new MyList();
        mylist.push(1);
        mylist.push(2);
        mylist.push(3);
        mylist.push(4);
        mylist.print();

        System.out.println("- - - - - - - - - -");
        mylist.pop();
        mylist.print();
        System.out.println("- - - - - - - - - -");
        mylist.reverse();
        mylist.print();
        System.out.println("- - - - - - - - - -");
        mylist.find(2);
        System.out.println("- - - - - - - - - -");
        System.out.println(mylist.contains(2));

    }
}