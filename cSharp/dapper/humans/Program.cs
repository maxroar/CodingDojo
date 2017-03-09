using System;

namespace ConsoleApplication
{
    public class Program
    {
        Random rand = new Random();
        public static bool ninjaescape = false;
        public static int turn = 0;
        public static bool stillTrue = true;
        
        
        public void displayAlly(){
            System.Console.WriteLine("Ally Health:");
            System.Console.WriteLine($"Ninja: {ninj.health} Samurai: {sam.health} Wizard: {wiz.health}");
            System.Console.WriteLine("Enemy Health:");
            System.Console.WriteLine($"Spider: {spider.health} Zombie: {zombie.health}");
            System.Console.WriteLine("Please choose an attack:");
            System.Console.WriteLine("Ninja: Escape ('e')");
            System.Console.WriteLine("Ninja: Steal ('s')");
            System.Console.WriteLine("Samurai: Meditate ('m')");
            System.Console.WriteLine("Samurai: Death Blow ('d')");
            System.Console.WriteLine("Wizard: Heal ('h')");
            System.Console.WriteLine("Wizard: Fireball ('f')");
        }
        public void allyAttack(){
            displayAlly();
            string InputLine = Console.ReadLine();
            string[] inputs = {"e","s", "m", "d", "h", "f"};
            bool validInput = false;
            for (int i = 0; i < inputs.Length; i++){
                if (InputLine == inputs[i]){
                    validInput = true;
                }
            }
            if (validInput == false){
                System.Console.WriteLine("Please enter a valid attack!");
                allyAttack();
            }else{
                if(InputLine == "e"){
                    ninj.escape();
                    ninjaescape = true;
                    turn++;
                }else if(InputLine == "s"){
                    ninj.steal();
                    turn++;
                }else if(InputLine == "m"){
                    sam.meditate();
                    turn++;
                }else if(InputLine == "d"){
                    sam.deathblow();
                    turn++;
                }else if(InputLine == "h"){
                    wiz.heal();
                    turn++;
                }else if(InputLine == "f"){
                    wiz.fireball();
                    turn++;
                }
            }
        }
        public void enemyAttack(){
            int enemyNum = rand.Next(0,2);
            if(ninjaescape = true){
                int allyNum = rand.Next(0,2);
            }else{
                int allyNum = rand.Next(0,3);
            }
            
            if(enemyNum == 0){
                if (allyNum == 0){
                    spider.spiderAttack(wiz);
                }else if (allyNum == 1){
                    spider.spiderAttack(sam);
                }else if (allyNum == 2){
                    spider.spiderAttack(ninj);
                }
            }else if(enemyNum == 1){
                if (allyNum == 0){
                    zombie.zombieAttack(wiz);
                }else if (allyNum == 1){
                    zombie.zombieAttack(sam);
                }else if (allyNum == 2){
                    zombie.zombieAttack(ninj);
                }
            }
            ninjaescape = false;
            turn++;
        }
        public static void gameTurns(){
            if(turn % 2 == 0){
                allyAttack();
            }else{
                enemyAttack();
            }
            if(ninj.health <= 0 && wiz.health <= 0 && sam.health <= 0){
                System.Console.WriteLine("Loser");
                stillTrue = false;
            }else if(spider.health <= 0 && zombie.health <= 0){
                System.Console.WriteLine("Winner");
                stillTrue = false;
            }else{
                stillTrue = true;
            }
        }
        public static void Main(string[] args)
        {
            Wizard wiz = new Wizard("Wiz");
            Ninja ninj = new Ninja("Ninj");
            Samurai sam = new Samurai("Sam");

            Enemy spider = new Enemy("Spider");
            Enemy zombie = new Enemy("Zombie");

            while (stillTrue == true){
                gameTurns();
            }


        }
    }
}
