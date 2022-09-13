pth = 'file.txt'

work = 1
lists = [-4, -3, -2, -1, 0, 1, 2, 3, 4]



def SetFile(lists, path):
    for ls in lists:
        with open(path, 'a') as f:
            f.write(str(f'{ls}\n'))

def GetFileIndex(digit, path):
    
    with open(path, 'r') as f:
        fl = f.readlines()
    return int(fl[digit])



digits = input("Вветите список чисел").split(' ')

SetFile(lists, pth)

