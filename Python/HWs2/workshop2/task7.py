# Напишите программу, которая получает целое
# число и возвращает его шестнадцатеричное
# строковое представление. Функцию hex
# используйте для проверки своего результата.

# https://ru.wikipedia.org/wiki/%D0%A8%D0%B5%D1%81%D1%82%D0%BD%D0%B0%D0%B4%D1%86%D0%B0%D1%82%D0%B5%D1%80%D0%B8%D1%87%D0%BD%D0%B0%D1%8F_%D1%81%D0%B8%D1%81%D1%82%D0%B5%D0%BC%D0%B0_%D1%81%D1%87%D0%B8%D1%81%D0%BB%D0%B5%D0%BD%D0%B8%D1%8F
# https://inf1.info/hexadecimal


def toHex(num):
    hex_num = ""
    while True:
        hex_num += "0123456789ABCDEF"[num % 16]
        num //= 16
        if num == 0:
            return hex_num


num = int(input("Введите число: "))
hex_num = toHex(num)
print("Шестнадцатеричное представление числа:", hex_num)

check_hex_num = hex(num)
print("Шестнадцатеричное представление числа:", check_hex_num)
