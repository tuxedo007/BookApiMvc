using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Services
{
    public class BookRepository : IBookRepository
    {
        private BookDbContext _bookDbContext;

        public BookRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public bool BookExists(int bookId)
        {
            return _bookDbContext.Books.Any(b => b.Id == bookId);
        }

        public bool BookExists(string bookIsbn)
        {
            return _bookDbContext.Books.Any(b => b.Isbn == bookIsbn);
        }

        public bool AddBook(List<int> authorsId, List<int> categoriesId, Book book)
        {
            var authors = _bookDbContext.Authors.Where(a => authorsId.Contains(a.Id)).ToList();
            var categories = _bookDbContext.Categories.Where(c => categoriesId.Contains(c.Id)).ToList();

            foreach (var author in authors)
            {
                var bookAuthor = new BookAuthor()
                {
                    Author = author,
                    Book = book
                };
                _bookDbContext.Add(bookAuthor);
            }

            foreach (var category in categories)
            {
                var bookCategory = new BookCategory()
                {
                    Category = category,
                    Book = book
                };
                _bookDbContext.Add(bookCategory);
            }

            _bookDbContext.Add(book);

            return Save();
        }

        public bool DeleteBook(Book book)
        {
            _bookDbContext.Remove(book);
            return Save();
        }

        public Book GetBook(int bookId)
        {
            return _bookDbContext.Books.Where(b => b.Id == bookId).FirstOrDefault();
        }

        public Book GetBook(string bookIsbn)
        {
            return _bookDbContext.Books.Where(b => b.Isbn == bookIsbn).FirstOrDefault();
        }

        public bool CheckOutBook(int bookId)
        {
            Book book = _bookDbContext.Books.Where(b => b.Id == bookId).FirstOrDefault();

            if (book.Available)
            {
                book.Available = false;

                _bookDbContext.Update(book);
                return Save();
            }
            else return false;
        }

        public bool CheckInBook(int bookId, int rating)
        {
            Book book = _bookDbContext.Books.Where(b => b.Id == bookId).FirstOrDefault();

            var bookreview = _bookDbContext.Books.Include(x => x.Reviews).Where(b => b.Id == bookId).FirstOrDefault();

            if (!book.Available)
            {
                book.Available = true;
                // Please note normally I wouldn't do it this way
                // I would do this through injection using the Review repository, but for brevity sake
                Review review = new Review { Headline = "New", ReviewText = "New Review", Rating = rating };
                book.Reviews.Add(review);
                _bookDbContext.Update(book);
                return Save();
            }
            else return false;
        }

        IEnumerable<Book> IBookRepository.GetBooks()
        {
            return _bookDbContext.Books.OrderByDescending(b => b.AverageRating).ThenBy(b => b.Title).ToList();
        }

        IEnumerable<Book> IBookRepository.GetTopRatedBooks()
        {
            UpdateBookRatings();
            return _bookDbContext.Books.OrderBy(b => b.AverageRating).ThenBy(b => b.Title).ToList();
        }

        //public ICollection<Book> GetBooks()
        //{
        //    return _bookDbContext.Books.OrderBy(b => b.Title).ToList();
        //}

        public bool IsDuplicateIsbn(int bookId, string bookIsbn)
        {
            var book = _bookDbContext.Books.Where(b => b.Isbn.Trim().ToUpper() == bookIsbn.Trim().ToUpper()
                                                && b.Id != bookId).FirstOrDefault();

            return book == null ? false : true;
        }

        public bool Save()
        {
            var saved = _bookDbContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool UpdateBook(List<int> authorsId, List<int> categoriesId, Book book)
        {
                _bookDbContext.Update(book);

                return Save();
        }

        //public bool UpdateBook(List<int> authorsId, List<int> categoriesId, Book book)
        //{
        //    var authors = _bookDbContext.Authors.Where(a => authorsId.Contains(a.Id)).ToList();
        //    var categories = _bookDbContext.Categories.Where(c => categoriesId.Contains(c.Id)).ToList();

        //    var bookAuthorsToDelete = _bookDbContext.BookAuthors.Where(b => b.BookId == book.Id);
        //    var bookCategoriesToDelete = _bookDbContext.BookCategories.Where(b => b.BookId == book.Id);

        //    _bookDbContext.RemoveRange(bookAuthorsToDelete);
        //    _bookDbContext.RemoveRange(bookCategoriesToDelete);

        //    foreach (var author in authors)
        //    {
        //        var bookAuthor = new BookAuthor()
        //        {
        //            Author = author,
        //            Book = book
        //        };
        //        _bookDbContext.Add(bookAuthor);
        //    }

        //    foreach (var category in categories)
        //    {
        //        var bookCategory = new BookCategory()
        //        {
        //            Category = category,
        //            Book = book
        //        };
        //        _bookDbContext.Add(bookCategory);
        //    }

        //    _bookDbContext.Update(book);

        //    return Save();
        //}

        public void UpdateBookRatings()
        {
            List<Book> books = _bookDbContext.Books.OrderBy(b => b.Title).ToList();
            foreach (Book book in books)
            {
                var reviews = _bookDbContext.Reviews.Where(r => r.Book.Id == book.Id);
                book.AverageRating = GetBookRating(book.Id);
            }

            _bookDbContext.SaveChanges();
        }

        public decimal GetBookRating(int bookId)
        {
            var reviews = _bookDbContext.Reviews.Where(r => r.Book.Id == bookId);

            if (reviews.Count() <= 0)
                return 0;

            return Math.Round((decimal)reviews.Sum(r => r.Rating) / reviews.Count(), 1);
        }

        // Normally I would place this in a separate class (Or extension method) but  for
        // the sake of brevity I have placed it here
        public decimal RatingAverage(params int[] bookratings)
        {
            int sum = Sum(bookratings);
            decimal result = (decimal)sum / bookratings.Length;
            return result;
        }

        public int Sum(params int[] bookratings)
        {
            int result = 0;
            foreach (int bookrating in bookratings) result += bookrating;
            return result;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _bookDbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
