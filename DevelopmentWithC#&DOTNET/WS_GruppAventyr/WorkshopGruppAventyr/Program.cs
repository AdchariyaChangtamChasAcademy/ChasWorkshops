using System.Collections.Generic;

namespace WorkshopGruppAventyr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayerCharacter myPlayer = new PlayerCharacter("Player", "Adventurer", 100);

            List<Character> npcList = new List<Character>()
            {
                new FriendlyCharacter("Alvi", "Elf", 100),
                new EnemyCharacter("Lorkan", "DarkElf", 100, 10),
                new FriendlyCharacter("Bob", "Human", 100),
                new EnemyCharacter("Vrarg", "Warewolf", 100, 20)
            };

            while (true)
            {
                Random rnd = new Random();
                int r = rnd.Next(npcList.Count);
                Character npc = npcList[r];

                Console.WriteLine($"You meet {npc.Name}, {npc.Type}. What do you do?");
                Console.WriteLine("1. Talk \n2. Fight \n3. Run");
                
                switch(Console.ReadLine())
                {
                    case "1":
                        npc.Talk(myPlayer);
                        break;

                    case "2":
                        npc.Fight(myPlayer);
                        break;

                    default:
                        break;
                }
                
            }
        }
    }
}
