class Bike(object):

    def __init__(self, price, max_speed):
        self.price = price
        self. max_speed = max_speed
        self.miles = 0
    def displayInfo(self):
        print('Price: $%d' % self.price)
        print('Max Speed: %d MPH' % self.max_speed)
        print('Miles: %d' % self.miles)
    def ride(self):
        print("Riding...")
        self.miles += 10
        return self
    def reverse(self):
        print('Reversing...')
        self.miles -= 5
        return self

blueBike = Bike(300, 30)
redBike = Bike(200, 20)
awesomeBike = Bike(750, 88)

blueBike.ride().ride().ride().reverse().displayInfo()

redBike.ride().ride().reverse().reverse().displayInfo()

awesomeBike.reverse().reverse().reverse().displayInfo()
