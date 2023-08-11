# ✔ Создайте вручную список с повторяющимися элементами.
# ✔ Удалите из него все элементы, которые встречаются дважды.

my_list = [1, 2, 3, 2, 4, 5, 3, 6, 4, 7, 8, 5]

unique_list = [element for element in my_list if my_list.count(element) == 1]

print(unique_list)
