using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Services
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();
        IEnumerable<Author> GetAllInactivo();
        Author? GetById( int id );
        void Add( Author author);
        void Remove( int id );
        void Activar( int id );
        void Update(Author author);
    }
}