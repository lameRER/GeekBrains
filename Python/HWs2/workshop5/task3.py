# ✔ Продолжаем развивать задачу 2.
# ✔ Возьмите словарь, который вы получили.
# Сохраните его итераторатор.
# ✔ Далее выведите первые 5 пар ключ-значение,
# обращаясь к итератору, а не к словарю.

text = input("Введите текст: ")
codes_dict = {char: ord(char) for char in text}
iter_dict = iter(codes_dict.items())
for i in range(5):
    print(next(iter_dict))
