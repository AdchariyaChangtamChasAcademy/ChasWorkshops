namespace UppgiftLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryClasses.Library myLibrary = new LibraryClasses.Library();
            myLibrary.RunLibrary();

            ProductOrder.Store myStore = new ProductOrder.Store();
            myStore.RunStore();

            StudentGrades.Grading myGrading = new StudentGrades.Grading();
            myGrading.RunGrading();
        }
    }
}
