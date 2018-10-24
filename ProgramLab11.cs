using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movieList = new List<Movie>();

            MovieLibrary(ref movieList);
            MainMenu(movieList);
            Exit();
        }

        public static void Header(int count)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Movie List Application!");
            Console.WriteLine($"There are {count} movies in this list...\n");
        }

        public static void MainMenu(List<Movie> movieList)
        {
            bool retry = true;
            while (retry)
            {
                bool invalid = false;
                Header(movieList.Count);
                
                List<Menu> menu = new List<Menu>()
                {
                    new Menu("View List by Title", () => Titles(movieList)),
                    new Menu("View List by Genre", () => Genres(movieList)),
                    new Menu("Add New Movie", () => UserInput(ref movieList))
                };
               
                int menuCount = 0;
                foreach (Menu m in menu)
                {
                    menuCount += 1;
                    Console.WriteLine(menuCount + " - " + m.Nav);
                }

                Console.Write("\nWhat would you like to do? (enter number)  ");
                if (int.TryParse(Console.ReadLine(), out int entry) && entry > 0 && entry <= menu.Count)
                {
                    menu[entry - 1].Page.Invoke();
                }
                else
                {
                    invalid = true;
                }

                if (!invalid)
                {
                    Console.Write("\n\nContinue to Main Menu? (y/n)  ");
                    retry = Retry();
                }
            }
        }

        public static List<Movie> MovieLibrary(ref List<Movie> movieList)
        {
            movieList = new List<Movie>()
            {
                new Movie("Scifi", "Star Wars"),
                new Movie("Scifi", "2001: A Space Odyssey"),
                new Movie("Scifi", "E.T. The Extra-terrestrial"),
                new Movie("Animated", "The Hobbit"),
                new Movie("Animated", "Who Framed Roger Rabbit"),
                new Movie("Drama", "Titanic"),
                new Movie("Drama", "Fight Club"),
                new Movie("Horror", "It"),
                new Movie("Horror", "Halloween"),
                new Movie("Animated", "Shrek")
            };
            return movieList;
        }

        public static List<Movie> UserInput(ref List<Movie> movieList)
        {
            bool retry = true;
            while (retry)
            {
                Console.Clear();
                Console.Write("Enter Movie Genre:  ");
                string genre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
                Console.Write("Enter Movie Title:  ");
                string title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
                movieList.Add(new Movie(genre, title));

                Console.Write("\nEnter Another Movie? (y/n)  ");
                retry = Retry();
            }
            return movieList;
        }

        public static void Genres(List<Movie> movieList)
        {
            bool retry = true;
            while (retry)
            {
                bool invalid = false;
                Console.Clear();
                List<string> genres = new List<string>();
                foreach (Movie movie in movieList)//put all genres into list
                {
                    genres.Add(movie.Genre);             
                }
                List<string> menu = genres.Distinct().ToList();//remove duplicates
                menu.Sort();//alphabetize

                int menuCount = 0;
                Console.WriteLine($"There are {menu.Count} total genres...\n");//display menu
                foreach (string nav in menu)
                {
                    menuCount += 1;
                    Console.WriteLine(menuCount + " - " + nav);
                }
            
                Console.Write("\nChoose a Genre:  (enter number)  ");//get user selection
                int.TryParse(Console.ReadLine(), out int entry);
                if (entry > 0 && entry <= menu.Count)
                {
                    List<string> display = new List<string>();
                    string select = menu[entry - 1];
                    Console.Clear();          
                    foreach (Movie movie in movieList)
                    {
                        if (Equals(select, movie.Genre))
                        {
                            display.Add(movie.Title);
                        }
                    }
                    Console.WriteLine($"There are {display.Count} movies in the {select} genre...\n");
                    display.Sort();
                    foreach(string title in display)
                    {
                        Console.WriteLine(title);
                    }
                }
                else
                {
                    invalid = true;
                }

                if (!invalid)
                {
                    Console.Write("\n\nChoose a different genre? (y/n)  ");
                    retry = Retry();
                }
            }     
        }

        public static void Titles(List<Movie> movieList)
        {
            Header(movieList.Count);
            List<string> titles = new List<string>();
            foreach (Movie movie in movieList)
            {
                titles.Add(movie.Title);
            }
            titles.Sort();
            foreach (string title in titles)
            {
                Console.WriteLine(title);
            }
        }

        public static bool Retry()
        {
            bool valid = false;
            bool retry = true;

            while (!valid)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Y)
                {
                    valid = true;
                    retry = true;
                }
                else if (key == ConsoleKey.N)
                {
                    valid = true;
                    retry = false;
                }
                else
                {
                    Console.Write("\nInvalid Entry, Try Again! Return to Previous Menu?  (y/n)  ");
                    valid = false;
                    retry = true;
                }
            }
            return retry;
        }

        public static void Exit()
        {
            Console.Write("\nGoodbye! Press ESCAPE to Exit...");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Exit();
            }
        }
    }
}
