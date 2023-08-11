# ✔ Напишите программу, которая решает
# квадратные уравнения даже если
# дискриминант отрицательный.
# ✔ Используйте комплексные числа
# для извлечения квадратного корня.


# D=b2−4ac, https://mat.1sept.ru/view_article.php?ID=200101001,
# https://www.mathway.com/ru/Algebra


import math

a = float(input("Введите коэффициент a: "))
b = float(input("Введите коэффициент b: "))
c = float(input("Введите коэффициент c: "))

discriminant = b**2 - 4*a*c

if discriminant >= 0:
    x1 = (-b + math.sqrt(discriminant)) / (2*a)
    x2 = (-b - math.sqrt(discriminant)) / (2*a)
    print(f"Корни уравнения: {x1:.2f} и {x2:.2f}")
else:
    real_part = -b / (2*a)
    imaginary_part = math.sqrt(abs(discriminant)) / (2*a)
    x1 = complex(real_part, imaginary_part)
    x2 = complex(real_part, -imaginary_part)
    print(f"Корни уравнения: {x1} и {x2}")
