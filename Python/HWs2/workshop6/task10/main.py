from portfolio import Portfolio


stocks = {"AAPL": 10, "GOOGL": 5, "MSFT": 8}
prices = {"AAPL": 150.25, "GOOGL": 2500.75, "MSFT": 300.50}

while True:

    print("Welcome to the Portfolio Management System!")
    print("Choose an option:")
    print("1. Calculate current portfolio value")
    print("2. Calculate portfolio return")
    print("3. Get most profitable stock")
    print("4. Exit")

    option = int(input("Enter your choice: "))

    portfolio = Portfolio(stocks, prices)

    match option:
        case 1:
            current_portfolio_value = portfolio.calculate_portfolio_value()
            print(f"Current portfolio value: ${current_portfolio_value:.2f}")
        case 2:
            current_portfolio_value = float(input(
                "Enter current portfolio value: "))
            portfolio_return = portfolio.calculate_portfolio_return(
                    current_portfolio_value)
            print(f"Portfolio return: {portfolio_return}")
        case 3:
            most_profitable_stock = portfolio.get_most_profitable_stock()
            print(f"Most profitable stock: {most_profitable_stock}")
        case 4:
            break
        case _:
            print("Invalid option selected. Please try again.")
