using System.Windows;
using System.Windows.Controls; 

namespace LibraryApp
{
    public partial class MainWindow : Window
    {
        private Library library;

        public MainWindow()
        {
            InitializeComponent();
            library = new Library();
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            var title = TitleTextBox.Text;
            var author = AuthorTextBox.Text;
            int year = int.Parse(YearTextBox.Text);
            var isbn = ISBNTextBox.Text;

            var book = new Book(title, author, year, isbn);
            library.AddBook(book);

            RefreshBookList();
        }

        private void RemoveBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (BooksListBox.SelectedItem is Book selectedBook)
            {
                library.RemoveBook(selectedBook);
                RefreshBookList();
            }
        }

        private void SearchByTitleButton_Click(object sender, RoutedEventArgs e)
        {
            var title = TitleTextBox.Text;
            var books = library.SearchByTitle(title);
            BooksListBox.ItemsSource = books;
        }

        private void SearchByAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            var author = AuthorTextBox.Text;
            var books = library.SearchByAuthor(author);
            BooksListBox.ItemsSource = books;
        }

        private void RefreshBookList()
        {
            BooksListBox.ItemsSource = null;
            BooksListBox.ItemsSource = library.GetAllBooks();
        }

        private void RemoveText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "Title" || textBox.Text == "Author" || textBox.Text == "Year" || textBox.Text == "ISBN")
            {
                textBox.Text = "";
            }
        }

        private void AddText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox.Name == "TitleTextBox") textBox.Text = "Title";
                if (textBox.Name == "AuthorTextBox") textBox.Text = "Author";
                if (textBox.Name == "YearTextBox") textBox.Text = "Year";
                if (textBox.Name == "ISBNTextBox") textBox.Text = "ISBN";
            }
        }
    }
}
