using System;

namespace ConsoleApplication
{
    public class Human
    {
            public string name;
            public int strength;
            public int intelligence;
            public int dexterity;
            public int health;
        public Human(string humanName)
        {
            name = humanName;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
        }

        public Human(string humanName, int humanStrength, int humanIntelligence, int humanDexterity, int humanHealth)
        {
            name = humanName;
            strength = humanStrength;
            intelligence = humanIntelligence;
            dexterity = humanDexterity;
            health = humanHealth;
        }

        public void attack(Human human){
            human.health -= 5*strength;

        }
    }
}
