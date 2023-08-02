from model import BankAccount


class ATMController:
    def __init__(self, bankAccount: BankAccount):
        self.model = bankAccount

    def deposit(self, amount):
        self.model.deposit(amount)
        if self.model.get_balance() >= 5000000:
            self.model.apply_tax()
        return self.model.get_balance()

    def withdraw(self, amount):
        success = self.model.withdraw(amount)
        if success and self.model.get_balance() >= 5000000:
            self.model.apply_tax()
        return success, self.model.get_balance()

    def get_balance(self):
        return self.model.get_balance()
