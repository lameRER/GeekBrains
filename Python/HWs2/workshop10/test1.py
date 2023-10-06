# MRO https://habr.com/ru/articles/62203/

class A:
    def __init__(self):
        print('Init class A')
        self.data_a = 'A'


class B:
    def __init__(self):
        print('Init class B')
        self.data_b = 'B'


class C:
    def __init__(self):
        print('Init class C')
        self.data_c = 'C'


class D:
    def __init__(self):
        print('Init class D')
        self.data_d = 'D'


class X1(A, C):
    def __init__(self):
        print('Init class X1')
        super().__init__()


class X2(B, D):
    def __init__(self):
        print('Init class X2')
        super().__init__()


class X3(A, D):
    def __init__(self):
        print('Init class X3')
        super().__init__()


class Z(X1, X2, X3):
    def __init__(self):
        print('Init class Z')
        super().__init__()
        print(*Z.mro(), sep='\n')


z = Z()
print(f'{z.data_b = }')
# print(f'{z.data_a = }')
