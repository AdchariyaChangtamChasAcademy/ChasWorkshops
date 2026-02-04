namespace WorkshopOOP3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal myDog = new Dog("Ludde");
            myDog.Speak();

            Animal myCat = new Cat("Lucifer");
            myCat.Speak();

            Animal myAnimal = new Animal("Oklart");
            myAnimal.Speak();

            List<Animal> Animals = new List<Animal>
            {
                new Dog("Pluto"),
                new Cat("Jansson"),
                new Animal("Mystery")
            };

            foreach(var animal in Animals)
            {
                animal.Speak();
            }
        }
    }
}
