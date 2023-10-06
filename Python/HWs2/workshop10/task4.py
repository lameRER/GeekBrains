# Создайте класс Сотрудник.
# Воспользуйтесь классом человека из прошлого задания.
# У сотрудника должен быть:
# ○ шестизначный идентификационный номер
# ○ уровень доступа вычисляемый как остаток от деления
# суммы цифр id на семь


from task3 import Person


class Worker(Person):
    def __init__(self, first_name, second_name, age, id_number):
        super().__init__(first_name, second_name, age)
        self.id_number = id_number

    @property
    def access_level(self):
        return sum(int(digit) for digit in str(self.id_number)) % 7


worker = Worker("Иван", "Иванов", 25, 123456)
print(worker.full_name)
print(worker.age)
print(worker.id_number)
print(worker.access_level)
