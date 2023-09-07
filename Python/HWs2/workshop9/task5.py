# Объедините функции из прошлых задач.
# Функцию угадайку задекорируйте:
# ○ декораторами для сохранения параметров,
# ○ декоратором контроля значений и
# ○ декоратором для многократного запуска.
# Выберите верный порядок декораторов

import json
import random
from pathlib import Path


def validate_input(func):
    def wrapper(num, attempts):
        if num not in range(1, 101) or attempts not in range(1, 11):
            print("Некорректный ввод. Генерируем случайные числа...")
            num = random.randint(1, 100)
            attempts = random.randint(1, 10)
        return func(num, attempts)
    return wrapper


def run_n_times(n):
    def decorator(func):
        def wrapper(*args, **kwargs):
            for i in range(n):
                func(*args, **kwargs)
        return wrapper
    return decorator


def save_to_json(file_name='guessing_game.json'):
    def decorator(func):
        def wrapper(*args, **kwargs):
            path = Path(file_name)
            if path.exists():
                with path.open("r") as f:
                    data = json.load(f)
            else:
                data = {}
            result = func(*args, **kwargs)
            data[str(args) + str(kwargs)] = result
            with path.open("w") as f:
                json.dump(data, f)
            return result
        return wrapper
    return decorator


@run_n_times(2)
@validate_input
@save_to_json()
def guessing_game(num, attempts):
    for i in range(attempts):
        guess = int(input("Угадайте число: "))
        if guess == num:
            print("Вы угадали!")
            return True
        elif guess < num:
            print("Загаданное число больше")
        else:
            print("Загаданное число меньше")
    print("Попытки закончились. Загаданное число было", num)
    return False


guessing_game(50, 5)
