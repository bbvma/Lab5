﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Catalog
    {
        private readonly Lab5Context db;
        public Catalog(Lab5Context _db)
        {
            db = _db;
        }
        public void AddBook(Book book)
        {
            // Проверка на уникальность по ISBN
            if (!IsISBNUnique(book.ISBN))
            {
                // Книга с таким ISBN уже существует, не добавляем
                return;
            }
            db.Books.Add(book);
            db.SaveChanges();
        }

        public List<Book> SearchByTitle(string searchByTitle)
        {
            return db.Books.Where(book => book.Title.Contains(searchByTitle)).ToList();
        }

        public List<Book> SearchByAuthor(string searchByAuthor)
        {
            return db.Books.Where(book => book.Author.Contains(searchByAuthor)).ToList();
        }

        public List<Book> SearchByISBN(string searchByISBN)
        {
            return db.Books.Where(book => book.ISBN == searchByISBN).ToList();
        }


        public List<Book> SearchByKeywords(List<string> keywords)
        {
            List<Book> result = new List<Book>();
            foreach (var book in db.Books)
            {
                if (keywords.Count(keyword => book.Title.Contains(keyword) || book.Annotation.Contains(keyword)) != 0)
                    result.Add(book);
            }
            return result;
        }
        public ObservableCollection<Book> GetAllBooks
        {
            get { return new ObservableCollection<Book>(db.Books.ToList()); }
        }
        private bool IsISBNUnique(string isbn)
        {
            // Проверка уникальности ISBN
            return !db.Books.Any(b => b.ISBN == isbn);
        }
    }
}
