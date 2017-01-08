def odd_or_even():
    for num in range(1, 1001):
        if num % 2 != 0:
            print('Number is %d. This is an odd number.' % num)
        else:
            print('Number is %d. This is an even number.' % num)
odd_or_even()
