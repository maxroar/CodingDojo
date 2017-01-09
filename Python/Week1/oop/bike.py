class Bike(object):

    def __init__(self, price, max_speed):
        self.price = price
        self. max_speed = max_speed
        self.miles = 0
    def displayInfo(self):
        print('Price: $%d' % self.price)
        print('Max Speed: %d MPH' % self.max_speed)
        print('Miles: %d' % self.miles)
    def ride(self, times):
        if times <=0:
            times = 1
        for rides in range(0, times):
            print("Riding...")
            self.miles += 10
    def reverse(self, times):
        if times <=0:
            times = 1
        for rides in range(0, times):
            print('Reversing...')
            self.miles -= 5

blueBike = Bike(300, 30)
redBike = Bike(200, 20)
awesomeBike = Bike(750, 88)

blueBike.ride(3)
blueBike.reverse(1)
blueBike.displayInfo()

redBike.ride(2)
redBike.reverse(2)
redBike.displayInfo()

awesomeBike.reverse(3)
awesomeBike.displayInfo()
