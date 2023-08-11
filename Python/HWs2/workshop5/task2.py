# ✔ Самостоятельно сохраните в переменной строку текста.
# ✔ Создайте из строки словарь, где ключ — буква, а значение — код буквы.
# ✔ Напишите преобразование в одну строку.

text = input("Введите текст: ")
codes_dict = {char: ord(char) for char in text}
result_str = "".join([f"{char}:{code} " for char, code in codes_dict.items()])
print(result_str)
