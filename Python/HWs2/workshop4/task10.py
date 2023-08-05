# Напишите функцию принимающую на вход только ключевые
# параметры и возвращающую словарь, где ключ — значение
# переданного аргумента, а значение — имя аргумента. Если
# ключ не хешируем, используйте его строковое представление.


def key_params_to_dict(**kwargs):
    result = {}
    for key, value in kwargs.items():
        if isinstance(key, (int, float, complex)):
            key = str(key)
        result[value] = key
    return result


result_dict = key_params_to_dict(a=1, b="hello", c=5.15, d=True)
print(result_dict)
