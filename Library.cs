using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5_JyothiLokesh
{
    class Library
    {

        private Customer[] customerArray = new Customer[5];
        private Book[] bookArray = new Book[5];

        public bool AddNewCustomer(string customerName)
        {
            for (int i = 0; i < customerArray.Length; i++)
            {
                if (customerArray[i] == null)
                {
                    customerArray[i] = new Customer(customerName, ++i);
                    return true;
                }
            }
            return false;
        }

        public bool AddNewBook(string bookTitle, string bookAuthor)
        {
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] == null)
                {
                    int id = 100 + i + 1;
                    bookArray[i] = new GeneralBook(bookTitle, bookAuthor, id);
                    return true;
                }
            }
            return false;
        }

        public bool AddNewBook(string bTitle, string bAuthor, int edition)
        {
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] == null)
                {
                    int id = 100 + i + 1;
                    bookArray[i] = new TextBook(bTitle, bAuthor, edition, id);
                    return true;
                }
            }
            return false;
        }

        public bool IssueBook(int custID, int bookCatalogNum)
        {
            int temp = 0, temp1 = 0;
            bool b = false, c = false;
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] != null)
                    if (bookArray[i].CatalogNumber == bookCatalogNum)
                    {
                        temp = i;
                        b = true;
                    }
            }
            for (int i = 0; i < customerArray.Length; i++)
            {
                if (customerArray[i] != null)
                    if (customerArray[i].Id == custID)
                    {
                        temp1 = i;
                        c = true;
                    }
            }

            if (b && c)
                return bookArray[temp].CheckOut(customerArray[temp1]);
            else
                return false;

        }

        public bool RenewBook(int bookCatalogNum)
        {
         
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] != null)
                    if (bookArray[i].CatalogNumber == bookCatalogNum && bookArray[i] is IRenewable)
                    {
                        return ((IRenewable)bookArray[i]).Renew();
                    }
            }
            return false;

        }

        public bool ReturnBook(int bookCatalogNum)
        {
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] != null)
                    if (bookArray[i].CatalogNumber == bookCatalogNum)
                    {
                        return bookArray[i].CheckIn();
                    }
            }

                return false;

        }

        public string[] GetCustomerList()
        {
            string[] s = new string[customerArray.Length];
            for (int i = 0; i < s.Length; i++)
            {
                if (customerArray[i] != null && s[i] == null)
                    s[i] = customerArray[i].ToString();
            }
            return s;
        }

        public string[] GetBookList()
        {
            string[] s = new string[bookArray.Length];
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] != null && s[i]==null)
                    s[i]= bookArray[i].ToString();
            }
            return s;
        }
    }
}
