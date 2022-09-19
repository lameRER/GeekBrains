from random import randint

def Mixing(sp):
    for s in range(0, len(sp)-1):
        a = sp[s]
        sp.pop(s)
        sp.insert(randint(0, len(sp)), a)
    return sp

lists = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
print(Mixing(lists))
