namespace WorkshopTeamAnimalDuel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AnimalFactory Factory = new AnimalFactory();
            List<Animal> Animals = new List<Animal>();

            Animals.Add(new Elephant());
            Animals.Add(new Tiger());
            Animals.Add(new Fox());

            Animals[0].Duel(Animals[1]);
            Animals[1].Duel(Animals[2]);
            Animals[2].Duel(Animals[0]);
        }
    }
}
