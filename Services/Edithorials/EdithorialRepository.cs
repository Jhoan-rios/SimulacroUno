using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;

namespace Library.Services
{
    public class EdithorialRepository : IEdithorialRepository
    {
        private readonly LibraryContext _context;
        public EdithorialRepository(LibraryContext context){
            _context = context;
        }
        public void Add(Edithorial edithorial)
        {
            _context.edithorials.Add(edithorial);
            _context.SaveChanges();
        }

        public IEnumerable<Edithorial> GetAll()
        {
            return _context.edithorials.Where(s => s.State=="Activo").ToList();
        }
        public IEnumerable<Edithorial> GetAllInactivo()
        {
            return _context.edithorials.Where(s => s.State=="Inactivo").ToList();
        }

        public Edithorial? GetById(int id)
        {
            return _context.edithorials.Find(id);
        }

        public void Remove(int id)
        {
            var edithorial = _context.edithorials.Find(id);
            if (edithorial != null)
            {
                edithorial.State = "Inactivo";
                _context.edithorials.Attach(edithorial);
                _context.Entry(edithorial).Property(b => b.State).IsModified = true;
                _context.SaveChanges();
            }
        }
        public void Activar(int id)
        {
            var edithorial = _context.edithorials.Find(id);
            if (edithorial != null)
            {
                edithorial.State = "Activar";
                _context.edithorials.Attach(edithorial);
                _context.Entry(edithorial).Property(b => b.State).IsModified = true;
                _context.SaveChanges();
            }
        }

        public void Update(Edithorial edithorial)
        {
            var existingEdithorial = _context.edithorials.Find(edithorial.Id);
            if (existingEdithorial != null)
            {
                existingEdithorial.Name = edithorial.Name;
                existingEdithorial.Address = edithorial.Address;
                existingEdithorial.Phone = edithorial.Phone;
                existingEdithorial.Email = edithorial.Email;
                existingEdithorial.State = edithorial.State;
                
                _context.edithorials.Update(existingEdithorial);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Book not found");
            }
        }
    }
}