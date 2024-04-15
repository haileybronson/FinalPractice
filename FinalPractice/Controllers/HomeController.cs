using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FinalPractice.Models;

namespace FinalPractice.Controllers;

public class HomeController : Controller
{
    private IMovieRepo _repo;

    public HomeController(IMovieRepo temp)
    {
        _repo = temp;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult Movies()
    {
        return View("Movies", new Movie());
    }

    [HttpPost]
    public IActionResult Movies(Movie response)
    {
        if (ModelState.IsValid)
        {
            _repo.AddMovie(response);
            _repo.Save();
            return View("Confirmation", response);
        }
        else
        {
            return View(response);
        }
    }

    public IActionResult MovieList()
    {
        var movies = _repo.GetAllMovies();
        return View(movies);
    }

    //test 
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _repo.GetMovieById(id);
        return View("Movies", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Movie updatedInfo)
    {
        _repo.UpdateMovie(updatedInfo);
        _repo.Save();
        return RedirectToAction("MovieList");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _repo.GetMovieById(id);
        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Movie deletedInfo)
    {
        _repo.DeleteMovie(deletedInfo);
        _repo.Save();
        return RedirectToAction("MovieList");
    }

}