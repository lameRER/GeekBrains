# Посчитайте сумму чётных элементов от 1 до n исключая кратные e.
# Используйте while и if.
# Попробуйте разные значения e и n.

n = 21
e = 4

i = 0
sum_even = 0

while i <= n:
    i += 1
    if i % e == 0 or i % 2 != 0:
        continue
    sum_even += i

print(sum_even)
