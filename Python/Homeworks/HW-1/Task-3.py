lists = \
    [
        [5, 5],
        [-3, 7],
        [4, -8],
        [-6, -5]
    ]

for ls in lists:
    x, y = ls
    if x > 0 > y:
        print(f' {x}, {y} - 4 четверть')
    elif x > 0 < y:
        print(f' {x}, {y} - 1 четверть')
    elif x < 0 < y:
        print(f' {x}, {y} - 2 четверть')
    elif x < 0 > y:
        print(f' {x}, {y} - 3 четверть')