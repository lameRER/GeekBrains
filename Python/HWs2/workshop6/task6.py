# Добавьте в модуль с загадками функцию, которая принимает на вход строку
# (текст загадки) и число (номер попытки, с которой она угадана).
# Функция формирует словарь с информацией о результатах отгадывания.
# Для хранения используйте защищённый словарь уровня модуля.
# Отдельно напишите функцию, которая выводит результаты
# угадывания из защищённого словаря в удобном для чтения виде.
# Для формирования результатов используйте генераторное выражение.

# Этот модуль можно запускать из main.py

__all__ = ['play_game']

import json
import random


def guess_riddle(riddle, options, max_attempts):
    print("Отгадайте загадку:")
    print(riddle)
    results = {}
    for attempt in range(1, max_attempts + 1):
        answer = input("Введите ваш ответ: ")
        if answer in options:
            results[attempt] = answer
            return results, attempt
        else:
            results[attempt] = "Неверный ответ"
            print(f"Попытка {attempt}: Неверный ответ")
    return results, 0


def add_riddle(riddle, options):
    with open("riddles.json", "r+", encoding="UTF-8") as f:
        riddles = json.load(f)
        riddles[riddle] = options
        f.seek(0)
        json.dump(riddles, f)


def get_random_riddle():
    with open("riddles.json", "r+", encoding="UTF-8") as f:
        riddles = json.load(f)
        riddle = random.choice(list(riddles.keys()))
        options = riddles[riddle]
        return riddle, options


def print_results(results):
    protected_dict = {f"Попытка {attempt}":
                      answer for attempt, answer in results.items()}
    print("\nРезультаты:")
    for key, value in protected_dict.items():
        print(f"{key}: {value}")


def play_game(max_attempts, riddle=None, options=None):
    if riddle and options:
        add_riddle(riddle, options)
        riddle = riddle
        options = options
    else:
        riddle, options = get_random_riddle()
    results, attempt = guess_riddle(riddle, options, max_attempts)
    if attempt > 0:
        print(f"Загадка отгадана с {attempt}-ой попытки!")
    else:
        print("Попытки исчерпаны. Загадка не отгадана.")
    print_results(results)
