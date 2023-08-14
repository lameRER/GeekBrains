# Создайте модуль с функцией внутри.
# Функция принимает на вход три целых числа: нижнюю
# и верхнюю границу и количество попыток.
# Внутри генерируется случайное число в указанных границах
# и пользователь должен угадать его за заданное число попыток.
# Функция выводит подсказки “больше” и “меньше”.
# Если число угадано, возвращается истина, а если попытки исчерпаны - ложь.

__all__ = ['guess_number']

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
