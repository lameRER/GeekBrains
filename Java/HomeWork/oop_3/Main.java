package homework.oop_3;

public class Main {
    public static void main(String[] args) {
        LinkedList<Integer> list = new LinkedList<>();
        list.addFirst(6);
        list.addFirst(3);
        list.addLast(11);
        list.addByIndex(436, 2);
        list.forEach(System.out::println);
        System.out.println();

        list.removeFirst();
        list.removeLast();
        list.removeByAt(6);
        list.forEach(System.out::println);
    }
}
