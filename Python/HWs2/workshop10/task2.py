# Создайте класс прямоугольник.
# Класс должен принимать длину и ширину при создании
# экземпляра.
# У класса должно быть два метода, возвращающие периметр
# и площадь.
# Если при создании экземпляра передаётся только одна
# сторона, считаем что у нас квадрат.


class Rectangle:

    def __init__(self, length, width=None):
        if width is None:
            self.length = length
            self.width = length
        else:
            self.length = length
            self.width = width

    def perimeter(self):
        return 2 * (self.length + self.width)

    def area(self):
        return self.length * self.width


rectangle1 = Rectangle(5, 10)
print("Периметр прямоугольника:", rectangle1.perimeter())
print("Площадь прямоугольника:", rectangle1.area())

rectangle2 = Rectangle(7)
print("Периметр квадрата:", rectangle2.perimeter())
print("Площадь квадрата:", rectangle2.area())
