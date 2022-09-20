n = int(input())

lst = []
work = 1

for i in range(work, n+work):
    work *= i
    lst.append(work)

print(n, lst, end=" ")
