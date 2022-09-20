n = input("Введите вещественное число: ")
sm = 0
for digit in n:
    if digit.isdigit():
        sum += int(digit)
print(sum)
