using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5_JyothiLokesh
{
    abstract class Book
    {
        private int catalogNumber;
        private string title;
        private string authors;
        protected Customer c;
        protected DateTime dueDate;

        public abstract DateTime FindDueDate();

        public int CatalogNumber
        {
            get { return catalogNumber; }
        }

        public Book(string title, string authors, int catalogNo)
        {
            this.title = title;
            this.authors = authors;
            this.catalogNumber = catalogNo;
        }

        public bool CheckOut(Customer c)
        {
            if (this.c == null)
            {
                this.c = c;
                this.dueDate = FindDueDate();
                return true;
            }
            return false;
        }

        public bool CheckIn()
        {
            if (this.c != null)
            {
                c = null;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string s = String.Format("{0}  {1},  {2}   ", catalogNumber, title, authors);
            if (this.c != null)
            {
                s += String.Format("{0}{1} {2}  {3}", " Checked out to Customer ", c.Id," Due on ", dueDate);
            }
            else
            {
                s += String.Format("{0}"," Available");
            }
            return s;
        }

    }
}
