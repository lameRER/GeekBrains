class View:

    def __init__(self, controller):
        self.controller = controller

    def menu(self):
        print("Привет!")
        while True:
            num = input("Введите число: ")
            result = self.controller.logic(num)
            if result is not None:
                break
        print(result)
