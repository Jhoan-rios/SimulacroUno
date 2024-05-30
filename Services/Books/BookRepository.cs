using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;
using Library.Controllers;
using Microsoft.EntityFrameworkCore;
using Library.Services;

namespace Library.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;
        public BookRepository(LibraryContext context){
            _context = context;
        }

        public void Add(Book book)
        {
            _context.books.Add(book);
            _context.SaveChanges();
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.books.Where(s => s.State=="Activo").Include(c => c.Authors).Include(a => a.edithorials).ToList();
        }

        public IEnumerable<Book> GetAllInactivo()
        {
            return _context.books.Where(s => s.State=="Inactivo").Include(c => c.Authors).Include(a => a.edithorials).ToList();
        }

        public Book? GetById(int id)
        {
            return _context.books.Include(a => a.Authors).Include(e => e.edithorials).FirstOrDefault(c => c.Id == id);
        }

        public void Remove(int id)
        {
            var book = _context.books.Find(id);
            if (book != null)
            {
                book.State = "Inactivo";
                _context.books.Attach(book);
                _context.Entry(book).Property(b => b.State).IsModified = true;
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Book not found");
            }
        }
        public void Activar(int id)
        {
            var book = _context.books.Find(id);
            if (book != null)
            {
                book.State = "Activo";
                _context.books.Attach(book);
                _context.Entry(book).Property(b => b.State).IsModified = true;
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Book not found");
            }
        }

        public void Update(Book book)
        {
            var existingBook = _context.books.Find(book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Pages = book.Pages;
                existingBook.Language = book.Language;
                existingBook.PublicationDate = book.PublicationDate;
                existingBook.Description = book.Description;
                existingBook.State = book.State;
                existingBook.EdithorialsId = book.EdithorialsId;
                existingBook.AuthorsId = book.AuthorsId;
                
                _context.books.Update(existingBook);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Book not found");
            }
        }
    }
}