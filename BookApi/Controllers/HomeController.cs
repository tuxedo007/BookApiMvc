using BookApi.Dtos;
using BookApi.Models;
using BookApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IBookRepository _bookRepository;
        private IAuthorRepository _authorRepository;
        private ICategoryRepository _categoryRepository;
        private IReviewRepository _reviewRepository;

        public HomeController(ILogger<HomeController> logger,
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            ICategoryRepository categoryRepository,
            IReviewRepository reviewRepository
            )
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _bookRepository.GetBooks();
            _bookRepository.UpdateBookRatings();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(Book model)
        {
            if (ModelState.IsValid)
            {
                // hard code authors, categories for sake of time
                List<int> authors = new List<int>();
                authors.Add(1);
                List<int> categories = new List<int>();
                categories.Add(1);

                _bookRepository.AddBook(authors, categories, model);
                _bookRepository.Save();
                return RedirectToAction("Index");
                //return RedirectToAction("Index", "Books");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditBook(int BookId)
        {
            Book model = _bookRepository.GetBook(BookId);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditBook(Book model)
        {
            if (ModelState.IsValid)
            {
                // hard code authors, categories for sake of time
                List<int> authors = new List<int>();
                authors.Add(1);
                List<int> categories = new List<int>();
                categories.Add(1);
                _bookRepository.UpdateBook(authors, categories, model);

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult DeleteBook(int BookId)
        {
            Book model = _bookRepository.GetBook(BookId);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int BookId)
        {
            Book book = _bookRepository.GetBook(BookId);
            _bookRepository.DeleteBook(book);
            //_bookRepository.Save();
            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        public IActionResult CheckOutBook(int BookId)
        {
            bool checkOutSuccess = _bookRepository.CheckOutBook(BookId);
            return RedirectToAction("Index", new { checkedOut = checkOutSuccess });
            //Book model = _bookRepository.GetBook(BookId);
            //if (model.Available)
            //    return View(model);
            //return null;
        }

        //[HttpPost]
        //public IActionResult CheckOut(int BookId)
        //{
        //    //Book book = _bookRepository.GetBook(BookId);
        //    _bookRepository.CheckOutBook(BookId);
        //    //_bookRepository.Save();
        //    return RedirectToAction("Index");
        //}


        [HttpGet]
        public IActionResult CheckInBook(int BookId)
        {
            Book model = _bookRepository.GetBook(BookId);
            // if available then you don't have it checked out
            if (!model.Available)
                return View(model);
            else
                return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult CheckInBook(Book model)
        {
            if (ModelState.IsValid)
            {
                int rating = Convert.ToInt32(model.AverageRating);
                _bookRepository.CheckInBook(model.Id, rating);
                //bool checkInSuccess = _bookRepository.CheckInBook(model.Id, 0);
                //_bookRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        //[HttpPost]
        //public IActionResult CheckInBook(Book model, int rating)
        //{                
        //    if (ModelState.IsValid)
        //    {
        //        bool checkInSuccess = _bookRepository.CheckInBook(model.Id, rating);
        //        _bookRepository.Save();
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View(model);
        //    }
        //}









        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
