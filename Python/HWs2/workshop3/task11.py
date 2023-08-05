# Создайте словарь со списком вещей для похода в качестве
# ключа и их массой в качестве значения. Определите какие
# вещи влезут в рюкзак передав его максимальную
# грузоподъёмность. Достаточно вернуть один допустимый вариант.
# *Верните все возможные варианты комплектации рюкзака.


def fill_backpack(items, max_weight):
    sorted_items = sorted(items.items(),
                          key=lambda x: -x[1],
                          reverse=True)
    backpack = {}

    for k, v in sorted_items:
        if v <= max_weight:
            backpack.update({k: v})
            max_weight -= v
    return backpack


items = {'палатка': 4, 'спальник': 2, 'еда': 3, 'вода': 1}
max_weight = 7
print(*fill_backpack(items, max_weight))


# Для возврата всех возможных вариантов можно использовать рекурсию:
def fill_backpacks(backpack, remaining_weight, index, sorted_items, backpacks):
    if remaining_weight == 0 or index == len(sorted_items):
        backpacks.append(backpack)
        return
    item, weight = sorted_items[index]
    if weight <= remaining_weight:
        fill_backpacks(backpack + [(item, weight)], remaining_weight - weight,
                       index + 1, sorted_items, backpacks)
    fill_backpacks(backpack, remaining_weight,
                   index + 1, sorted_items, backpacks)


items = {'палатка': 4, 'спальник': 2, 'еда': 3, 'вода': 1}
max_weight = 7
sorted_items = sorted(items.items(), key=lambda x: -x[1], reverse=True)
backpacks = []
fill_backpacks([], max_weight, 0, sorted_items, backpacks)
for backpack in backpacks:
    print(*backpack)
