user_input = input().upper().split('О')
res = max(user_input, key=len)
print(len(res))
