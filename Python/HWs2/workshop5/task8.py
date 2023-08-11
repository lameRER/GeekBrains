# Напишите функцию, которая принимает на вход строку —
# абсолютный путь до файла. Функция возвращает кортеж из трёх
# элементов: путь, имя файла, расширение файла.

def parse_filename(path):
    """
    Функция для парсинга имени файла из абсолютного пути.
    :param path: абсолютный путь до файла
    :return: кортеж из трех элементов: путь, имя файла, расширение файла
    """
    import os
    filename = os.path.basename(path)
    name, extension = os.path.splitext(filename)
    directory = os.path.dirname(path)
    return directory, name, extension


path = r'/home/sasha/develop/GeekBrains/Python/HWs2/workshop5/test.txt'
directory, name, extension = parse_filename(path)
print('Directory:', directory)
print('Name:', name)
print('Extension:', extension)
