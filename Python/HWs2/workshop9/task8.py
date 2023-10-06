# Напишите следующие функции:
# ○ Нахождение корней квадратного уравнения
# ○ Генерация csv файла с тремя случайными числами в каждой строке.
# 100-1000 строк.
# ○ Декоратор, запускающий функцию нахождения корней квадратного
# уравнения с каждой тройкой чисел из csv файла.
# ○ Декоратор, сохраняющий переданные параметры и результаты работы
# функции в json файл.


import csv
import random

# ○ Генерация csv файла с тремя случайными числами в каждой строке.
# 100-1000 строк.


def generate_csv(file_name):
    with open(file_name, 'w', newline='') as file:
        writer = csv.writer(file)
        for i in range(100, 1001):
            row = [random.randint(1, 1000) for _ in range(3)]
            writer.writerow(row)


generate_csv("generated.csv")
