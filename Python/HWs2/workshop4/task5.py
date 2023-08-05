# ✔ Функция принимает на вход три списка одинаковой длины:
# ✔ имена str,
# ✔ ставка int,
# ✔ премия str с указанием процентов вида «10.25%».
# ✔ Вернуть словарь с именем в качестве ключа и суммой
# премии в качестве значения.
# ✔ Сумма рассчитывается как ставка умноженная на процент премии.


def calculate_bonus(names, rates, bonuses):
    result = {}
    for i in range(len(names)):
        bonus_percent = float(bonuses[i].strip('%')) / 100
        result[names[i]] = rates[i] * bonus_percent
    return result


print(calculate_bonus(['Алена', 'Дима', 'Света'],
                      [1000, 2000, 3000],
                      ['10%', '20.4%', "30%"]))
