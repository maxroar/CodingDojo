def draw_stars(lst):
    for item in lst:
        stars = ''
        words = ''
        if type(item) == int:
            for num in range(0, item):
                stars += '*'
            print(stars)
        elif type(item) == str:
            for num in range(0, len(item)):
                words += item[0]
            print(words)
newList = [3, 'farts']

draw_stars(newList)
