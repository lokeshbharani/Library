using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A5_JyothiLokesh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Library l = new Library();
        private string[] custList = new string[5];
        private string[] bookList = new string[5];
        int count_cust = 0, count_book = 0;

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label1.Text = "Customer Name";
                textBox3.Enabled = false;
                textBox2.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                label1.Text = "Title";
                textBox3.Enabled = false;
                textBox2.Enabled = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                label1.Text = "Title";
                textBox3.Enabled = true;
                textBox2.Enabled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;
            int j = listBox2.SelectedIndex;
            if (i < 0)
            {
                MessageBox.Show("You have to select a customer");
            }
            else if (j < 0)
            {
                MessageBox.Show("You have to select a book");
            }
            else
            {
                int id = i + 1;
                int catNum = j + 1 + 100;
                if (l.IssueBook(id, catNum))
                {
                    listBox2.Items.RemoveAt(j);
                    bookList = l.GetBookList();
                    listBox2.Items.Insert(j, bookList[j]);
                }
                else
                {
                    MessageBox.Show("This book is already checked out.");
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = listBox2.SelectedIndex;
            if (i < 0)
            {
                MessageBox.Show("You have to select a book");
            }
            else
            {
                int catNum = 100 + i + 1;
                if (l.RenewBook(catNum))
                {
                    listBox2.Items.RemoveAt(i);
                    bookList = l.GetBookList();
                    listBox2.Items.Insert(i, bookList[i]);
                }
                else
                {
                    MessageBox.Show("This book cannot be renewed.");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = listBox2.SelectedIndex;
            if (i < 0)
            {
                MessageBox.Show("You have to select a book");
            }
            else
            {
                int catNum = i + 100 + 1;
                if (l.ReturnBook(catNum))
                {
                    listBox2.Items.RemoveAt(i);
                    bookList = l.GetBookList();
                    listBox2.Items.Insert(i, bookList[i]);
                }
                else
                {
                    MessageBox.Show("This book is not checked out");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("The information provided is incomplete.");
                }
                else if (count_cust == custList.Length)
                {
                    MessageBox.Show("Cannot add more customers.");
                }

                else if (l.AddNewCustomer(textBox1.Text))
                {
                    custList = l.GetCustomerList();
                    listBox1.Items.Add(custList[count_cust]);
                    count_cust++;
                }
            }

            else if (radioButton2.Checked == true)
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("The information provided is incomplete.");
                }
                else if (count_book == bookList.Length)
                {
                    MessageBox.Show("Cannot add more books");
                }
                else if (l.AddNewBook(textBox1.Text, textBox2.Text))
                {
                    bookList = l.GetBookList();
                    listBox2.Items.Add(bookList[count_book]);
                    count_book++;
                }

            }

            else if (radioButton3.Checked == true)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("The information provided is incomplete.");
                }
                else if (count_book == bookList.Length)
                {
                    MessageBox.Show("Cannot add more books");
                }
                else
                {
                    if (l.AddNewBook(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text)))
                    {
                        bookList = l.GetBookList();
                        listBox2.Items.Add(bookList[count_book]);
                        count_book++;
                    }
                }
            }
        }
    }
}
