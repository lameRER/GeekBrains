# Напишите функцию, которая принимает строку текста.
# Сформируйте список с уникальными кодами Unicode каждого
# символа введённой строки отсортированный по убыванию.

# https://habr.com/ru/articles/485148/

def unicode_codes(text):
    code_points = set()

    for char in text:
        code_points.add(ord(char))
    sorted_codes = sorted(code_points, reverse=True)
    return sorted_codes


print(unicode_codes("Aloha!"))
