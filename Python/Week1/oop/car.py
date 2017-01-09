def Main():
    class Car(object):

        def displayAll(self):
            print('Price: $%d' % self.price)
            print('Speed: %d MPH' % self.speed)
            print('Fuel: %s' % self.fuel)
            print('Mileage: %d MPG' % self.mileage)
            print('Tax: %f' % self.salesTax)
        def __init__(self, price, speed, fuel, mileage,salesTax=0.12):
            if price > 10000:
                salesTax = 0.15
            self.price = price
            self.speed = speed
            self.fuel = fuel
            self.mileage = mileage
            self.salesTax = salesTax
            self.displayAll()

    lambo = Car(350000, 180, 'None', 15, .14)
    fiesta = Car(10000, 90, 'Full', 38)
    gti = Car(33000, 135, 'Half', 25)
    prius = Car(37000, 95, 'Full', 52)
    escalade = Car(58000, 112, 'None', 20)

if __name__ == "__main__":
    Main()
