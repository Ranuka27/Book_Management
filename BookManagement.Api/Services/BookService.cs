// Add this line at the top ↓↓↓
using BookManagement.Api.Models;

namespace BookManagement.Api.Services
{
    public class BookService
    {
        private static List<Book> Books = new List<Book>();
        private static int NextId = 1;

        public IEnumerable<Book> GetAll() => Books;

        public Book? GetById(int id) => Books.FirstOrDefault(b => b.Id == id);

        public Book Add(Book book)
        {
            book.Id = NextId++;
            Books.Add(book);
            return book;
        }

        public bool Update(Book updatedBook)
        {
            var existing = Books.FirstOrDefault(b => b.Id == updatedBook.Id);
            if (existing == null) return false;

            existing.Title = updatedBook.Title;
            existing.Author = updatedBook.Author;
            existing.ISBN = updatedBook.ISBN;
            existing.PublicationDate = updatedBook.PublicationDate;

            return true;
        }

        public bool Delete(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book == null) return false;

            Books.Remove(book);
            return true;
        }
    }
}