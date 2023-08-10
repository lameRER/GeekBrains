# Вручную создайте список с целыми числами, которые
# повторяются. Получите новый список, который содержит
# уникальные (без повтора) элементы исходного списка.

lst = [1, 2, 3, 4, 2, 3, 5, 6, 1]
unique_lst = []

for i in lst:
    if i not in unique_lst:
        unique_lst.append(i)

print(unique_lst)

lst = [1, 2, 3, 4, 2, 3, 5, 6, 1]
unique_lst = list(set(lst))
print(unique_lst)
