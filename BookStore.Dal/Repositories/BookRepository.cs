using BookStore.Dal.Data;
using BookStore.Dal.IRepositories;
using BookStore.Dal.Models;
using BookStore.Dal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Dal.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Book AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public void DeleteById(int id)
        {
            var book = GetById(id);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public Book GetBookByISBN(string isbn)
        {
            return _context.Books.FirstOrDefault(x => x.ISBN == isbn);
        }

        public List<Book> GetBooks()
        {
            var books = _context.Books.ToList();
            return books;
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            return _context.Books.Where(x => x.Author.Contains(author)).ToList();
        }

        public List<Book> GetBooksByDate(DateTime dateTime)
        {
            return _context.Books.Where(x => x.Date == dateTime).ToList();
        }

        public List<Book> GetBooksByName(string name)
        {
            return _context.Books.Where(x => x.Name.Contains(name)).ToList();
        }

        public List<Book> GetBooksByPriceRange(int min, int max)
        {
            return _context.Books.Where(x => x.Price >= min && x.Price <= max).ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books.Where(x => x.Id == id).FirstOrDefault();
        }

        public IQueryable<Book> SearchBooks(SearchViewModel model)
        {
            var result = _context.Books.AsQueryable();
            if(model != null)
            {
                if (!string.IsNullOrEmpty(model.ISBN))
                {
                    result = result.Where(x => x.ISBN == model.ISBN);
                    return result;
                }
                if (!string.IsNullOrEmpty(model.Name))
                {
                    result = result.Where(x => x.Name.Contains(model.Name));
                }
                if (!string.IsNullOrEmpty(model.Author))
                {
                    result = result.Where(x => x.Author.Contains(model.Author));
                }
                if (model.MinPrice.HasValue)
                {
                    result = result.Where(x => x.Price >= model.MinPrice);
                }
                if (model.MaxPrice.HasValue)
                {
                    result = result.Where(x => x.Price <= model.MaxPrice);
                }
                if (model.Date.HasValue)
                {
                    result = result.Where(x => x.Date == model.Date);
                }
            }
            return result;
        }

    }
}
