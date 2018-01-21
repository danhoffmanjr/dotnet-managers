using System;
using System.Collections.Generic;
using BookLibrary;

namespace BookLibrary
{
    public class BookRepo
    {
        private static List<Book> _books = new List<Book>();
        private static int nextId = 0;

        public List<Book> ListAll()
        {
            return _books;
        }

        public Book GetById(int id)
        {
            return _books.Find(v => v.Id == id);
        }

        public void AddBook(Book newBook)
        {
            newBook.Id = nextId++;
            _books.Add(newBook);
        }

        public void EditBook(Book editBook)
        {
            var origBook = GetById(editBook.Id);
            origBook.Title = editBook.Title;
            origBook.Author = editBook.Author;
            origBook.ISBN = editBook.ISBN;
            origBook.Publisher = editBook.Publisher;
            origBook.Year = editBook.Year;
            origBook.NumOfPages = editBook.NumOfPages;
        }

        public void DeleteBook(int id)
        {
            var bookToDelete = GetById(id);
            _books.Remove(bookToDelete);
        }
    }
}