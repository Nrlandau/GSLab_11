using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab11
{
    enum MovieCategory{ANIMATED,DRAMA,HORROR,SCIFI};
    class Movie
    {
        //Vars
        private string name;
        private MovieCategory category;
        //Constructors
        public Movie(string _name, MovieCategory _category)
        {
            if(_category > MovieCategory.SCIFI || _category < MovieCategory.ANIMATED)
                throw new ArgumentOutOfRangeException();
            name = _name;
            category = _category;
        }
        public Movie(string _name, string _category)
        {
            name = _name;
            category = StringToCategory(_category);
        }
        //Methods
        public static void DisplayMoviesFromCategory(ArrayList _movies, MovieCategory _category )
        {
            List<string> sortName = new List<string>();
            foreach(Movie m in _movies)
            {
                if(m.category == _category)
                    sortName.Add(m.name);
            }
            if(sortName.Count > 1)
            {
                sortName.Sort();
            }
            if(sortName.Count > 0)
            {
                System.Console.WriteLine("The ");
                foreach(string n in sortName)
                    System.Console.WriteLine(n);
            }
            else
            {
                System.Console.WriteLine("There are no movies in the {0} category",_category.ToString().ToLower());
            }
        }
        public static MovieCategory GetCagegories(int _index)
        {
            return (MovieCategory)(_index);
        }
        public static void DisplayCategorys()
        {
            for(MovieCategory i = MovieCategory.ANIMATED; i <= MovieCategory.SCIFI;i++)
            {
                System.Console.WriteLine(i);
            }
        }
        private static MovieCategory StringToCategory(string _movieCat)
        {
            switch(_movieCat.ToLower())
            {
                case "drama": return MovieCategory.DRAMA;
                case "animated": return MovieCategory.ANIMATED;
                case "horror": return MovieCategory.HORROR;
                case "scifi": return MovieCategory.SCIFI;
                default: throw new ArgumentException("Invalid Category");
            }
        }
        //Properties
    }
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList movies = new ArrayList();
            Movie.DisplayMoviesFromCategory(movies,MovieCategory.ANIMATED);

        }
    }
}
