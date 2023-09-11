# ✔ Дорабатываем функции из предыдущих задач.
# ✔ Генерируйте файлы в указанную директорию — отдельный параметр функции.
# ✔ Отсутствие/наличие директории не должно вызывать ошибок в работе функции
# (добавьте проверки).
# ✔ Существующие файлы не должны удаляться/изменяться в случае совпадения имён.

import os
import random


class FileManager:
    def __init__(self, directory):
        self.directory = directory
        self.name = generate_name()
        self.file_path = os.path.normpath(
            os.path.join(self.directory, self.name))

    def generate_file(self):
        if not os.path.exists(self.file_path):
            with open(self.file_path + ".txt", 'w') as f:
                f.write('This is a generated file.')
        else:
            print('File already exists.')

    def check_file(self, name):
        file_path = os.path.normpath(os.path.join(self.directory, name))
        if os.path.exists(file_path):
            print('File exists.')
        else:
            print('File does not exist.')

    def update_file(self, old_name, new_name):
        old_path = os.path.normpath(os.path.join(self.directory, old_name))
        new_path = os.path.normpath(os.path.join(self.directory, new_name))
        if os.path.exists(old_path):
            if not os.path.exists(new_path):
                os.rename(old_path, new_path)
                print('File renamed.')
            else:
                print('New file name already exists.')
        else:
            print('File does not exist.')

    def delete_file(self, name):
        file_path = os.path.normpath(os.path.join(self.directory, name))
        if os.path.exists(file_path):
            os.remove(file_path)
            print('File deleted.')
        else:
            print('File does not exist.')


def generate_name():
    vowels = ['а', 'е', 'ё', 'и', 'о', 'y', 'ы', 'э', 'ю', 'я']
    length = random.randint(4, 7)
    name = ''
    for i in range(length):
        if i == 0:
            name += random.choice('АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ')
        else:
            name += random.choice('абвгдеёжзийклмнопрстуфхцчшщъыьэюя')
    if not any(v in name for v in vowels):
        return generate_name()
    return name

# Чтобы все работало нормально, лучше методы выбирать по очереди
# и внимательно смотреть какие аргументы туда передаются.


file_manager = FileManager(r'C:\Users\Nata\Prog\Python2\workshop10')
file_manager.generate_file()
file_manager.check_file('Эрэжбх.txt')
file_manager.update_file('Нтпящ.txt', 'new.txt')
file_manager.delete_file('Цбвшэшю.txt')
