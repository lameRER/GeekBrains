a = int(input('Введите число недели: '))
listDay = ['', 'Понедельник', 'Вторник', 'Среда', 'Четверг', 'Пятница', 'Суббота', 'Воскресенье']


def GetDaysWeek(n):
    if n == 6 or n == 7:
        return f'{listDay[a]} - Да'
    else:
        return f'{listDay[a]} - Нет'


if 8 > a > 0:
    print(GetDaysWeek(a))
else:
    print('Введено неверно число дня недели')
