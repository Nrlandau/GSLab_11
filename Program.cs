using System;
using System.Collections;

namespace Lab11
{
    enum MovieCategory{ANIMATED,DRAMA,HORROR,SCIFI};
    class Movie
    {
        //Vars
        private string name;
        private MovieCategory category;
        //Constructor
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
            category = SetCategory(_category);
        }
        //Methods
        public static void DisplayMoviesFromCategory(ArrayList _movies, MovieCategory _category )
        {
            foreach(Movie m in _movies)
            {
                if(m.category == _category)
                    System.Console.WriteLine(m.name);
            }
        }
        public static MovieCategory GetCagegories(int _index)
        {
            return (MovieCategory)(_index);
        }
        private static MovieCategory SetCategory(string _movieCat)
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
            System.Console.WriteLine(Movie.GetCagegories(4));
        }
    }
}
