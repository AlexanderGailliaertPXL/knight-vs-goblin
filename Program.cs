using System.Drawing;
using System.Threading;
using System.Text;
using System.ComponentModel.Design;


namespace spelletje
{
    internal class Program
    {
        static void printCentered(string text)
        {
            int xPostion = (Console.WindowWidth - text.Length) / 2;
            if (xPostion < 0) xPostion = 0;

            Console.SetCursorPosition(xPostion, Console.CursorTop);
            Console.WriteLine(text);
        }
        static void Main(string[] args)
        {
            
            Random random = new Random();
            int GoblinHealth = random.Next(0, 101);
            int KnightHealth = 0;
            int KnightAttack = 10;
            int GoblinAttack = random.Next(5,16);
            int healOrAttack;
            string endMessage ="";


            bool isCorrect;

            Console.ForegroundColor = ConsoleColor.White;
            printCentered("");
            printCentered("knight");
            printCentered("  vs  ");
            printCentered("goblin");
            printCentered("");
            Console.ResetColor();
            Console.WriteLine();
            Thread.Sleep(3000);
            /* 
            pauzeert 3 seconden voor clearing scherm 1000=1seconden               
            */
            Console.Clear();
            do
            {
                Console.Write("enter the healthpoints for your knight: ");
                isCorrect = int.TryParse(Console.ReadLine(), out KnightHealth) && KnightHealth >= 0 && KnightHealth <= 100;

                if (!isCorrect)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid number between 0 and 100! ");
                    Console.ResetColor();                  
                    Console.WriteLine("");

                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.WriteLine($"input correct you knighthealth is saved as: {KnightHealth} healthpoints. ");
                    Console.ResetColor();
                    Console.WriteLine("");


                }
            } while (!isCorrect);
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"knighthealth: {KnightHealth}");
            Console.WriteLine($"goblinhealth: {GoblinHealth}");
            Console.ResetColor();

            Console.WriteLine("choose your next move carefully:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1.Attack");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("2.heal");
            Console.ResetColor();
            
            int.TryParse(Console.ReadLine(), out healOrAttack);

            switch (healOrAttack)
            {
                case 1://attack
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"you attacked the goblin for 10 damage!");
                    Console.ResetColor();
                    GoblinHealth = GoblinHealth - KnightAttack;
                    break;

                case 2: //heal
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"you healed yourself for 10 points.");
                    Console.ResetColor();
                    KnightHealth = KnightHealth + 10;
                    break;

                default: //bij foute ingave 
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("wrong input lowering health by 5 points!");
                    Console.ResetColor();
                    KnightHealth = KnightHealth - 3;
                    break;
            }
            Console.WriteLine($"you were attacked by the goblin for {GoblinAttack} damage ");
            KnightHealth = KnightHealth - GoblinAttack;


            Console.WriteLine($"current health knight: {KnightHealth}");
            Console.WriteLine($"current health goblin: {GoblinHealth}");
            
            if (KnightHealth <= 0 && GoblinHealth <= 0)
            {
                endMessage = "gelijkspel beide zijn dood ";
            }
            else if (KnightHealth <= 0)
            {
                endMessage = "you lost!";
            }
            else if (GoblinHealth <= 0 )
            {
                endMessage = "you win goblins dead";
            }

            Console.WriteLine($"{endMessage}");
            
            
            

        }
    }
}
