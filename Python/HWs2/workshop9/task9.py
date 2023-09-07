# Напишите следующие функции:
# ○ Нахождение корней квадратного уравнения
# ○ Генерация csv файла с тремя случайными числами в каждой строке.
# 100-1000 строк.
# ○ Декоратор, запускающий функцию нахождения корней квадратного
# уравнения с каждой тройкой чисел из csv файла.
# ○ Декоратор, сохраняющий переданные параметры и результаты работы
# функции в json файл.

import csv
from functools import wraps
import math

# ○ Декоратор, запускающий функцию нахождения корней квадратного
# уравнения с каждой тройкой чисел из csv файла.


def run_on_csv(func):
    @wraps(func)
    def wrapper(file_name):
        with open(file_name, 'r') as file:
            reader = csv.reader(file)
            results = []
            for row in reader:
                a, b, c = map(int, row)
                result = func(a, b, c)
                results.append(result)
        return results
    return wrapper


@run_on_csv
def quadratic_equation(a, b, c):
    discr = b ** 2 - 4 * a * c
    if discr < 0:
        return None
    elif discr == 0:
        x = -b / (2 * a)
        return x
    else:
        x1 = (-b + math.sqrt(discr)) / (2 * a)
        x2 = (-b - math.sqrt(discr)) / (2 * a)
        return x1, x2


print(quadratic_equation("generated.csv"))
