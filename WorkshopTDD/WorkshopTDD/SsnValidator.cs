namespace WorkshopTDD
{
    public class SsnValidator
    {
        public bool IsValid(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length != 10 || !input.All(char.IsDigit)) 
                return false;
            else
                return true;
        }
    }
}
