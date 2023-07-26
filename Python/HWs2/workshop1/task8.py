# Нарисовать в консоли ёлку спросив
# у пользователя количество рядов.
# Пример результата:
# Сколько рядов у ёлки? 5
#     *
#    ***
#   *****
#  *******
# *********


NUM_OF_ROWS = int(input('Сколько рядов у ёлки? '))

STAR = '*'
SPACE = " "
DIVEDER = 2

SPACE_COUNT = ((NUM_OF_ROWS * DIVEDER) - DIVEDER) // DIVEDER
STARS_COUNT = 1
for i in range(NUM_OF_ROWS):
    print(SPACE * (SPACE_COUNT - i)
          + STAR * (STARS_COUNT + DIVEDER * i)
          + SPACE * (SPACE_COUNT - i))
