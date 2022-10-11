str = input().upper().split('О')
res = max(str, key=len)
print(len(res))
