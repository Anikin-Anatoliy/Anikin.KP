using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anikin.KP
{
    public class Book
    {
        private String Bname;
        private String Author;

        public Book(string n, string a) {
            Bname = n;
            Author = a;
        }
        public string getBname()
        {
            return Bname;
        }
        public string getAuthor()
        {
            return Author;
        }
        public void setBname(string n)
        {
            Bname = n;
        }
        public void setAuthor(string a)
        {
            Author = a;
        }
        public override string ToString()
        {
            return "Автор: " + Author + " -- Название книги: " + Bname;
        }
        public string Save()
        {
            return Author + "," + Bname;
        }
    }
}
