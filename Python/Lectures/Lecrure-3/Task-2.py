import math

lst = [int(i) for i in input('Введите список чисел: ').split()]
multi = []
for l in range(math.ceil(len(lst) / 2)):
    multi.append(lst[l] * lst[-l - 1])
print(lst, '=', multi)
