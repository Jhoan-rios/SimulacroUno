using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;
using Library.Services;

namespace Library.Services
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _context;
        public AuthorRepository(LibraryContext context){
            _context = context;
        }
        public void Add(Author author)
        {
            _context.authors.Add(author);
            _context.SaveChanges();
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.authors.Where(s => s.State=="Activo").ToList();
        }
        public IEnumerable<Author> GetAllInactivo()
        {
            return _context.authors.Where(s => s.State=="Inactivo").ToList();
        }

        public Author? GetById(int id)
        {
            return _context.authors.Find(id);
        }

        public void Remove(int id)
        {
            var author = _context.authors.Find(id);
            if (author != null)
            {
                author.State = "Inactivo";
                _context.authors.Attach(author);
                _context.Entry(author).Property(b => b.State).IsModified = true;
                _context.SaveChanges();
            }
        }
        public void Activar(int id)
        {
            var author = _context.authors.Find(id);
            if (author != null)
            {
                author.State = "Activo";
                _context.authors.Attach(author);
                _context.Entry(author).Property(b => b.State).IsModified = true;
                _context.SaveChanges();
            }
        }

        public void Update(Author author)
        {
            var existingAuthor = _context.authors.Find(author.Id);
            if (existingAuthor != null)
            {
                existingAuthor.Name = author.Name;
                existingAuthor.LastName = author.LastName;
                existingAuthor.Email = author.Email;
                existingAuthor.Nationality = author.Nationality;
                existingAuthor.State = author.State;
                
                _context.authors.Update(existingAuthor);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Book not found");
            }
        }
    }
}