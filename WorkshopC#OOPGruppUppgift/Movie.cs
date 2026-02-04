using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopC_OOPGruppUppgift
{
    public class Movie
    {
        //## Uppgift i team 2
        //Skapa en klass Movie med egenskaperna Title, Genre, och Rating.
        //Lägg till en metod IsRecommended() som returnerar true om betyget är över 7.

        //### Utmaning:
        //Använd inkapsling för att säkerställa att betyget är mellan 1 och 10.

        //### Diskussionsfråga:
        //Hur kan metoder i en klass bidra till att göra koden mer återanvändbar ?

        public string Title;
        public string Genre;

        private int rating;

        public int Rating
        {
            get { return rating; }
            set 
            { 
                if(value >= 1 && value <= 10)
                {
                    rating = value;
                }
            }
        }

        public bool IsRecommended()
        {
            if (rating > 7)
            {
                return true;
            }
            else if(rating <= 7)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
