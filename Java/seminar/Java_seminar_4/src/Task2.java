import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.Deque;

public class Task2 {
    public static void main(String[] args) {
        Deque<Integer> d1 = new ArrayDeque<>(Arrays.asList(1,2,3));
        Deque<Integer> d2 = new ArrayDeque<>(Arrays.asList(5,9,7));
        // result [6,6,0,1]
        Deque<Integer> res = sum(d1, d2);
        System.out.println(res);
    }


    public static Deque<Integer> sum(Deque<Integer> d1, Deque<Integer> d2) {
        int len = d1.size() < d2.size() ? d1.size():d2.size();
        int buf = 0;
        Deque<Integer> d3 = new ArrayDeque<>();
        while (len > 0 ){
            int tmp = d1.pollFirst() + d2.pollFirst();
            if (tmp > 9) {
                d3.addLast(tmp % 10);
                buf =1 ;
            }
            else if (buf == 1)
                d3.addLast(tmp+1);
            else d3.addLast(tmp);
            len--;
        }
        return new ArrayDeque<>(d3);
    }
}
