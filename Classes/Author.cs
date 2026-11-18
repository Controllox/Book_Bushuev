using System.Collections.Generic;

namespace Book_Bushuev
{
    public class Author
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public Author(int Id, string FIO)
        {
            this.Id = Id;
            this.FIO =FIO;
        }
        public static List<Genre> AllGenres()
        {
            List<Genre> allGenres = new List<Genre>();
            allGenres.Add(new Genre(1, "Виктор Пелевин"));
            allGenres.Add(new Genre(2, "Александра Маринина"));
            allGenres.Add(new Genre(3, "Ольга Герр"));
            return allGenres;
        }
    }
}