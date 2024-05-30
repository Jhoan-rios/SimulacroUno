using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Services
{
    public interface IEdithorialRepository
    {
        IEnumerable<Edithorial> GetAll();
        IEnumerable<Edithorial> GetAllInactivo();
        Edithorial? GetById( int id );
        void Add( Edithorial edithorial);
        void Remove( int id );
        void Activar( int id );
        void Update( Edithorial edithorial );
    }
}