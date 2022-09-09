Quarter = input('Введите четверть(1-4): ')
if Quarter.isdigit():
    Quarter = int(Quarter)
    if 1 >= Quarter <= 4:
        if Quarter == 1:
            print('x > 0 < y - 1 четверть')
        elif Quarter == 2:
            print('x < 0 < y - 2 четверть')
        elif Quarter == 3:
            print('x < 0 > y - 3 четверть')
        elif Quarter == 4:
            print('x > 0 > y - 4 четверть')
    else:
        print('Введено недопустимое число')
else:
    print('Введен недопустимый символ')
