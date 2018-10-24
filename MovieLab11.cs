using System;

namespace Lab11
{
    class Movie
    {
        private string genre;
        public string Genre
        {
            get
            {
                return this.genre;
            }
            set
            {
                this.genre = value;
            }
        }
        private string title;
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        public Movie(string categoryInput, string titleInput)
        {
            Genre = categoryInput;
            Title = titleInput;
        }

        public void MovieGenre(string genre)
        {

            Console.WriteLine();
        }

        public string MovieTitle()
        {
            return title;
        }
    }
}
