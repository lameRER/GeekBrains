import java.util.ArrayList;
import java.util.InputMismatchException;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
         processArray(); // 1.
//         operations(); // 2.
//         emptyString(); // 3.

    }


    public static float readFloatFromUser() {
        Scanner scanner = new Scanner(System.in);
        while (true) {
            try {
                System.out.print("Введите число с плавающей точкой: ");
                float input = scanner.nextFloat();
                return input;
            } catch (InputMismatchException e) {
                System.out.println("Ошибка: введено некорректное значение");
                scanner.nextLine();
            } catch (NumberFormatException e) {
                System.out.println("Ошибка: введено некорректное число");
                scanner.nextLine();
            }
        }
    }

    public static void processArray() {
        Scanner scanner = new Scanner(System.in);
        int[] intArray = new int[10];
        int d = 0;
        try {
            System.out.println("Введите 10 чисел, отделяя их друг от друга пробелами: ");
            for (int i = 0; i < 10; i++) {
                intArray[i] = scanner.nextInt();
            }
            System.out.println("Введите число d, но помните, что на ноль делить нельзя: ");
            d = scanner.nextInt();
            double catchedRes1 = intArray[8] / (double)d;
            System.out.println("Результат: " + catchedRes1);
        } catch (ArithmeticException e) {
            System.out.println("А я предупреждал... " + e);
        } catch (ArrayIndexOutOfBoundsException e) {
            System.out.println("Просил же 10 чисел... " + e);
        } catch (InputMismatchException e) {
            System.out.println("Числа, мать, числа! " + e);
        }
    }

    public static void operations() {
        Scanner scanner = new Scanner(System.in);
        List<Integer> numbers = new ArrayList<>();
        try {
            System.out.print("Введите первое число: ");
            int num1 = scanner.nextInt();
            System.out.print("Введите второе число: ");
            int num2 = scanner.nextInt();
            numbers.add(num1);
            numbers.add(num2);
            int result = num1 / num2;
            System.out.println("Результат деления: " + result);
            numbers.add(result);
            int sum = num1 + num2;
            System.out.println("Сумма чисел: " + sum);
            numbers.add(sum);
        } catch (InputMismatchException ex) {
            System.out.println("Неверный формат ввода!");
        } catch (ArithmeticException ex) {
            System.out.println("Деление на ноль!");
        } catch (Exception ex) {
            System.out.println("Произошла ошибка: " + ex.getMessage());
        }
    }

    public static void emptyString(){
        Scanner scanner = new Scanner(System.in);
        System.out.print("Введите строку: ");
        String input = scanner.nextLine();
        try {
            if (input.trim().isEmpty()) {
                throw new Exception("Пустые строки вводить нельзя");
            }
            System.out.println("Вы ввели: " + input);
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }
}