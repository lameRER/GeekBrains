# Создайте несколько переменных заканчивающихся и не оканчивающихся на «s».
# Напишите функцию, которая при запуске заменяет содержимое переменных
# оканчивающихся на s (кроме переменной из одной буквы s) на None.
# Значения не удаляются, а помещаются в одноимённые переменные без s на конце.

s1 = "hello"
s2s = "worlds"
s3s = "python"
s = "s"


def replace_s():
    for name, value in list(globals().items()):
        if name.endswith('s') and len(name) > 1:
            new_name = name[:-1]
            globals()[new_name] = value
            globals()[name] = None


replace_s()

print(s1)
print(s2s)
print(s3s)
print(s)
