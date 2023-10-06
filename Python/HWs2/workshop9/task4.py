# Создайте декоратор с параметром.
# Параметр - целое число, количество запусков декорируемой
# функции.

import random


def run_n_times(n):
    def decorator(func):
        def wrapper(*args, **kwargs):
            for i in range(n):
                result = func(*args, **kwargs)
            return result
        return wrapper
    return decorator


@run_n_times(3)
def add_numbers(a, b):
    result = a + b + random.randint(1, 10)
    print(f"Складываем {a} и {b}: {result}")
    return result


@run_n_times(2)
def multiply_numbers(a, b):
    result = a * b * random.randint(1, 10)
    print(f"Умножаем {a} и {b}: {result}")
    return result


print(add_numbers(2, 3))
print(multiply_numbers(2, 3))
