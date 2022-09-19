n = 8
fib = [0, 1]
for i in range(2, n + 1):
    fib.append(fib[-1] + fib[-2])
for i in range(n):
    fib = [fib[1] - fib[0]] + fib
print(fib)