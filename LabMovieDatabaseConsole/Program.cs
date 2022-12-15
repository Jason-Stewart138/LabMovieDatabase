using LabMovieDatabaseDomain;
using MovieDatabaseDTO;
using System;

MovieInteracter _movieInteracter = new MovieInteracter();

//AddMoviesToDatabase();
Main();
Console.Clear();
Console.WriteLine("Press Any Key To Exit");
Console.ReadKey();

Console.Clear();
Console.WriteLine("Good Bye");
Environment.Exit(0);

void Main()
{
    while (true)
    {
        DisplayAllItems();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Please Narrow Your Results By Entering 1 To Search By Title Or Enter 2 To Search By Genre:");
        Console.WriteLine();

        string userSelection = Console.ReadLine().Trim();
        Console.WriteLine();

        if (userSelection == "1")
        {
            Console.WriteLine("Please Enter The Movie Title:");
            string userMovieTitle = Console.ReadLine().Trim();
            SearchByTitle(userMovieTitle);

        }
        else if (userSelection == "2")
        {
            Console.WriteLine("Please Enter A Genre:");
            string userMovieGenre = Console.ReadLine().Trim();
            SearchByGenre(userMovieGenre);
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("You Have Entered An Invalid Entry");
            Console.WriteLine("Press Any Key To Exit");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Good Bye");
            Environment.Exit(0);

        }
        Console.WriteLine();
        Console.WriteLine("Would you like to search again? y/n");
        string goAgain = Console.ReadLine().ToLower().Trim();
        if (goAgain == "y" || goAgain == "yes")
        {
            Console.Clear();
            Main();
        }
        break;

    }

}


Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Please Narrow Your Results By Entering 1 To Search By Title Or Enter 2 To Search By Genre:");
Console.WriteLine();

string userSelection = Console.ReadLine().Trim();
Console.WriteLine();

if (userSelection == "1")
{
    Console.WriteLine("Please Enter The Movie Title:");
    string userMovieTitle = Console.ReadLine().Trim();
    SearchByTitle(userMovieTitle);

}
else if (userSelection == "2")
{
    Console.WriteLine("Please Enter A Genre:"); 
    string userMovieGenre = Console.ReadLine().Trim();
    SearchByGenre(userMovieGenre);
}
else
{
    Console.WriteLine();
    Console.WriteLine("You Have Entered An Invalid Entry");
    Console.WriteLine("Press Any Key To Exit");
    Console.ReadKey();

    Console.Clear();
    Console.WriteLine("Good Bye");
    Environment.Exit(0);

}


Console.ReadKey();

void DisplayAllItems()
{
    Console.WriteLine();
    Console.WriteLine("The following items are in the database");
    Console.WriteLine();

    Console.WriteLine("Title - - - Genre");
    Console.WriteLine();

    foreach (Movie movie in _movieInteracter.GetAllMovies())
    {
        Console.WriteLine($"{movie.Title} - - - {movie.Genre}");
    }
}
void SearchByTitle(string movieTitle)
{
    Console.WriteLine();
    Console.WriteLine($"Searching for movie: {movieTitle}");
    bool doesItemExist = _movieInteracter.GetMovieByTitleIfExists(movieTitle, out List<Movie> movies);
    if (doesItemExist)
    {
        Console.WriteLine("Movie Found!");
        Console.WriteLine();
        foreach (Movie x in movies)
        {
            Console.WriteLine($"Name: {x.Title}: Genre: {x.Genre}");
        }
    }
    else
    { Console.WriteLine("That movie is not in the system"); }
}

void SearchByGenre(string movieGenre)
{
    Console.WriteLine();
    Console.WriteLine($"Searching for genre: {movieGenre}");
    bool doesItemExist = _movieInteracter.GetMovieByGenreIfExists(movieGenre, out List<Movie> movies);
    if (doesItemExist)
    {
        Console.WriteLine("Movies Found!");
        Console.WriteLine();
        foreach (Movie x in movies)
        {
            Console.WriteLine($"Name: {x.Title}");
        }
    }
    else
    { Console.WriteLine("Sorry we have nothing for that genre in the system"); }
}

void AddMoviesToDatabase()
{
    foreach (Movie movie in BuildMovieCollection())
    {
        if (_movieInteracter.AddNewMovie(movie) == true)
        {
            Console.WriteLine($"{movie.Title} was added to the database.");
        }
        else
        {
            Console.WriteLine($"{movie.Title} was NOT added to the database.");
        }
    }
}

List<Movie> BuildMovieCollection()
{
    List<Movie> initialMovies = new List<Movie>();
    initialMovies.Add(new Movie() { Title = "Indiana Jones and the Last Crusade", Genre = "Fantasy", Runtime = 2.07 });
    initialMovies.Add(new Movie() { Title = "The Mask", Genre = "Fantasy", Runtime = 1.41 });
    initialMovies.Add(new Movie() { Title = "Blade", Genre = "Fantasy", Runtime = 2.00 });
    initialMovies.Add(new Movie() { Title = "American Psycho", Genre = "Horror", Runtime = 1.44 });
    initialMovies.Add(new Movie() { Title = "Bodies Bodies Bodies", Genre = "Horror", Runtime = 1.35 });
    initialMovies.Add(new Movie() { Title = "Dahmer", Genre = "Horror", Runtime = 1.42 });
    initialMovies.Add(new Movie() { Title = "The Princess Bride", Genre = "Romance", Runtime = 1.38 });
    initialMovies.Add(new Movie() { Title = "Grease", Genre = "Romance", Runtime = 1.50 });
    initialMovies.Add(new Movie() { Title = "Hercules", Genre = "Romance", Runtime = 1.33 });
    initialMovies.Add(new Movie() { Title = "Avatar", Genre = "Action", Runtime = 2.41 });
    initialMovies.Add(new Movie() { Title = "Mad Max: Fury Road", Genre = "Action", Runtime = 2.00 });
    initialMovies.Add(new Movie() { Title = "Logan", Genre = "Action", Runtime = 2.17 });
    initialMovies.Add(new Movie() { Title = "Dead Pool", Genre = "Action", Runtime = 1.48 });
    initialMovies.Add(new Movie() { Title = "The Beatles: Get Back Docuseries", Genre = "Documentary", Runtime = 7.48 });
    initialMovies.Add(new Movie() { Title = "The Alpinist", Genre = "Documentary", Runtime = 1.22 });
    initialMovies.Add(new Movie() { Title = "Grizzly Man", Genre = "Documentary", Runtime = 1.43 });
    initialMovies.Add(new Movie() { Title = "Pulp Fiction", Genre = "Drama", Runtime = 2.34 });
    initialMovies.Add(new Movie() { Title = "Top Gun: Maverick", Genre = "Drama", Runtime = 2.11 });
    initialMovies.Add(new Movie() { Title = "The Lord of the Rings: The Fellowship of the Ring", Genre = "Drama", Runtime = 2.58 });
    initialMovies.Add(new Movie() { Title = "Dumb and Dumber", Genre = "Comedy", Runtime = 1.47 });
    initialMovies.Add(new Movie() { Title = "Step Brothers", Genre = "Comedy", Runtime = 1.38 });
    return initialMovies;
}