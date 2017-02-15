using System;

namespace ConsoleApplication
{
    public class Wizard : Human
    {
        public Wizard(string humanName) : base(humanName, 3, 25, 3, 50)
        {
            // Human wizard = new Human(humanName, 3, 25, 3, 50);
        }

        

        public void heal(){
            health += 10*intelligence;
        }

        public void fireball(Human human){
            Random rand = new Random();
            human.health -= rand.Next(20,51);
        }
    }
}
