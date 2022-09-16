lst = [int(i) for i in input('Введите список чисел: ').split()]
lstSum = 0
for k, l in enumerate(lst):
    if k % 2:
        lstSum += l
print(lstSum)
        
