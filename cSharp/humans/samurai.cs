using System;

namespace ConsoleApplication
{
    public class Samurai : Human
    {

        public static int howmany = 0;
        public Samurai(string humanName) : base(humanName, 3, 3, 3, 200)
        {
            // Human wizard = new Human(humanName, 3, 25, 3, 50);
            howmany++;
        }


        public void meditate(){
            health = 200;
        }

        public void deathblow(Human human){
            //deals a random amount of damage between 20 and 50. if enemy has 50 health or less then it instant kills
            if (human.health < 51){
                human.health = 0;
            }else{
                Random rand = new Random();
            int healthnum = rand.Next(20,51);
            human.health -= healthnum;
            }
        }
    }
}
