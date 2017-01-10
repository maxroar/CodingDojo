def ten_scores():
    for num in range(0,10):
        val = int(input('Please enter the test score: '))
        if val >= 90:
            print('Your grade is A.')
        elif val >= 80:
            print('Your grade is B.')
        elif val >= 70:
            print('Your grade is C.')
        elif val >= 60:
            print('Your grade is D.')
        else:
            print('Go back to school, fool.')
    print('Exiting the program... Goodbye.')

ten_scores()
