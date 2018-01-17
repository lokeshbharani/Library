using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5_JyothiLokesh
{
    class GeneralBook : Book
    {
        public GeneralBook(string title, string authors, int catalogNo) : base(title, authors, catalogNo)
        {
           
        }

        public override DateTime FindDueDate()
        {
            DateTime today = DateTime.Now;
            today = today.AddDays(7);
            return today;
        }

        
    }
}
