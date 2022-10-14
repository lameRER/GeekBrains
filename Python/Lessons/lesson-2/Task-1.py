sp = [1, 2, 4 ,5 ,4, 6, 2, 3]
ls = []
d = 0
for i in sp:
    if i in ls:
        d += 1
    ls.append(i)
print(f'{sp} => {d}')
