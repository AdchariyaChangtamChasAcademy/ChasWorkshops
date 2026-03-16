using System.ComponentModel.DataAnnotations;

namespace WS_AsyncPaging.Exeptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {

        }
    }
}
