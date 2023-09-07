# Напишите следующие функции:
# ○ Нахождение корней квадратного уравнения
# ○ Генерация csv файла с тремя случайными числами в каждой строке.
# 100-1000 строк.
# ○ Декоратор, запускающий функцию нахождения корней квадратного
# уравнения с каждой тройкой чисел из csv файла.
# ○ Декоратор, сохраняющий переданные параметры и результаты работы
# функции в json файл.

import json
from functools import wraps
import math

# ○ Декоратор, сохраняющий переданные параметры и результаты работы
# функции в json файл.


def save_to_json(file_name):
    def decorator(func):
        @wraps(func)
        def wrapper(*args, **kwargs):
            result = func(*args, **kwargs)
            with open(file_name, 'a') as file:
                data = {
                    'args': args,
                    'kwargs': kwargs,
                    'result': result
                }
                json.dump(data, file)
                file.write('\n')
            return result
        return wrapper
    return decorator


@save_to_json('quadratic_results.json')
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
