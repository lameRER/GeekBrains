from Controller.controller import get_controller


def main():
    state = (None, None)
    while True:
        controller = get_controller(state[0])
        state = controller()


if __name__ == '__main__':
    main()
