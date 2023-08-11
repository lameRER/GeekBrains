# Возьмите задачу о банкомате из семинара 2. Разбейте её на отдельные операции — функции. Дополнительно сохраняйте все операции поступления и снятия средств в список.

from model import BankAccount
from controller import ATMController
from view import ATMView


def main():
    model = BankAccount()
    controller = ATMController(model)
    view = ATMView(controller)
    view.run()


main()
