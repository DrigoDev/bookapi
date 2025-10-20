using BookAPI.Data.Entities;
using BookAPI.Data.Repositories;
using BookAPI.Data.Repositories.Interfaces;
using Moq;

namespace BookAPI.Tests.Controllers
{
    public class BookRepositoryTests
    {
        [Fact]
        public async void GetAll_ShouldReturnAllBooks()
        {
            //Arrange
            List<Book> books = new List<Book>();
            books.Add(new Book() { Name = "Book 1" });

            var mock = new Mock<IBookRepository>();
            mock.Setup(s => s.GetAllAsync()).ReturnsAsync(books);

            //Act
            var result = await mock.Object.GetAllAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Contains(result, b => b.Name == "Book 1");
        }
    }
}
