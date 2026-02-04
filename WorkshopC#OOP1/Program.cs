namespace WorkshopC_OOP1
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Animal myAnimal = new Animal();
            //myAnimal.Name = "Leo";
            //myAnimal.Species = "Lejon";
            //myAnimal.Age = 5;

            //Console.WriteLine($"{myAnimal.Name} är ett {myAnimal.Species} och är {myAnimal.Age} år gammal");

            Animal myAnimal = new Animal("Simba", "Lejon", 5);
            myAnimal.PrintInfo();
        }
    }
}
