sp = [6.78, 5, 0.34]
for s in sp:
    if type(s) == float:
        print(s, '=>', int(s * 10 % 10))
    else:
        print(s, '=>', 'нет')
