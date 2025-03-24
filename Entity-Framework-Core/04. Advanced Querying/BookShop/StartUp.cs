namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
        }
        //Problem 02
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            string result = string.Empty;
            bool isEnumValid = Enum
                .TryParse(command,true, out AgeRestriction ageRestriction);

            if(!isEnumValid)
            {
                return result;
            }

            string[] bookTitles = context
                .Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();
                
            result = String.Join(Environment.NewLine, bookTitles);

            return result;
        }
        //Problem 03 
        public static string GetGoldenBooks(BookShopContext context)
        {
            string[] titles = context
               .Books
               .Where(b => b.EditionType == EditionType.Gold &&
                           b.Copies < 5000)
               .OrderBy(b => b.BookId)
               .Select(b => b.Title)
               .ToArray();

            return String.Join(Environment.NewLine, titles);
        }

        //Problem 04
        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksByPrice = context
                .Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                }).ToArray()
                .OrderByDescending(b => b.Price);

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksByPrice)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        //Problem 05
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            string[] booksNotReleasedIn = context
                .Books
                .Where(b => b.ReleaseDate!.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();


            return String.Join(Environment.NewLine, booksNotReleasedIn);
        }

        //Problem 06 
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] searchCategories = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLowerInvariant())
                .ToArray();

            string[] bookTitles = context
               .Books
               .Where(b => b.BookCategories
                    .Any(bc => searchCategories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();
            return String.Join(Environment.NewLine, bookTitles);
        }
        //Problem 07
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var booksReleasedBefore = context
                .Books
                .Where(b => b.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", null))
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                }).ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var b in booksReleasedBefore)
            {
                sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        //Problem 08 
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();
            var authorNamesEndingIn = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                })
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .ToArray();

            foreach(var author in authorNamesEndingIn)
            {
                sb.AppendLine(author.FirstName + " " + author.LastName);
            }
            return sb.ToString().TrimEnd();
        }

        //Problem 09
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string[] bookTitlesContaining = context
                .Books      
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return String.Join(Environment.NewLine, bookTitlesContaining);
        }

        //Problem 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();
            var booksByAuthor = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    b.Author.FirstName,
                    b.Author.LastName
                })
                .ToArray();
            foreach (var book in booksByAuthor)
            {
                sb.AppendLine($"{book.Title} ({book.FirstName} {book.LastName})");
            }
            return sb.ToString().TrimEnd();
        }
        //Problem 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            Book[] books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToArray();

            return books.Length;
        }
        //Problem 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    AuthorFullName = a.FirstName + " " + a.LastName,
                    BookCopies = a.Books.Sum(b => b.Copies)
                }).OrderByDescending(b => b.BookCopies)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var a in authors)
            {
                sb.AppendLine($"{a.AuthorFullName} - {a.BookCopies}");
            }

            return sb.ToString().TrimEnd();
        }
        //Problem 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var books = context.Categories
                 .Select(c => new
                 {
                     CategoryName = c.Name,
                     TotalProfit = c.CategoryBooks.Sum(bc => bc.Book.Copies * bc.Book.Price)
                 }).OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.CategoryName).ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.CategoryName} ${b.TotalProfit:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        //Problem 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categoriesWithMostRecentBooks = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    MostRecentBooks = c.CategoryBooks
                        .OrderByDescending(cb => cb.Book.ReleaseDate)
                        .Take(3)
                        .Select(cb => new
                        {
                            BookTitle = cb.Book.Title,
                            ReleaseYear = cb.Book.ReleaseDate.Value.Year
                        }).ToArray()
                }).ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var c in categoriesWithMostRecentBooks)
            {
                sb.AppendLine($"--{c.CategoryName}");

                foreach (var b in c.MostRecentBooks)
                {
                    sb.AppendLine($"{b.BookTitle} ({b.ReleaseYear})");
                }
            }

            return sb.ToString().TrimEnd();
        }
        //Problem 15
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010).ToArray();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }
        //Problem 16
        public static int RemoveBooks(BookShopContext context)
        {
            Book[] books = context.Books
                .Where(b => b.Copies < 4200).ToArray();

            foreach (var book in books)
            {
                context.Books.Remove(book);
            }

            context.SaveChanges();

            return books.Count();
        }
    }
}


