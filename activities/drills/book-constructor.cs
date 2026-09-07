using System;

namespace BookDrill
{
    public class Book
    {
        private string _title;

        public Book(string title)
        {
            _title = title;
        }

        public string GetTitle()
        {
            return _title;
        }
    }

    class program
    {
        static void Main(string[] args)
        {
            var book = new Book("Eduvos");
            string name = book.GetTitle();
            Console.WriteLine(name);
        }
    }
}
