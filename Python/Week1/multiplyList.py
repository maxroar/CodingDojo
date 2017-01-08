def multiply_by(lst, mult):
    newList = []
    for num in lst:
        newList.append(num * mult)
    return newList

a = [2, 4, 10, 16]
mul = 5

print(multiply_by(a, 5))
