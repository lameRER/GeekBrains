import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.Deque;

public class Task1 {
    //Даны два Deque представляющие два неотрицательных целых числа.
    // Цифры хранятся в обратном порядке,
    // и каждый из их узлов содержит одну цифру.
    // Сложите два числа и верните сумму в виде связанного списка.
    public static void main(String[] args) {
        Deque<Integer> d1 = new ArrayDeque<>(Arrays.asList(1,2,2));
        Deque<Integer> d2 = new ArrayDeque<>(Arrays.asList(5,9,6));
        // result [6,6,0,1]
        System.out.println(sum(d1, d2));
    }


    public static Deque<Integer> sum(Deque<Integer> d1, Deque<Integer> d2) {
        return toDeque(toInt(d1) + toInt(d2));
    }

    public static int toInt(Deque<Integer> deq) {
        int n = 0;
        int i = 0;
        while(deq.size() > 0) {
            n += deq.removeFirst() * Math.pow(10, i++);
        }
        return n;
    }

    public static ArrayDeque<Integer> toDeque(int n) {
        ArrayDeque<Integer> rezDeq = new ArrayDeque<>();
        while (n > 0) {
            rezDeq.add(n % 10);
            n /= 10;
        }
        return rezDeq;
    }
}