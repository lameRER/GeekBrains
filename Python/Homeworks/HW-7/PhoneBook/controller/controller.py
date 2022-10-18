from view.view import render_menu


def default_controller():
    render_menu(menu_dict)
    return (input())


def search_controller():
    pass


def import_file_controller():
    pass


def export_file_controller():
    pass


def exit_controller():
    exit()


def get_controller(state):
    return contollers_dict.get(state, default_controller)


contollers_dict = {
    '1': search_controller,
    '2': import_file_controller,
    '3': export_file_controller,
    '4': exit_controller
}

menu_dict = {
    1: 'Поиск контакта',
    2: 'Импорт файла',
    3: 'Экспорт файла',
    4: 'Выход из програмы'
}
