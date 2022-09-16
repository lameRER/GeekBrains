lst = [int(i) for i in input('Введите список чисел: ').split()]
lst2 = []
for ls in lst:
    a = ls - int(ls)
    if a != 0:
        lst2.append(round(a, 2))
print(lst, '=>', max(lst2) - min(lst2))
