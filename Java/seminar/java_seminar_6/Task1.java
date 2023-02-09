package seminar.java_seminar_6;

import java.util.Arrays;
import java.util.HashSet;

public class Task1 {

    public static void main(String[] args) {
        System.out.println(getPercentUniqueValues(initArray()) + "%");
    }

    // Напишите метод, который заполнит массив из 1000 элементов случайными цифрами от 0 до 24.
    public static Integer[] initArray() {
//        Random random = new Random();
        Integer[] arr = new Integer[1000];
        for (int i = 0; i < arr.length; i++)
            arr[i] = (int) (Math.random() * 25);
        return arr;
    }

    // Создайте метод, в который передайте заполненный выше массив и с помощью Set вычислите процент уникальных
    // значений в данном массиве и верните его в виде числа с плавающей запятой.
    // Для вычисления процента используйте формулу:
    // процент уникальных чисел = количество уникальных чисел * 100 / общее количество чисел в массиве.
    public static double getPercentUniqueValues(Integer[] array) {
        HashSet<Integer> hS = new HashSet<Integer>(Arrays.asList(array));
        System.out.println(hS);
        double res = hS.size() / 10;
        return res;
    }
}