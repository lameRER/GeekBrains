# В модуль с проверкой даты добавьте возможность запуска
# в терминале с передачей даты на проверку.

def is_leap_year(year):
    if year % 4 != 0:
        return False
    elif year % 100 != 0:
        return True
    elif year % 400 != 0:
        return False
    else:
        return True


def check_date(date_str):
    try:
        day, month, year = map(int, date_str.split("."))
        if year < 1 or year > 9999:
            return False
        if month < 1 or month > 12:
            return False
        if month == 2:
            if is_leap_year(year):
                if day < 1 or day > 29:
                    return False
            else:
                if day < 1 or day > 28:
                    return False
        elif month in [4, 6, 9, 11]:
            if day < 1 or day > 30:
                return False
        else:
            if day < 1 or day > 31:
                return False
        return True
    except ValueError:
        return False


if __name__ == "__main__":
    import sys
    date_str = sys.argv[1]
    if check_date(date_str):
        print("Date is valid")
    else:
        print("Date is invalid")
