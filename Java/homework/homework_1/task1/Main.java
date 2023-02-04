package homework.homework_1.task1;
import java.util.Arrays;

public class Main {
    public static void main(String[] args) {
        int[] arr = new int[5];
        for (int i = 0; i < arr.length; i++) {
            arr[i] = (int) (Math.random() * 300);
            System.out.println(arr[i]);
        }
        Arrays.sort(arr);
        System.out.println("Максимальное значение: " + arr[arr.length - 1]);
        System.out.println("Минимальное значение: " + arr[0]);
        System.out.println("Среднее значение: " + arr[arr.length / 2]);
    }
}