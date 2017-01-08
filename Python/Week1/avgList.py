a = [1, 2, 5, 10, 255, 3]

def avgList(list):
    total = 0
    for num in list:
        total += num
    return float(total/len(list))

print(avgList(a))
