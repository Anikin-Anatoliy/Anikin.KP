using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anikin.KP
{
    public class Library
    {
        private static List<LibraryClient> Clients = new List<LibraryClient>();
        private static List<Book> Allbooks = new List<Book>();
        public Library()
        {
            
        }
        public Library(List<LibraryClient> clients, List<Book> allbooks)
        {
            Clients = clients;
            Allbooks = allbooks;
        }
        public List<LibraryClient> getClients()
        {
            return Clients;
        }
        public List<Book> getAllbook()
        {
            return Allbooks;
        }

        public void setClients(List<LibraryClient> c)
        {
            Clients = c;
        }
        public void setAllbooks(List<Book> a)
        {
            Allbooks = a;
        }
        public void addBook(Book b)
        {
            Allbooks.Add(b);
        }
        public void addClient(LibraryClient c)
        {
            Clients.Add(c);
        } 
    }
}
