# Напишите программу, которая запрашивает год и проверяет его на високосность.
# Распишите все возможные проверки в цепочке elif
# Откажитесь от магических чисел
# Обязательно учтите год ввода Григорианского календаря
# В коде должны быть один input и один print

MAIN_LEAP_CRITERIA = 4
EXCEPT_LEAP_CRIT = 100
ADDITIONAL_LEAP_CRIT = 400

year = int(input('Year: '))

if (year % MAIN_LEAP_CRITERIA == 0 and year % EXCEPT_LEAP_CRIT != 0) or (year % ADDITIONAL_LEAP_CRIT == 0):
    print('Год високосный')
else:
    print('Не является високосным')
