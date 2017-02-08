using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Human max = new Human("Max");
            System.Console.WriteLine(max.name);
            Human pleb = new Human("Plebby", 1, 1, 1, 50);
            System.Console.WriteLine(pleb.health);
            max.attack(pleb);
            System.Console.WriteLine(pleb.health);
            Wizard blake = new Wizard("Blake");
            System.Console.WriteLine(blake.health);
            blake.fireball(pleb);
            System.Console.WriteLine(pleb.health);
            Samurai sam = new Samurai("Sammy");
            System.Console.WriteLine(Samurai.howmany);
            Samurai pete = new Samurai("Petey");
            System.Console.WriteLine(Samurai.howmany);
        }
    }
}
