using BookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Services
{
    public interface IBookRepository
    {

        Book GetBook(int bookId);
        IEnumerable<Book> GetBooks();
        //Book CheckOutBook(int bookId);
        bool CheckOutBook(int bookId);
        bool CheckInBook(int bookId, int rating);
        IEnumerable<Book> GetTopRatedBooks();
        decimal GetBookRating(int bookId);
        void UpdateBookRatings();
        bool BookExists(int bookId);
        bool BookExists(string bookIsbn);
        bool IsDuplicateIsbn(int bookId, string bookIsbn);
        bool AddBook(List<int> authorsId, List<int> categoriesId, Book book);
        bool UpdateBook(List<int> authorsId, List<int> categoriesId, Book book);
        bool DeleteBook(Book book);
        bool Save();
    }
}
