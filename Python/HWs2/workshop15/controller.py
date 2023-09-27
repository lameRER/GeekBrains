class Controller:
    def __init__(self, logger) -> None:
        self.logger = logger

    def logic(self, num):
        self.logger.debug(f"Пользователь ввел: {num}")
        return self.validation(num)

    def validation(self, num):
        try:
            num = float(num)
            if num.is_integer():
                return int(num)
            else:
                return num
        except ValueError:
            self.logger.error("Ошибка! Введите число.")
            print("Ошибка! Введите число.")
