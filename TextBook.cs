using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5_JyothiLokesh
{
    class TextBook : Book, IRenewable
    {
        private int edition;

        public TextBook(string bookTitle, string bookAuthor, int edition, int id): base(bookTitle, bookAuthor, id)
        {
            this.edition = edition;
        }

        public override DateTime FindDueDate()
        {
            DateTime today = DateTime.Now;
            today = today.AddDays(30);
            return today;
        }

        public bool Renew()
        {
            if(this.c!=null){
                dueDate = FindDueDate();
                dueDate = dueDate.AddDays(15);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string s = String.Format("  Edition: {0}",edition);
            return base.ToString()+s;
        }

    }
}
