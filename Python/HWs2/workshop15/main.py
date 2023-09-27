# Создайте функцию, которая запрашивает числовые данные от
# пользователя до тех пор, пока он не введёт целое или
# вещественное число.
# Обрабатывайте не числовые данные как исключения.

import sys
from controller import Controller
from view import View
from loguru import logger


def main(logger):
    controller = Controller(logger)
    view = View(controller)
    view.menu()


if __name__ == '__main__':
    level = "ERROR"
    if len(sys.argv) == 2:
        arg = sys.argv[1].upper()
        if arg in ["INFO", "DEBUG", "ERROR", "WARNING"]:
            level = arg
    logger.remove()
    logger.add("logs.log", level=level)
    main(logger)
