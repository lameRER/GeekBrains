package seminar.Java_seminar_4;// Дан Deque состоящий из последовательности цифр.
// Необходимо проверить, что последовательность цифр является палиндромом

import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.Deque;

public class Task0 {
    public static void main(String[] args) {
        Deque<Integer> deque = new ArrayDeque<>(Arrays.asList(1, 2, 3, 2, 1));
        System.out.println(isPolindrom(deque));
    }

    public static boolean isPolindrom(Deque<Integer> deq) {
        while (deq.size() > 1 && deq.peekFirst() != null) {
            if (!deq.removeFirst().equals(deq.removeLast()))
                return false;
        }
        return true;
    }
}