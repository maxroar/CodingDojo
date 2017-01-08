from random import randint

def toss(toss_num):
    headcount = 0 #tracks total heads
    tailcount = 0 #you already know
    for num in range(1, toss_num+1):
        result = randint(0,1)
        if result == 0:
            outcome = 'heads'
            headcount += 1
        else:
            outcome = 'tails'
            tailcount += 1
        print('Attempt #%d: Throwing coin... It\'s %s! Got %d heads so far and %d tails so far.' % (num, outcome, headcount, tailcount))
    print('Ending the program... goodbye.')

toss(5000)
