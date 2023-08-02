# Напишите программу, которая принимает две строки
# вида “a/b” — дробь с числителем и знаменателем.
# Программа должна возвращать сумму
# и *произведение дробей. Для проверки своего
# кода используйте модуль fractions.

from fractions import Fraction


def my_sum(frac1, frac2):
    a, b = map(int, frac1.split('/'))
    c, d = map(int, frac2.split('/'))

    number = first = a * d + c * b
    denum = second = b * d

    while first != second:
        if first > second:
            first -= second
        else:
            second -= first
    return f"{number//first}/{denum//first}"


def my_prod(frac1, frac2):
    a, b = map(int, frac1.split('/'))
    c, d = map(int, frac2.split('/'))

    number = first = a * c
    denum = second = b * d

    while first != second:
        if first > second:
            first -= second
        else:
            second -= first
    return f"{number//first}/{denum//first}"


def sum_and_product(frac1, frac2):
    f1 = Fraction(frac1)
    f2 = Fraction(frac2)

    sum_frac = f1 + f2
    prod_frac = f1 * f2

    return sum_frac, prod_frac


frac1 = input("Введите первую дробь: ")
frac2 = input("Введите вторую дробь: ")
my_sum = my_sum(frac1, frac2)
my_prod = my_prod(frac1, frac2)

sum_frac, prod_frac = sum_and_product(frac1, frac2)
print("Сумма дробей:", my_sum, sum_frac)
print("Произведение дробей:", my_prod, prod_frac)
