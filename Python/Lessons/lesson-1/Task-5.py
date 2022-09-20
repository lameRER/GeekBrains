d = int(input())
if ((d % 5 == 0) or (d % 10 == 0) or (d % 15 == 0)) and (d % 30 != 0):
    print('Кратно')
else:
    print('Не кратно')
