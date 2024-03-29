# Пользователь вводит данные. Сделайте проверку данных
# и преобразуйте если возможно в один из вариантов ниже:
# ✔ Целое положительное число
# ✔ Вещественное положительное или отрицательное число
# ✔ Строку в нижнем регистре, если в строке есть
# хотя бы одна заглавная буква
# ✔ Строку в нижнем регистре в остальных случаях

data = input("Введите данные: ")

if data.isdigit():
    data = int(data)
    print("Вы ввели целое положительное число:", data)

elif "." in data:
    try:
        data = float(data)
        print("Вы ввели вещественное число:", data)
    except ValueError:
        print("Ошибка: введенная строка не является числом")

elif data.islower():
    print("Вы ввели строку в нижнем регистре:", data)

else:
    data = data.lower()
    print("Вы ввели строку, преобразованную в нижний регистр:", data)
