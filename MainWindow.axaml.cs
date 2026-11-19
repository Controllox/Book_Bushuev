using Avalonia.Controls;
using System.Collections.Generic;
using Avalonia.Input;
using System;

namespace Book_Bushuev;

public partial class MainWindow : Window
{
    List<Book_Bushuev.Classes.Author> AllAuthors = Book_Bushuev.Classes.Author.AllAuthors();
    List<Book_Bushuev.Classes.Genre> AllGenres = Book_Bushuev.Classes.Genre.AllGenres();
    List<Book_Bushuev.Classes.Book> AllBooks = Book_Bushuev.Classes.Book.AllBook();

    public MainWindow()
    {
        InitializeComponent();
        AddAuthors();
        AddGenres();
        AddYears();
        CreateUI(AllBooks);
    }
    public void CreateUI(List<Classes.Book> AllBooks)
    {
        parent.Children.Clear();
        foreach (Book_Bushuev.Classes.Book Book in AllBooks)
            parent.Children.Add(new Elements.Element(Book));
    }
    public void AddAuthors()
    {
        cbAuthors.Items.Add("Выберите...");
        foreach (Book_Bushuev.Classes.Author Author in AllAuthors)
            cbAuthors.Items.Add(Author.FIO);
    }
    public void AddGenres()
    {
        cbGenres.Items.Add("Выберите...");
        foreach (Book_Bushuev.Classes.Genre Genre in AllGenres)
            cbGenres.Items.Add(Genre.Name);
    }
    public void AddYears()
    {
        cbYear.Items.Add("Выберите...");
        List<int> AllYears = new List<int>();
        foreach (Book_Bushuev.Classes.Book Book in AllBooks)
            if(AllYears.Find(x => x == Book.Year) == 0)
            {
                AllYears.Add(Book.Year);
                cbYear.Items.Add(Book.Year);
            }
    }
    private void Search_Book(object? sender, KeyEventArgs e) =>
        Search();

    private void SelectAuthor(object? sender, SelectionChangedEventArgs e) =>
        Search();
        public void Search()
    {
        List<Book_Bushuev.Classes.Book> FindBook = AllBooks.FindAll(x => x.Name.ToLower().Contains((tbSearch.Text ?? "").ToLower()));
        if (cbAuthors.SelectedIndex > 0)
        {
            Book_Bushuev.Classes.Author SelectAuthor = AllAuthors.Find(x => x.FIO == cbAuthors.SelectedItem.ToString());
            FindBook = FindBook.FindAll(x => x.Authors.Find(y => y.Id == SelectAuthor.Id) != null);
        }
        if (cbGenres.SelectedIndex > 0)
        {
            Book_Bushuev.Classes.Genre SelectGender = AllGenres.Find(x => x.Name == cbGenres.SelectedItem.ToString());
            FindBook = FindBook.FindAll(x => x.Genres.Find(y => y.Id == SelectGender.Id) != null);
        }
        if (cbYear.SelectedIndex > 0)
            FindBook = FindBook.FindAll(x => x.Year == Convert.ToInt32(cbYear.SelectedItem.ToString()));
        CreateUI(FindBook);
    }
}