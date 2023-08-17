# Создайте файл, в котором вы импортируете встроенные в модуль функции
# под псевдонимами. (3-7 строк импорта)

import math as m
import random as r
from datetime import datetime as dt, timedelta as td

print(m.sqrt(25))
print(r.randint(1, 10))
now = dt.now()
print(now)
tomorrow = now + td(days=1)
print(tomorrow)
