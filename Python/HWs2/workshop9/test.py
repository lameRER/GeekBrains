from typing import Callable


def main(x: int) -> Callable[[int], dict[int, int]]:
    d = {}

    def loc(y: int) -> dict[int, int]:
        for i in range(y):
            d[i] = x ** i
            return d
    return loc


small = main(42)
big = main(73)

print(small(7))
print(big(7))
print(small(3))
