using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Services
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetAllInactivo();
        Book? GetById( int id );
        void Add(Book book);
        void Remove( int id );
        void Activar( int id );
        void Update(Book book);
    }
}