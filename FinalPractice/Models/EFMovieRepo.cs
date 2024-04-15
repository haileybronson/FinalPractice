using Microsoft.AspNetCore.Routing.Template;

namespace FinalPractice.Models;

public class EFMovieRepo : IMovieRepo
{
    private JoelHiltonMovieCollectionContext _context;

    public EFMovieRepo(JoelHiltonMovieCollectionContext temp)
    {
        _context = temp;
    }
    
    //list out the movies 
    public IEnumerable<Movie> GetAllMovies()
    {
        return _context.Movies.OrderBy(m => m.Title).ToList();
    }

    //grab the movies? 
    public Movie GetMovieById(int movieId)
    {
        return _context.Movies.FirstOrDefault(m => m.MovieId == movieId);
    }

    //add movies 
    public void AddMovie(Movie movie)
    {
        _context.Movies.Add(movie);
    }

    //update the movies 
    public void UpdateMovie(Movie movie)
    {
        _context.Update(movie);
    }

    //delete movies 
    public void DeleteMovie(Movie movie)
    {
        _context.Movies.Remove(movie);
    }
    
    public void Save()
    {
        _context.SaveChanges();
    }
}