n = int(input("Введите число: "))
lst = []
for i in range(1, n+1):
    fld = round((1 + (1/i))**i, 3)
    lst.append(fld)
print("sum:", sum(lst), "=", lst)
