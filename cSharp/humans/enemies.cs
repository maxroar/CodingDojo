using System;

namespace ConsoleApplication
{
    public class Enemy : Human
    {
        Random rand = new Random();
        public Enemy(string humanName) : base(humanName, 3, 3, 3, 200)
        {
            // Human enemy = new Human(humanName, 3, 25, 3, 50);
        }

        

        public void zombieAttack(Human human){
            
            int healthnum = rand.Next(10,25);
            human.health -= healthnum;
            health += 5;
        }

        public void spiderAttack(Human human){
            //steals a random amount of health between 10 and 25
            int healthnum = rand.Next(10,25);
            human.health -= healthnum;
            health += healthnum;
        }
    }
}
