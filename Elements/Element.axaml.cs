using Avalonia.Controls;
using Book_Bushuev.Classes;

namespace Book_Bushuev.Elements;

public partial class Element : UserControl
{
    public Element(Classes.Book Book)
    {
        InitializeComponent();
        tbName.Text = $"Наименование: {Book.Name} ({Book.Year} г.)";
        tbGenre.Text = $"Жанр: {Book.ToGenres()}";
        tbAuthor.Text = $"Автор: {Book.ToAuthors()}";
    }
}