from controller.controller import get_controller


def main():
    state = (None, None)
    while True:
        contoller = get_controller(state[0])
        state = contoller()


if __name__ == '__main__':
    main()
