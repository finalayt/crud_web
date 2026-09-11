using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using crud_web.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_web.Controllers;

public class HomeController : Controller
{
    private readonly PersonDbContext _Context;

    public HomeController(PersonDbContext context)
    {
        _Context = context;
    }
    public async Task<IActionResult> Index()
    {
        var people = await _Context.People.ToListAsync();   
        return View(people);
    }

    //public async Task<IActionResult> Delete(int id)
    //{
    //  var person = await _Context.People.FindAsync<id>;

     // if (person != null) 
    //}

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
