a = [1, 2, 5, 10, 255, 3]

def printSum(list):
    total = 0
    for num in list:
        total += num
    return total

print(printSum(a))
