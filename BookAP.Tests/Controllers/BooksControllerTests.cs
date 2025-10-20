using BookAPI.Controllers;
using BookAPI.Data.Entities;
using BookAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Tests.Controllers
{
    public class BooksControllerTests
    {
        [Fact]
        public async void GetAll_ShouldReturnAllBooks()
        {
            //Arrange
            List<Book> books = new List<Book>();
            books.Add(new Book() { Name = "Book 1" });

            var mock = new Mock<IBookRepository>();
            mock.Setup(s => s.GetAllAsync()).ReturnsAsync(books);

            var controller = new BooksController(mock.Object);

            //Act
            var result = controller.GetAll();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, books.Count);
        }
    }
}
