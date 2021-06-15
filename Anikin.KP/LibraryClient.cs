using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anikin.KP
{
    public class LibraryClient
    {
        private String FIO;
        private List<Book> Mybooks;
        private int Age;
        private String Email;
        private String Phone;
        private String Passport;
        private bool Debtor;

        public LibraryClient(String fio, Book book, int age, String email, String phone, String passport, bool d) { 
            this.FIO = fio;
            Mybooks = new List<Book>();
            this.Mybooks.Add(book);
            this.Age = age;
            this.Email = email;
            this.Phone = phone;
            this.Passport = passport;
            this.Debtor = d;
        }
        public LibraryClient(String fio, Book book, int age, String email, String phone, String passport)
        {
            this.FIO = fio;
            Mybooks = new List<Book>();
            this.Mybooks.Add(book);
            this.Age = age;
            this.Email = email;
            this.Phone = phone;
            this.Passport = passport;
            this.Debtor = false;
        }
        public String getFIO()
        {
            return FIO;
        }

        public List<Book> getBook(int i)
        {
            return Mybooks;
        }
        public String getBookstr()
        {
            String s = "";
            for (int i = 0; i < Mybooks.Count(); i++)
            {
                s += Mybooks[i].ToString() + "; ";
            }
            return s;
        }
        public int getAge()
        {
            return Age;
        }

        public String getEmail()
        {
            return Email;
        }

        public String getPhone()
        {
            return Phone;
        }

        public String getPassport()
        {
            return Passport;
        }
        public bool getDebtor()
        {
            return Debtor;
        }
        


        public void addBook(Book b)
        {
            Mybooks.Add(b);
        }
        public void setFIO(String fio)
        {
            this.FIO = fio;
        }

        public void setMybooks(List<Book> l)
        {
            this.Mybooks = l;
        }

        public void setAge(int h)
        {
            this.Age = h;
        }

        public void setEmail(String f)
        {
            this.Email = f;
        }

        public void setPhone(String r)
        {
            this.Phone= r;
        }

        public void setPassport (String t)
        {
            this.Passport = t;
        }
        public void setDebtor(bool t)
        {
            this.Debtor = t;
        }
        public string write()
        {
            string s = " Взятые книги: ";
            for(int i = 0; i < Mybooks.Count(); i++)
            {
                s += Mybooks[i].getBname() + " - " + Mybooks[i].getAuthor();
                s += ",";
            }
            return s;
        }
        public string writeS()
        {
            string s = "";
            for (int i = 0; i < Mybooks.Count(); i++)
            {
                s += Mybooks[i].Save();
                s += ",";
            }
            return s;
        }


        public override bool Equals(object c)
        {
            LibraryClient obj = (LibraryClient)c;
            return this.FIO.Equals(obj.getFIO());
        }

        public override string ToString()
        {
            return FIO + "," + this.write() + "Возраст: "+ Age.ToString() + ", Почта " + Email.ToString() + ", Телефон " +
                   Phone.ToString() + ", Паспорт: " + Passport.ToString() + ", Является должником: " + Debtor.ToString();
        }
        public string Save()
        {
            return FIO + "," + this.writeS() + Age.ToString() + "," + Email.ToString() + "," +
                  Phone.ToString() + "," + Passport.ToString() + "," + Debtor.ToString();
        }
    }
}
