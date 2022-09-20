sp = [5, 10, 15, 30]
for s in sp:
    if ((s % 5 == 0) or (s % 10 == 0) or (s % 15 == 0)) and (s % 30 != 0):
        print('Кратно')
    else:
        print('Не кратно')
