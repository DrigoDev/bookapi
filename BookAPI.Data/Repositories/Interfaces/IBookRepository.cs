using BookAPI.Data.Entities;

namespace BookAPI.Data.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> AddAsync(Book book);
        Task<List<Book>> GetAllAsync();
        Task UpdateAsync(int id, Book book);
        Task<Book> GetByIdAsync(int id);
        Task<List<Book>> GetByNameAsync(string name);
        Task RemoveAsync(Book book);       
    }
}
