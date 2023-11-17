class Book
{
    private string title;
    private string author;
    private double cost;

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string Author
    {
        get { return author; }
        set { author = value; }
    }

    public double Cost
    {
        get { return cost; }
        set { cost = value; }
    }

    public Book(string _title, string _author, double _cost)
    {
        title = _title;
        author = _author;
        cost = _cost;
    }

    public virtual void Print()
    {
        Console.Write($"Название: {Title}, атвор: {Author}, стоимость: {Cost}");
    }
}

class BookGenre : Book
{
    private string genre;

    public string Genre
    {
        get { return genre; }
        set { genre = value; }
    }

    public BookGenre(string _title, string _author, double _cost, string _genre) : base(_title, _author, _cost)
    {
        genre = _genre;
    }

    public override void Print()
    {
        base.Print();
        Console.Write($", Жанр: {Genre}");
    }
}

sealed class BookGenrePubl : BookGenre
{
    private string publisher;
    public string Publisher
    {
        get { return publisher; }
        set { publisher = value; }
    }

    public BookGenrePubl(string _title, string _author, double _cost, string _genre, string _publisher) : base(_title, _author, _cost, _genre)
    {
        publisher = _publisher;
    }

    public override void Print()
    {
        base.Print();
        Console.Write($", Издатель: {Publisher}");
    }
}

class Task2
{
    static void Main()
    {
        Book book = new Book("Пардус", "Евгений Гаглоев", 469.30);
        BookGenre bookGenre = new BookGenre("Мастер и Маргарита", "Михаил Булгаков", 500, "Классика");
        BookGenrePubl bookGenrePubl = new BookGenrePubl("НИ СЫ", "Джен Синсеро", 350.50, "Личностный рост", "ЭКСМО");

        book.Print();
        Console.WriteLine();
        bookGenre.Print();
        Console.WriteLine();
        bookGenrePubl.Print();
        Console.WriteLine();
        bookGenrePubl.Cost = 300;
        bookGenrePubl.Print();
        Console.WriteLine();
    }
}
