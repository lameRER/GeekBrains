# Дан список повторяющихся элементов. Вернуть список
# с дублирующимися элементами. В результирующем списке
# не должно быть дубликатов.

array_list = [1, 2, 3, 1, 2, 4, 5]
dup = [x for i, x in enumerate(array_list) if i != array_list.index(x)]
print(dup)