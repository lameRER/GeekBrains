# ✔ Функция получает на вход словарь с названием компании в качестве ключа
# и списком с доходами и расходами (3-10 чисел) в качестве значения.
# ✔ Вычислите итоговую прибыль или убыток каждой компании. Если все компании
# прибыльные, верните истину, а если хотя бы одна убыточная — ложь.


def calculate_profit(companies):
    all_profitable = True

    for company, data in companies.items():
        profit = sum(data) - data[0] - data[-1]
        if profit < 0:
            all_profitable = False
        print(f'{company}: '
              f'{"прибыль" if profit >= 0 else "убыток"} - {abs(profit)}')
    return all_profitable


print(calculate_profit({"Рога и копыта": [10, 20, 30],
                        "Лазурит": [5, 20, 40, 60]}))
