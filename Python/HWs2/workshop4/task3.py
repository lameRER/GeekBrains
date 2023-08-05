# ✔ Функция получает на вход строку из двух чисел через пробел.
# ✔ Сформируйте словарь, где ключом будет
# символ из Unicode, а значением — целое число.
# ✔ Диапазон пар ключ-значение от наименьшего из введённых
# пользователем чисел до наибольшего включительно

def unicode_dict(text):
    num1, num2 = map(int, text.split())
    start = min(num1, num2)
    end = max(num1, num2)
    unicode_dict = {}

    for i in range(start, end+1):
        unicode_dict[chr(i)] = i
    return unicode_dict


print(unicode_dict("65 70"))
