# ✔ Функция получает на вход список чисел и два индекса.
# ✔ Вернуть сумму чисел между между переданными индексами.
# ✔ Если индекс выходит за пределы списка, сумма считается
# до конца и/или начала списка.


def sum_between_indexes(lst, index1, index2):
    start = min(index1, index2)
    end = max(index1, index2)
    total = 0
    for i in range(start, end+1):
        if i < 0 or i >= len(lst):
            continue
        total += lst[i]
    return total


print(sum_between_indexes([1, 2, 3, 4, 5], 0, 3))
