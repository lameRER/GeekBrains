d = input('Введите число: ')
x = 0
for d in range(1, 1000000):
    x = x + 4 * ((-1) ** (d + 1)) / (2 * d - 1)
print(round(x, 3))
