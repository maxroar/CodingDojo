def Main():
    class Animal(object):
        def __init__(self):
            self.name = 'Animal'
            self.health = 100
        def walk(self):
            self.health -= 1
            return self
        def run(self):
            self.health -= 5
            return self
        def displayHealth(self):
            print('Name: %s' % self.name)
            print('Health: %d' % self.health)

    animal = Animal()
    animal.walk().walk().walk().run().run().displayHealth()

    class Dog(Animal):
        def __init__(self):
            super(Dog, self).__init__()
            self.health = 150
            self.name = 'Dog'
        def pet(self):
            self.health += 5
            return self

    dog = Dog()
    dog.walk().walk().walk().run().run().pet().displayHealth()

if __name__ == '__main__':
    Main()
