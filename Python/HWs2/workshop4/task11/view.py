from controller import ATMController


class ATMView:
    def __init__(self, atmController: ATMController):
        self.controller = atmController

    def run(self):
        while True:
            print("1. Deposit")
            print("2. Withdraw")
            print("3. Balance")
            print("4. Exit")
            choice = input("Enter your choice: ")
            if choice == "1":
                amount = int(input(
                    "Enter the amount to deposit (must be a multiple of 50): "
                    ))
                if amount % 50 != 0:
                    print("Amount must be a multiple of 50")
                    continue
                balance = self.controller.deposit(amount)
                print("New balance: {}".format(balance))
            elif choice == "2":
                amount = int(input(
                    "Enter the amount to withdraw (must be a multiple of 50): "
                    ))
                if amount % 50 != 0:
                    print("Amount must be a multiple of 50")
                    continue
                success, balance = self.controller.withdraw(amount)
                if success:
                    print("New balance: {}".format(balance))
                else:
                    print("Insufficient funds")
            elif choice == "3":
                print("Balance: {}".format(self.controller.get_balance()))
            elif choice == "4":
                break
            else:
                print("Invalid choice")
