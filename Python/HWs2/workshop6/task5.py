# Добавьте в модуль с загадками функцию, которая хранит словарь списков.
# Ключ словаря - загадка, значение - список с отгадками.
# Функция в цикле вызывает загадывающую функцию,
# чтобы передать ей все свои загадки.

import json
import argparse
import random


def guess_riddle(riddle, options, max_attempts):
    """
    Функция для угадывания загадки из списка возможных ответов

    :param riddle: загадка для отгадывания
    :param options: список возможных вариантов ответов
    :param max_attempts: максимальное количество попыток на отгадывание
    :return: номер попытки, с которой была отгадана загадка или 0,
    если попытки исчерпаны
    """
    print("Отгадайте загадку:")
    print(riddle)
    for attempt in range(1, max_attempts + 1):
        answer = input("Введите ваш ответ: ")
        if answer in options:
            return attempt
        else:
            print(f"Попытка {attempt}: Неверный ответ")
    return 0


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


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description="Игра в угадывание загадок")
    parser.add_argument("max_attempts", type=int,
                        help="максимальное количество попыток на отгадывание")
    parser.add_argument("--riddle", type=str,
                        help="текст загадки")
    parser.add_argument("--options", nargs="+",
                        help="список возможных вариантов ответов")
    args = parser.parse_args()
    print(type(args))

    if args.riddle and args.options:
        add_riddle(args.riddle, args.options)
        riddle = args.riddle
        options = args.options
    else:
        riddle, options = get_random_riddle()
    result = guess_riddle(riddle, options, args.max_attempts)
    if result > 0:
        print(f"Загадка отгадана с {result}-ой попытки!")
    else:
        print("Попытки исчерпаны. Загадка не отгадана.")
