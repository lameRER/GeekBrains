# ✔ Создайте вручную список с повторяющимися целыми числами.
# ✔ Сформируйте список с порядковыми номерами
# нечётных элементов исходного списка.
# ✔ Нумерация начинается с единицы.

my_list = [1, 2, 3, 2, 4, 5, 3, 6, 4, 7, 8, 5]
# my_list = list(map(int, input("Cписок: ").split()))
odd_indices = [i + 1 for i, v in enumerate(my_list) if v % 2 != 0]
print(odd_indices)