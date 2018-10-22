using System;
using System.Collections;

namespace Lab11
{
    class Movie
    {
        //Vars
        private string name;
        private string category;
        //Constructor
        public Movie(string _name, string _category)
        {
            name = _name;
            category = _category;
        }
        //Methods
        public static void GetCagegories(ArrayList _movies, string _category )
        {
            foreach(Movie m in _movies)
            {
                if(m.category == _category)
                    System.Console.WriteLine(m.name);
            }
        }

        //Properties
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
