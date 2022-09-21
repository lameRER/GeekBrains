sp = [1, 2, 4 ,5 ,4, 6, 2, 3]
outList = []
d = 0
for i in sp:
    if i in outList:
        d += 1
    outList.append(i)
print(f'{sp} => {d}')
