namespace FinalPractice.Models;

public interface IMovieRepo
{
    IEnumerable<Movie> GetAllMovies();
    Movie GetMovieById(int movieId);
    void AddMovie(Movie movie);
    void UpdateMovie(Movie movie);
    void DeleteMovie(Movie movie);
    void Save();
}