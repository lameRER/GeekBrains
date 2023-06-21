import java.io.File;
import java.io.FileNotFoundException;
import java.util.Arrays;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        try {
            method1();
        } catch (FileNotFoundException e) {
            System.out.println("File not found");
        } catch (ArithmeticException e) {
            System.out.println("Division by zero");
        }

        try {
            method2();
        } catch (NullPointerException e) {
            System.out.println("Null pointer exception");
        }

        try {
            method3();
        } catch (CustomException e) {
            System.out.println(e.getMessage());
        }

        try {
            int[] arr1 = {1, 2, 3};
            int[] arr2 = {4, 5, 6};
            int[] result = diffArrays(arr1, arr2);
            System.out.println(Arrays.toString(result));

            int[] arr3 = {1, 2};
            int[] arr4 = {4, 5, 6};
            int[] result2 = diffArrays(arr3, arr4);
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }

    public static void method1() throws FileNotFoundException, ArithmeticException {
        File file = new File("nonexistent.txt");
        Scanner scanner = new Scanner(file);
        int result = 10 / 0;
        scanner.close();
    }

    public static void method2() {
        String str = null;
        System.out.println(str.length());
    }

    public static void method3() throws CustomException {
        int age = 17;
        if (age < 18) {
            throw new CustomException("You must be at least 18 years old");
        }
    }

    // метод для второго задания
    public static int[] diffArrays(int[] arr1, int[] arr2) throws Exception {
        if (arr1.length != arr2.length) {
            throw new Exception("Длины массивов не равны!");
        }
        int[] result = new int[arr1.length];
        for (int i = 0; i < arr1.length; i++) {
            result[i] = arr1[i] - arr2[i];
        }
        return result;
    }


}

class CustomException extends Exception {
    public CustomException(String message) {
        super(message);
    }
}