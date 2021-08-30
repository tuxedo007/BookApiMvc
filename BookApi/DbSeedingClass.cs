using BookApi.Models;
using BookApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi
{
    public static class DbSeedingClass
    {

        public static void SeedDataContext(this BookDbContext context)
        {
            var booksAuthors = new List<BookAuthor>()
            {
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        Isbn = "12345",
                        Title = "Practical Economics Algorithms",
                        DatePublished = new DateTime(2019,2,2),
                        Available = true,
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Category = new Category() { Name = "Educational"}},
                            new BookCategory { Category = new Category() { Name = "Computer Programming"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review { Headline = "Awesome Programming Book", ReviewText = "Good examples beyond words", Rating = 10 },
                            new Review { Headline = "Where's the Advil", ReviewText = "I had a headache after reading this one", Rating = 5 },
                            new Review { Headline = "Meh!", ReviewText = "Kind of interesting", Rating = 4 }

                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Joe",
                        LastName = "Unknown"
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        Isbn = "001322",
                        Title = "Call of the Wild",
                        DatePublished = new DateTime(1903,1,1),
                        Available = true,
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Category = new Category() { Name = "Action"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review { Headline = "Awesome Book", ReviewText = "Reviewing Call of the Wild and it is awesome beyond words", Rating = 5},
                            new Review { Headline = "Terrible Book", ReviewText = "Reviewing Call of the Wild and it is terrrible book", Rating = 1},
                            new Review { Headline = "Decent Book", ReviewText = "Not a bad read, I kind of liked it", Rating = 3}
                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Jack",
                        LastName = "London"
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        Isbn = "123414",
                        Title = "War and Peace",
                        DatePublished = new DateTime(1878,10,1),
                        Available = true,
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Category = new Category() { Name = "Classic"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review { Headline = "A classic", ReviewText = "Reviewing it, it is awesome book", Rating = 8}
                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Leo",
                        LastName = "Tolstoy"
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        Isbn = "666004",
                        Title = "The Silence of the Lambs",
                        DatePublished = new DateTime(1988,5,2),
                        Available = true,
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Category = new Category() { Name = "Thriller"}},
                            new BookCategory { Category = new Category() { Name = "Mystery"}}
                        }
                        ,
                        Reviews = new List<Review>()
                        {
                            new Review { Headline = "read with chianti", ReviewText = "Is it required to read Red Dragon first and read Silence afterwards?", Rating = 7 },
                            new Review { Headline = "not a bedtime read", ReviewText = "I check my closets every night now", Rating = 9 }

                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Thomas",
                        LastName = "Harris"
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        Isbn = "1234567",
                        Title = "A Clockwork Orange",
                        DatePublished = new DateTime(1971,3,24),
                        Available = true,
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Category = new Category() { Name = "Fiction"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review { Headline = "Good Book", ReviewText = "This book made me scream a few times", Rating = 6},
                            new Review { Headline = "Horrible Book", ReviewText = "My wife made me read it and I hated it", Rating = 4}
                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Anthony",
                        LastName = " Burgess"
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        Isbn = "20330",
                        Title = "Cloudy With a Chance of Meatballs",
                        DatePublished = new DateTime(2019,12,6),
                        Available = true,
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Category = new Category() { Name = "Childrens"}},
                            new BookCategory { Category = new Category() { Name = "Fantasy"}}
                        }
                        ,
                        Reviews = new List<Review>()
                        {
                            new Review { Headline = "Meh!", ReviewText = "boring", Rating = 5 }
                            //new Review { Headline = "Meh!", ReviewText = "boring", Rating = 3,
                            // Reviewer = new Reviewer(){ FirstName = "Pavol2", LastName = "Almasi2" } }
                        }
                    },
                    Author = new Author()
                    {
                        FirstName = " Judi",
                        LastName = "Barrett"
                        //,
                        //Country = new Country()
                        //{
                        //    Name = "France"
                        //}
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        Isbn = "22345",
                        Title = "So Long, and Thanks for All the Fish",
                        DatePublished = new DateTime(2019,2,2),
                        Available = true,
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Category = new Category() { Name = "Humor"}},
                            new BookCategory { Category = new Category() { Name = "Fiction"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review { Headline = "I don't understand", ReviewText = "Why did the relation between Arther Dent and Fenchurch escalate quickly?", Rating = 6},
                            new Review { Headline = "Interesting", ReviewText = "Speedy read with a laugh or two", Rating = 7}
                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Douglas",
                        LastName = "Adams"
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        Isbn = "823455",
                        Title = "I Am America",
                        DatePublished = new DateTime(2020,9,9),
                        Available = true,
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Category = new Category() { Name = "Humor"}},
                            new BookCategory { Category = new Category() { Name = "Politics"}}
                        }
                        ,
                        Reviews = new List<Review>()
                        {
                            new Review { Headline = "Okay", ReviewText = "I set out with the intent of quoting my favorite passages from this book.", Rating = 6 },
                            new Review { Headline = "Laugh", ReviewText = "I Really really funny. ", Rating = 8 },
                            new Review { Headline = "What do you expect", ReviewText = "what a wiseass.", Rating = 2 },

                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Stephen",
                        LastName = "Colbert"
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        Isbn = "023475",
                        Title = "For Whom the Bell Tolls",
                        DatePublished = new DateTime(1940,8,12),
                        Available = true,
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Category = new Category() { Name = "Classic"}},
                            new BookCategory { Category = new Category() { Name = "Fictions"}}
                        }
                        ,
                        Reviews = new List<Review>()
                        {
                            new Review { Headline = "Okay", ReviewText = "If we can win here, we can win everywhere", Rating = 9 },
                            new Review { Headline = "Laugh", ReviewText = "This book was beautiful. ", Rating = 8 },
                            new Review { Headline = "What do you expect", ReviewText = "At some point in high school, I decided that I hated Ernest Hemingway.", Rating = 2 },

                        }
                    },
                    Author = new Author()
                    {
                        FirstName = "Ernest",
                        LastName = "Hemingway"
                    }
                },
                new BookAuthor()
                {
                    Book = new Book()
                    {
                        Isbn = "534567",
                        Title = "Fear and Loathing in Las Vegas",
                        DatePublished = new DateTime(1971,6,28),
                        Available = true,
                        BookCategories = new List<BookCategory>()
                        {
                            new BookCategory { Category = new Category() { Name = "Fiction"}}
                        },
                        Reviews = new List<Review>()
                        {
                            new Review { Headline = "Good Romantic Book", ReviewText = "I recently went to Las Vegas for the first", Rating = 5},
                            new Review { Headline = "Horrible", ReviewText = "I read this years ago and reviewed it", Rating = 1},
                            new Review { Headline = "lol", ReviewText = "Whoop whoop, yeehaw", Rating = 8}
                        }
                    },
                    Author = new Author()
                    {
                        FirstName = " Hunter S",
                        LastName = "Thompson"
                    }
                }
            };

            context.BookAuthors.AddRange(booksAuthors);
            context.SaveChanges();
        }
    }
}
