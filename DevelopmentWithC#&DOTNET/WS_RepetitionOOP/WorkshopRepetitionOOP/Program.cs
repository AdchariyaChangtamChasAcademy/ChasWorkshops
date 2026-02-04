namespace WorkshopRepetitionOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Mission> missions = new List<Mission>()
            {
                new Mission("Rädda katten Jansson", 1),
                new Mission("Stoppa tjuvarna  i juvelerarbutiken", 2),
                new Mission("Släcka skogsbranden", 3)
            };

            List<Hero> heroes = new List<Hero>
            {
                new Hero("Batman", "klyftighet"),
                new SuperHero("Hulken", "styrka", 4),
                new SuperHero("Spiderman", "smidighet", 2)
            };


            for(int i = 0; i < heroes.Count; i++)
            {
                missions[i].Describe();
                heroes[i].PerformMission(missions[i]);
                heroes[i].Rest();
                Console.WriteLine();
            }

            Console.WriteLine("Alla uppdrag är uppförda!");
        }
    }
}
