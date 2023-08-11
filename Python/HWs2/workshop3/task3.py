# ✔ Создайте вручную кортеж содержащий элементы разных типов.
# ✔ Получите из него словарь списков, где:
# ключ — тип элемента,

my_tuple = (1, "hello", 3.14, True, "world", 42)

result_dict = {}

for element in my_tuple:
    element_type = type(element).__name__
    if element_type not in result_dict:
        result_dict[element_type] = []
    result_dict[element_type].append(element)

print(result_dict)
