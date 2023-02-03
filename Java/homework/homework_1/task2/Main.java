import java.util.Arrays;

public class Main {
    public static void main(String[] args) {
        int[] arr = {4, 1, 66, 9, 5, 15, 45, 54, 2};
        System.out.println(Arrays.toString(arr));
        bubbleSort(arr);
        System.out.println(Arrays.toString(arr));
    }

    private static int[] bubbleSort(int[] arr) {
        boolean flag = true;
        while (flag) {
            flag = false;
            for (int i = 0; i < arr.length; i++) {
                if (arr.length != i + 1 && arr[i] > arr[i + 1]) {
                    int item = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = item;
                    flag = true;
                }
            }
        }
        return arr;
    }
}