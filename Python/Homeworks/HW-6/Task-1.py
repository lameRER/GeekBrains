user_Input = input().upper().split('О')
res = max(user_Input, key=len)
print(len(res))
