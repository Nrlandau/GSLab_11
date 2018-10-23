using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
        private static void DisplayMoviesFromCategory(ArrayList _movies, MovieCategory _category )
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
                System.Console.WriteLine("The movies in {0} category:",_category.ToString().ToLower() );
                foreach(string n in sortName)
                    System.Console.WriteLine(n);
            }
            else
            {
                System.Console.WriteLine("There are no movies in the {0} category",_category.ToString().ToLower());
            }
        }
        public static void DisplayMoviesFromCategory(ArrayList _movies, string _category)
        {
            int intCat;
            if(int.TryParse(_category,out intCat))
            {
                DisplayMoviesFromCategory(_movies,intCat);
            }
            else
            {
                DisplayMoviesFromCategory(_movies,StringToCategory(_category));
            }
        }
        private static void DisplayMoviesFromCategory(ArrayList _movies, int _category)
        {
            DisplayMoviesFromCategory(_movies,GetCagegories(_category));
        }
        public static MovieCategory GetCagegories(int _index)
        {
            _index--;
            if ((MovieCategory)_index < MovieCategory.ANIMATED || (MovieCategory)_index > MovieCategory.SCIFI)
                throw new ArgumentException("That index does not link to a category");
            return (MovieCategory)(_index);
        }
        public static void DisplayCategorys()
        {
            for(MovieCategory i = MovieCategory.ANIMATED; i <= MovieCategory.SCIFI;i++)
            {
                System.Console.WriteLine("{0}:{1}",(int)i + 1,i);
            }
        }
        public static MovieCategory StringToCategory(string _movieCat)
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
        static ArrayList MakeMovies()
        {
            ArrayList movies = new ArrayList();
            movies.Add(new Movie("Name",MovieCategory.ANIMATED));
            movies.Add(new Movie("Lame",MovieCategory.ANIMATED));
            movies.Add(new Movie("Same",MovieCategory.ANIMATED));
            movies.Add(new Movie("Name2 the drama",MovieCategory.DRAMA));
            movies.Add(new Movie("Dame",MovieCategory.DRAMA));
            movies.Add(new Movie("Rain",MovieCategory.DRAMA));
            movies.Add(new Movie("Name in SPACE",MovieCategory.SCIFI));
            movies.Add(new Movie("Mame",MovieCategory.HORROR));
            movies.Add(new Movie("Mame2",MovieCategory.HORROR));
            movies.Add(new Movie("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA","horror"));
            return movies;
        }
        static bool isContinue() 
        {
            string con;
            while(true)
                {
                System.Console.WriteLine("Do you want to enter another Category?");
                con = System.Console.ReadLine();
                if(Regex.IsMatch(con,@"^[nNyY]"))
                {
                    if(Regex.IsMatch(con,@"^[nN]"))
                        return false;
                    return true;
                }
            }
        }
        static void Main(string[] args)
        {
            ArrayList movies = MakeMovies();
            while (true)
            {
                string cat = "";
                try
                {
                    Movie.DisplayCategorys();
                    System.Console.WriteLine("Input a category");
                    cat = Console.ReadLine();
                    Movie.DisplayMoviesFromCategory(movies,cat);
                }
                catch(ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    continue;
                }
            if(!isContinue())
                break;
            }
        }
    }
}
