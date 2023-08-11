# ✔ Напишите программу, которая получает целое число и возвращает
# его двоичное, восьмеричное строковое представление.
# ✔ Функции bin и oct используйте для проверки своего
# результата, а не для решения.
# Дополнительно:
# ✔ Попробуйте избежать дублирования кода
# в преобразованиях к разным системам счисления
# ✔ Избегайте магических чисел
# ✔ Добавьте аннотацию типов где это возможно

def num_to_base(num: int, base: int):
    if base == 2:
        result = ""
        while num > 0:
            result = str(num % 2) + result
            num //= 2
        return result
    elif base == 8:
        result = ""
        while num > 0:
            result = str(num % 8) + result
            num //= 8
        return result
    else:
        return ""


def check(num: int, base: int):
    if base == 2:
        return bin(num)[2:]
    elif base == 8:
        return oct(num)[2:]
    else:
        return ""


num = int(input("Введите число: "))
bin_num = num_to_base(num, 2)
check_bin_num = check(num, 2)
oct_num = num_to_base(num, 8)
check_oct_num = check(num, 8)

print(f"Число {num} в двоичной системе: {bin_num}")
print(check_bin_num)
print(f"Число {num} в восьмеричной системе: {oct_num}")
print(check_oct_num)
