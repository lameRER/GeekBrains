# Создайте модуль с функцией внутри.
# Функция получает на вход загадку,
# список с возможными вариантами отгадок и количество попыток на угадывание.
# Программа возвращает номер попытки,
# с которой была отгадана загадка или ноль, если попытки исчерпаны.

import random
import argparse


def guess_riddle(riddle, options, max_attempts):
    """
    Функция для угадывания загадки

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
    """
    Функция для добавления новой загадки в файл

    :param riddle: загадка для добавления
    :param options: список возможных вариантов ответов
    """
    with open("riddles.txt", "a") as f:
        f.write(riddle + "\n")
        for option in options:
            f.write(option + "\n")


def get_random_riddle():
    """
    Функция для получения случайной загадки из файла

    :return: кортеж из загадки и списка возможных вариантов ответов
    """
    with open("riddles.txt", "r") as f:
        lines = f.readlines()
        riddle = random.choice(lines).strip()
        options = [line.strip() for line in lines if line.strip() != riddle]
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
