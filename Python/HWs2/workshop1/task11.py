# Напишите код, который запрашивает число и сообщает
# является ли оно простым или составным.Используйте правило для проверки:
# «Число является простым, если делится нацело только на единицу и на себя».
# Сделайте ограничение на ввод отрицательных чисел и чисел больше 100 тысяч.


def prime_number():
    number = int(input("Input number: "))
    if number > 0 and number < 100000:
        for div in range(2, number):
            if number % div == 0:
                return "Composite number"
        return "Prime number"
    else:
        return "Your number is out of range"


print(prime_number())
