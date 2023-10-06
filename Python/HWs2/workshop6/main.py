# from task6 import play_game
from task7 import check_date

# play_game(5)


def task7():
    date_str = input("Введите дату в формате DD.MM.YYYY: ")
    if check_date(date_str):
        print("Дата может существовать")
    else:
        print("Такая дата невозможна")


task7()
