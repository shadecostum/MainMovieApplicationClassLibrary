using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAppClassLibrary.ExceptionHandaling;
using MovieAppClassLibrary;

namespace MainMovieApplicationClassLibrary
{
    public class MovieController
    {

        private MovieManager manager;
        public MovieController()
        {

            manager = new MovieManager();

        }

        public void Run()
        {
            int movieId = 0;
            int movieYear = 0;
            int yearFind = 0;
            string deletedMovieDetails;

            while (true)
            {
                int choose = Display();

                switch (choose)
                {
                    case 1:

                        try
                        {
                            try
                            {
                                Console.WriteLine("Enter the movie id");
                                movieId = Convert.ToInt16(Console.ReadLine());

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                break;
                            }
                            Console.WriteLine("Enter the movie Name");
                            string movieName = Console.ReadLine();
                            Console.WriteLine("Enter movie year");
                            try
                            {
                                movieYear = Convert.ToInt16(Console.ReadLine());

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                break;

                            }
                            Console.WriteLine("Enter movie director");
                            string moviePerson = Console.ReadLine();
                            //string sizeLimit = "";

                            manager.AddFunction(movieId, movieName, movieYear, moviePerson);
                        }
                        catch (StorageException sx)
                        {
                            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                            Console.WriteLine(sx.Message);
                            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                        }


                        Console.WriteLine("+++++++++++============++++++++++");
                        break;
                    case 2:
                        try
                        {
                            string details = manager.ReadFunction();
                            Console.WriteLine(details);
                        }
                        catch (EmptyStorageException ex)
                        {
                            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                        }
                        Console.WriteLine("+++++++++++================+++++++++");


                        break;
                    case 3:
                        Console.WriteLine("Enter Id to update");
                        int updateId = Convert.ToInt32(Console.ReadLine());
                        string detailsupdated;
                        manager.UpdateList(updateId, out detailsupdated);
                        Console.WriteLine("+++++++++++================+++++++++");
                        Console.WriteLine("Updated Movie from database : " + detailsupdated);

                        break;
                    case 4:
                        try
                        {
                            Console.WriteLine("Enter the Name of Movie to delete");
                            string deleteMovieName = Console.ReadLine();
                            manager.DeletList(deleteMovieName, out deletedMovieDetails);
                            Console.WriteLine("Deletd the movie from Database" + deletedMovieDetails);
                        }
                        catch (MovieNotFoundException nf)
                        {
                            Console.WriteLine(nf.Message);
                        }
                        Console.WriteLine("===================================");

                        break;


                    case 5:
                        try
                        {
                            Console.WriteLine("Enter the Year to find Movie");
                            yearFind = Convert.ToInt16(Console.ReadLine());
                        }
                        catch (EmptyStorageException ex) { Console.WriteLine(ex.Message); break; }
                        string data;
                        manager.FindMovie(yearFind, out data);
                        Console.WriteLine("You Entered movie Details" + data);
                        Console.WriteLine("+++++++++++================+++++++++");
                        break;
                    case 6:
                        manager.ClearMovies();

                        Console.WriteLine("Database is cleared");
                        Console.WriteLine("+++++++++++================+++++++++");
                        break;
                    case 7: return;

                    default:
                        Console.WriteLine("invalid");
                        break;
                }
            }
        }

        public int Display()
        {
            Console.WriteLine("Choose \n1.Add a movie\n2.Display all movies\n3.Update\n4.Remove movie by name\n5.Find movie by year\n6.Clear list\n7.Exit  ");
            int choose = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("+++++++++++============++++++++++");
            return choose;
        }

    }
}
