using System;

namespace LibraryApp  // Пространство имен вашего проекта
{
    public class Book  // Имя класса
    {
        // Поля (переменные) класса
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }

        // Конструктор класса
        public Book(string title, string author, int year, string isbn)
        {
            Title = title;
            Author = author;
            Year = year;
            ISBN = isbn;
        }

        // Метод для вывода информации о книге
        public override string ToString()
        {
            return $"{Title} by {Author}, {Year} (ISBN: {ISBN})";
        }
    }
}
