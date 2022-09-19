digitList = [1, 23, 5, 3465, 476, 878, 769, 8797, 1, 3, 4, 5, 66, 75, 55, 77, 88, 88, 11]
unique = []
for d in digitList:
    if d in unique:
        continue
    else:
        unique.append(d)
print(digitList)
print(unique)
