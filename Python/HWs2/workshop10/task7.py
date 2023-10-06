# Задача 2. Доработаем задания 5-6. Создайте класс-фабрику.
# - Класс принимает тип животного (название одного из созданных классов)
# и параметры для этого типа.
# - Внутри класса создайте экземпляр на основе
# переданного типа и верните его из класса-фабрики.


class Animal:
    def __init__(self, name):
        self.name = name

    def info(self):
        print("Я животное, меня зовут", self.name)


class Fish(Animal):
    def __init__(self, name, habitat):
        super().__init__(name)
        self.habitat = habitat

    def info(self):
        print("Я рыба, меня зовут", self.name, "и я обитаю в", self.habitat)


class Bird(Animal):
    def __init__(self, name, wingspan):
        super().__init__(name)
        self.wingspan = wingspan

    def info(self):
        print("Я птица, меня зовут", self.name,
              "и мой размах крыльев составляет", self.wingspan, "см")


class Mammal(Animal):
    def __init__(self, name, diet):
        super().__init__(name)
        self.diet = diet

    def info(self):
        print("Я млекопитающее, меня зовут",
              self.name, "и я питаюсь", self.diet)


class Farm:
    @staticmethod
    def create_animal(type_animal, name, feature):
        match type_animal.lower():
            case "fish" | "рыба":
                return Fish(name, feature)
            case "bird" | "птица":
                return Bird(name, feature)
            case "mammal" | "млекопитающее":
                return Mammal(name, feature)
            case _:
                return Animal(name)


created_animal = Farm.create_animal(*[i for i in input("Введите через пробел: тип, имя, особенность животного\n").split()])
created_animal.info()
