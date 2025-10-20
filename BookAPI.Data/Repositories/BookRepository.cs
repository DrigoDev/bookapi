using BookAPI.Data.DatabaseContext;
using BookAPI.Data.Entities;
using BookAPI.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Data.Repositories
{
    public class BookRepository : IBookRepository
    {        
        private AppDbContext _appDbContext;
        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Book> AddAsync(Book book)
        {
            _appDbContext.Books.Add(book);
            await _appDbContext.SaveChangesAsync();
            return book;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _appDbContext.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _appDbContext.Books.Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Book>> GetByNameAsync(string name)
        {
            return await _appDbContext.Books.Where(b => b.Name == name).ToListAsync();
        }

        public async Task RemoveAsync(Book book)
        {
            _appDbContext.Books.Remove(book);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Book book)
        {
            Book bookContext = await _appDbContext.Books.Where(b => b.Id == id).FirstOrDefaultAsync();
            bookContext.IsBooked = book.IsBooked;

            bookContext.Name = book.Name;
            bookContext.IsBooked = book.IsBooked;

            _appDbContext.Books.Update(bookContext);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
