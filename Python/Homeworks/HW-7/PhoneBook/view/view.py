import os

def render_menu(context=None):
    for i in range(0, len(context)):
        print(f'{list(context.keys())[i]} - {list(context.values())[i]}')
    return input('\nВыберите пункт: ')
        

def render_message_input(context=None):
    os.system('cls||clear')
    return input(context)

def render_message(context=None):
    os.system('cls||clear')
    print(context)
    
