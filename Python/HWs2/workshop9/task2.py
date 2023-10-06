# Дорабатываем задачу 1.
# Превратите внешнюю функцию в декоратор.
# Он должен проверять входят ли переданные в функцию - угадайку числа
# в диапазоны [1, 100] и [1, 10].
# Если не входят, вызывать функцию со случайными числами
# из диапазонов.

import random


def validate_input(func):
    def wrapper():
        num = int(input("Введите число от 1 до 100 для загадывания: "))
        attempts = int(input("Введите количество попыток от 1 до 10: "))
        if num not in range(1, 101) or attempts not in range(1, 11):
            print("Некорректный ввод. Генерируем случайные числа...")
            num = random.randint(1, 100)
            attempts = random.randint(1, 10)
        func(num, attempts)
    return wrapper


@validate_input
def guessing_game(num, attempts):
    def game():
        for i in range(attempts):
            guess = int(input("Угадайте число: "))
            if guess == num:
                print("Вы угадали!")
                return
            elif guess < num:
                print("Загаданное число больше")
            else:
                print("Загаданное число меньше")
        print("Попытки закончились. Загаданное число было", num)
    game()


guessing_game()
