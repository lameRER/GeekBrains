# Напишите класс для хранения информации о человеке:
# ФИО, возраст и т.п. на ваш выбор.
# У класса должны быть методы birthday для увеличения
# возраста на год, full_name для вывода полного ФИО и т.п. на
# ваш выбор.
# Убедитесь, что свойство возраст недоступно для прямого
# изменения, но есть возможность получить текущий возраст.

class Person:
    def __init__(self, first_name, last_name, age):
        self.first_name = first_name
        self.last_name = last_name
        self._age = age

    def birthday(self):
        self._age += 1

    @property
    def full_name(self):
        return self.first_name + " " + self.last_name

    @property
    def age(self):
        return self._age


person1 = Person("Иван", "Иванов", 25)
print("ФИО:", person1.full_name())
print("Возраст:", person1.age)

person1.birthday()
print("Новый возраст:", person1.age)
