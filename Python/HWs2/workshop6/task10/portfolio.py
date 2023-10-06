class Portfolio:

    def __init__(self, stocks: dict, prices: dict):
        self.stocks = stocks
        self.prices = prices
        self.__initial_portfolio_value = self.calculate_portfolio_value()

    def calculate_portfolio_value(self) -> float:
        total_value = 0
        for stock, quantity in self.stocks.items():
            total_value += quantity * self.prices[stock]
        return total_value

    def calculate_portfolio_return(self, current_value: float,
                                   initial_value: float = None) -> str:
        if initial_value is None:
            initial_value = self.__initial_portfolio_value
        return f"{((current_value - initial_value) / initial_value) * 100:.2f}%"

    def get_most_profitable_stock(self) -> str:
        most_profitable_stock = ""
        max_profit = 0
        for stock, quantity in self.stocks.items():
            profit = (
                self.prices[stock] -
                (self.__initial_portfolio_value / sum(self.stocks.values())))\
                  * quantity
            if profit > max_profit:
                max_profit = profit
                most_profitable_stock = stock
        return most_profitable_stock
