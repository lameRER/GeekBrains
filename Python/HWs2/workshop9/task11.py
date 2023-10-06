# Напишите следующие функции:
# ○ Нахождение корней квадратного уравнения
# ○ Генерация csv файла с тремя случайными числами в каждой строке.
# 100-1000 строк.
# ○ Декоратор, запускающий функцию нахождения корней квадратного
# уравнения с каждой тройкой чисел из csv файла.
# ○ Декоратор, сохраняющий переданные параметры и результаты работы
# функции в json файл.

import csv
import json
from functools import wraps
import math
import random


def generate_csv(file_name):
    def decorator(func):
        @wraps(func)
        def wrapper(*args, **kwargs):
            with open(file_name, 'w', newline='') as file:
                writer = csv.writer(file)
                for i in range(100, 1001):
                    row = [random.randint(1, 1000) for _ in range(3)]
                    writer.writerow(row)
            with open(file_name, 'r') as file:
                reader = csv.reader(file)
                results = []
                for row in reader:
                    a, b, c = map(int, row)
                    result = func(a, b, c)
                    results.append(result)
            return results
        return wrapper
    return decorator


def save_to_json(file_name):
    def decorator(func):
        @wraps(func)
        def wrapper(*args, **kwargs):
            result = func(*args, **kwargs)
            with open(file_name, 'a') as file:
                data = {
                    'args': args,
                    'result': result
                }
                json.dump(data, file)
                file.write('\n')
            return result
        return wrapper
    return decorator


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


@generate_csv('quadratic.csv')
@save_to_json('quadratic_results.json')
def solve_quadratic_equation(a, b, c):
    return quadratic_equation(a, b, c)


print(solve_quadratic_equation())
