class BankAccount:
    def __init__(self):
        self.balance = 0
        self.operations_count = 0

    def deposit(self, amount):
        self.balance += amount
        self.operations_count += 1
        if self.operations_count % 3 == 0:
            self.balance *= 1.03

    def withdraw(self, amount):
        if amount > self.balance:
            return False
        else:
            self.balance -= amount
            self.operations_count += 1
            if self.operations_count % 3 == 0:
                self.balance *= 1.03
            fee = amount * 0.015
            if fee < 30:
                fee = 30
            elif fee > 600:
                fee = 600
            self.balance -= fee
            return True

    def get_balance(self):
        return self.balance

    def apply_tax(self):
        if self.balance >= 5000000:
            self.balance *= 0.9
