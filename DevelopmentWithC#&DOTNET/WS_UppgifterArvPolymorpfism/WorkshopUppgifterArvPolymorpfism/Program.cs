using WorkshopUppgifterArvPolymorpfism.Products;

namespace WorkshopUppgifterArvPolymorpfism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            //Car myCar = new Car(300, "Bensin");
            //myCar.Describe();

            //Bicycle myBicycle = new Bicycle(25, "Man power");
            //myBicycle.Describe();

            //Vehicle myVehicle = new Vehicle(0, "Mystery");
            //myVehicle.Describe();
            */
            /*
            //Electronic myElectronic = new Electronic("Dator", 10000);
            //myElectronic.GetProductInformation();

            //Book myBook = new Book("Novell", 200, "Astrid Lindgren");
            //myBook.GetProductInformation();

            //Clothing myClothing = new Clothing("Tröja", 500, "Bomull");
            //myClothing.GetProductInformation();

            //Jacket myJacket = new Jacket("Vinterjacka", 2000, "Ull");
            //myJacket.GetProductInformation();
            */

            AnimalPark myAnimalPark = new AnimalPark();

            myAnimalPark.addAnimal(new Tiger("Lars", 23));
            myAnimalPark.addAnimal(new Panda("KungFu", true));
            myAnimalPark.addAnimal(new Wolf("Jan", 8));

            myAnimalPark.printAllAnimals();
        }
    }
}