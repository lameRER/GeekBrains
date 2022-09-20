digit = int(input('Ведите число: '))
a = ''
while digit > 0:
    a = str(digit % 2) + a
    digit = digit // 2
print(a)
