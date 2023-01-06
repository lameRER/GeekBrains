import json
from View.view import *
from Model.phonebook import PhoneBook
import json

ls = []


def default_controller():
    return (render_menu(menu_dict))


def search_controller():
    st = render_message_input("Введите фамилию: ")
    for i in range(0, len(PhoneBook.items)):
        if st in PhoneBook.items[i].lastName:
            render_message(PhoneBook.items[i].__dict__)
    return (None, None)


def import_file_controller():
    res = ''
    with open('data.json', 'r') as f:
        res = f.read()
    for i in json.loads(res):
        p = PhoneBook(i['lastName'], i['firstName'], i['parthName'], i['phone'])
        ls.append(p)
    return (None, None)


def export_file_controller():
    ls = []
    for i in PhoneBook.items:
        ls.append(i.__dict__)
    x = json.dumps(ls, sort_keys=True, indent=4)
    with open('data.json', 'w') as f:
        f.write(x)
    return (None, None)


def create_new_contact_controller():
    contact = PhoneBook(render_message_input("Введите Фамилию:"), render_message_input("Введите имя:"), render_message_input("Введите отчество:"), render_message_input("Введите телефон:"))
    ls.append(contact.__dict__)
    render_message(contact.__dict__)
    return(None, None)


def exit_controller():
    exit()


def get_controller(state):
    return controllers_dict.get(state, default_controller)


controllers_dict = {
    '1': search_controller,
    '2': import_file_controller,
    '3': export_file_controller,
    '4': create_new_contact_controller,
    '5': exit_controller
}

menu_dict = {
    1: 'Поиск контакта',
    2: 'Импорт файла',
    3: 'Экспорт файла',
    4: 'Добавить новый контакт',
    5: 'Выход из програмы'
}
