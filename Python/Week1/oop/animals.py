def Main():
    class Animal(object):
        def __init__(self, name):
            self.type = 'Animal'
            self.health = 100
            self.name = name
        def walk(self):
            self.health -= 1
            return self
        def run(self):
            self.health -= 5
            return self
        def displayHealth(self):
            print('Name: %s' % self.name)
            print('Health: %d' % self.health)

    animal = Animal('fred')
    animal.walk().walk().walk().run().run().displayHealth()

    class Dog(Animal):
        def __init__(self, name):
            super(Dog, self).__init__(name)
            self.health = 150
            self.type = 'Dog'
            self.name = name
        def pet(self):
            self.health += 5
            return self
        def display_dog(self):
            print('This is a dog:')
            super(Dog, self).displayHealth()

    dog = Dog('fido')
    dog.walk().walk().walk().run().run().pet().display_dog()

if __name__ == '__main__':
    Main()
