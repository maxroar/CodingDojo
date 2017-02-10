using System;

namespace ConsoleApplication
{
    public class Ninja : Human
    {
        public Ninja(string humanName) : base(humanName, 3, 3, 175, 100)
        {
            // Human wizard = new Human(humanName, 3, 25, 3, 50);
        }

        

        public void getaway(){
            health -= 15;
        }

        public void steal(Human human){
            //steals a random amount of health between 10 and 25
            Random rand = new Random();
            int healthnum = rand.Next(10,26);
            human.health -= healthnum;
            health += healthnum;
        }
    }
}
