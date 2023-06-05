import java.util.Scanner;

public class Main {
    public static void heapSort(int[] arr) {
        buildMaxHeap(arr);
        for (int i = arr.length - 1; i > 0; i--) {
            swap(arr, 0, i);
            maxHeapify(arr, 0, i);
        }
    }

    private static void buildMaxHeap(int[] arr) {
        int length = arr.length;
        int start = parent(length - 1);
        while (start >= 0) {
            maxHeapify(arr, start, length);
            start--;
        }
    }

    private static void maxHeapify(int[] arr, int index, int size) {
        int left = left(index);
        int right = right(index);
        int largest;
        if (left < size && arr[left] > arr[index]) {
            largest = left;
        } else {
            largest = index;
        }
        if (right < size && arr[right] > arr[largest]) {
            largest = right;
        }
        if (largest != index) {
            swap(arr, index, largest);
            maxHeapify(arr, largest, size);
        }
    }

    private static int parent(int i) {
        return (i - 1) / 2;
    }

    private static int left(int i) {
        return 2 * i + 1;
    }

    private static int right(int i) {
        return 2 * i + 2;
    }

    private static void swap(int[] arr, int i, int j) {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter the list of numbers: ");
        String[] input = scanner.nextLine().split(" ");
        int[] arr = new int[input.length];
        for (int i = 0; i < input.length; i++) {
            arr[i] = Integer.parseInt(input[i]);
        }
        heapSort(arr);
        System.out.print("Sorted list: ");
        for (int num : arr) {
            System.out.print(num + " ");
        }
    }
}
