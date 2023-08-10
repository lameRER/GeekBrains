# Создайте функцию генератор чисел Фибоначчи (см. Википедию)
# https://ejudge.179.ru/tasks/python/2017b1/pgm23__Generators.html


def fib(n):
    a, b = 0, 1
    for __ in range(n):
        yield a
        a, b = b, a + b


print(list(fib(22)))
