# Добавьте возможность запуска функции “угадайки” из модуля в командной
# строке терминала.
# Строка должна принимать от 1 до 3 аргументов: параметры вызова функции.
# Для преобразования строковых аргументов командной строки в числовые параметры
# используйте генераторное выражение.


import argparse
import random


def guess_number(lower_bound, upper_bound, max_attempts):
    number = random.randint(lower_bound, upper_bound)
    for attempt in range(max_attempts):
        guess = int(input(
            f"Угадайте число от {lower_bound} до {upper_bound}: "))
        if guess < number:
            print("Загаданное число больше")
        elif guess > number:
            print("Загаданное число меньше")
        else:
            print("Вы угадали!")
            return True
    print(f"Попытки исчерпаны. Было загадано число {number}")
    return False


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description='Угадайте число: ')
    parser.add_argument('--lower', type=int,
                        default=1, help='Lower bound of the number range')
    parser.add_argument('--upper', type=int,
                        default=100, help='Upper bound of the number range')
    parser.add_argument('--attempts', type=int,
                        default=10, help='Maximum number of attempts')
    args = parser.parse_args()

    guess_number(args.lower, args.upper, args.attempts)
