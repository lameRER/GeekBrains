n = input("Введите вещественное число: ")
sum = 0
for digit in n:
    if digit.isdigit():
        sum += int(digit)
print(sum)
