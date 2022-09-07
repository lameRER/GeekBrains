Lists = \
    [
        [0, 0, 0],
        [0, 0, 1],
        [0, 1, 1],
        [1, 1, 1],
        [1, 1, 0],
        [1, 0, 0],
        [1, 0, 0],
        [0, 1, 0]
    ]
for ls in Lists:
    x, y, z = ls
    print(f'({x}, {y}, {z}) - {not (x or y or z) == (not x) and (not y) and (not z)}')
