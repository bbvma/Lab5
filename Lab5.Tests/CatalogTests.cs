namespace Lab5.Tests
{
    public class CatalogTests
    {
        Lab5Context testDb;
        Catalog testCat;

        [Fact]
        public void AddingBook_ByTitleReturn()
        {
            testDb = new Lab5Context();
            testDb.Database.EnsureCreated();
            testDb.SaveChanges();
            testCat = new Catalog(testDb);
            var expectedBooks = new List<Book>
            { new Book
            {
                Title = "Pride and Prejudice",
                Author = "Jane Austen",
                Genres = "romance, drama",
                PublicationDate = DateTime.Now.ToString(),
                Annotation = "Test Annotation",
                ISBN = "1234567890"
            },
            new Book
            {
                Title = "Him and her",
                Author = "Emma Winter",
                Genres = "romance, fantastic",
                PublicationDate = DateTime.Now.ToString(),
                Annotation = "Test Annotation2",
                ISBN = "5234567890"
            }};
            testCat.AddBook(expectedBooks[0]);
            testCat.AddBook(expectedBooks[1]);
            var actualBooks = testCat.SearchByTitle("Him and her");
            expectedBooks.Remove(expectedBooks[0]);
            Assert.True(BooksEqual(expectedBooks, actualBooks));
        }
        [Fact]
        public void AddingBook_ByAuthorReturn()
        {
            testDb = new Lab5Context();
            testDb.Database.EnsureCreated();
            testDb.SaveChanges();
            testCat = new Catalog(testDb);
            var expectedBooks = new List<Book>
            { new Book
            {
                Title = "Pride and Prejudice",
                Author = "Jane Austen",
                Genres = "romance, drama",
                PublicationDate = DateTime.Now.ToString(),
                Annotation = "Test Annotation",
                ISBN = "1234567890"
            },
            new Book
            {
                Title = "Him and her",
                Author = "Emma Winter",
                Genres = "romance, fantastic",
                PublicationDate = DateTime.Now.ToString(),
                Annotation = "Test Annotation2",
                ISBN = "5234567890"
            }};
            testCat.AddBook(expectedBooks[0]);
            testCat.AddBook(expectedBooks[1]);
            var actualBooks = testCat.SearchByAuthor("Emma");
            expectedBooks.Remove(expectedBooks[0]);
            Assert.True(BooksEqual(expectedBooks, actualBooks));
        }
        [Fact]
        public void AddingBook_ByISBNReturn()
        {
            testDb = new Lab5Context();
            testDb.Database.EnsureCreated();
            testDb.SaveChanges();
            testCat = new Catalog(testDb);
            var expectedBooks = new List<Book>
            { new Book
            {
                Title = "Pride and Prejudice",
                Author = "Jane Austen",
                Genres = "romance, drama",
                PublicationDate = DateTime.Now.ToString(),
                Annotation = "Test Annotation",
                ISBN = "1234567890"
            },
            new Book
            {
                Title = "Him and her",
                Author = "Emma Winter",
                Genres = "romance, fantastic",
                PublicationDate = DateTime.Now.ToString(),
                Annotation = "Test Annotation2",
                ISBN = "5234567890"
            }};
            testCat.AddBook(expectedBooks[0]);
            testCat.AddBook(expectedBooks[1]);
            var actualBooks = testCat.SearchByISBN("1234567890");
            expectedBooks.Remove(expectedBooks[1]);
            Assert.True(BooksEqual(expectedBooks, actualBooks));
        }
        [Fact]
        public void AddingBook_ByKeywordsReturn()
        {
            testDb = new Lab5Context();
            testDb.Database.EnsureCreated();
            testDb.SaveChanges();
            testCat = new Catalog(testDb);
            var expectedBooks = new List<Book>
            { new Book
            {
                Title = "Pride and Prejudice",
                Author = "Jane Austen",
                Genres = "romance, drama",
                PublicationDate = DateTime.Now.ToString(),
                Annotation = "Test Annotation",
                ISBN = "1234567890"
            },
            new Book
            {
                Title = "Him and her",
                Author = "Emma Winter",
                Genres = "romance, fantastic",
                PublicationDate = DateTime.Now.ToString(),
                Annotation = "Test Annotation2",
                ISBN = "5234567890"
            },
            new Book
            {
                Title = "Hello world",
                Author = "Some Programmer",
                Genres = "fantastic, thriller",
                PublicationDate = DateTime.Now.ToString(),
                Annotation = "Test Annotation2",
                ISBN = "089975234567890"
            }};
            testCat.AddBook(expectedBooks[0]);
            testCat.AddBook(expectedBooks[1]);
            testCat.AddBook(expectedBooks[2]);
            List<string> list = new List<string>();
            list.Add("Pride");
            list.Add("her");
            var actualBooks = testCat.SearchByKeywords(list);
            expectedBooks.Remove(expectedBooks[2]);
            Assert.True(BooksEqual(expectedBooks, actualBooks));
        }
        private bool BooksEqual(List<Book> b1, List<Book> b2)
        {
            if (b1.Count() != b2.Count())
            {
                return false;
            }
            var flag = true;
            for (int i = 0; i < b1.Count(); i++)
            {
                if (!BookEqual(b1[i], b2[i]))
                {
                    flag = false;
                }
            }
            return flag;
        }
        private bool BookEqual(Book b1, Book b2)
        {
            if (b1.Title == b2.Title && b1.Author == b2.Author && b1.Genres == b2.Genres && b1.PublicationDate == b2.PublicationDate && b1.ISBN == b2.ISBN && b1.Annotation == b2.Annotation)
            {
                return true;
            }
            return false;
        }

    }
}