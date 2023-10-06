# Напишите декоратор, который сохраняет в json файл
# параметры декорируемой функции и результат, который она
# возвращает. При повторном вызове файл должен
# расширяться, а не перезаписываться.
# Каждый ключевой параметр сохраните как отдельный ключ
# json словаря.
# Для декорирования напишите функцию, которая может
# принимать как позиционные, так и ключевые аргументы.
# Имя файла должно совпадать с именем декорируемой
# функции.

import json


def save_to_json(func):
    def wrapper(*args, **kwargs):
        file_name = func.__name__ + ".json"
        try:
            with open(file_name, "r") as f:
                data = json.load(f)
        except FileNotFoundError:
            data = {}
        result = func(*args, **kwargs)
        data[str(args) + str(kwargs)] = result
        with open(file_name, "w") as f:
            json.dump(data, f)
        return result
    return wrapper


@save_to_json
def add_numbers(a, b):
    return a + b


@save_to_json
def multiply_numbers(a, b):
    return a * b


print(add_numbers(2, 3))
print(multiply_numbers(a=2, b=3))
