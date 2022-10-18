def render_menu(context=None):
    for i in range(0, len(context)):
        print(f'{list(context.keys())[i]} - {list(context.values())[i]}')
