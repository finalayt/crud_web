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

    public async Task<IActionResult> Delete(int id)
    {
      var person = await _Context.People.FindAsync(id);

      if (person != null)
        {
            _Context.People.Remove(person);
            await _Context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

[HttpGet]


    public async Task<IActionResult> Creating(int? id)
    {;
        if (id == null)   {

        ViewBag.ActionType = "Create";  
        return View(new Person());
        }

        var person = await _Context.People.FindAsync(id);
        if (person == null) return NotFound();

        return View(person);

    }

[HttpPost]
    public async Task<IActionResult> Creating(Person person, string actionType)
    {
        ViewBag.ActionType = actionType;

        if (ModelState.IsValid)
        {
            if (actionType == "Create")
            {
            var exists = await _Context.People.FindAsync(person.Id);
            if (exists != null)
                {
                    ModelState.AddModelError("Id", "This user is already exist");
                    return View(person);
                }
                _Context.People.Add(person);    
            }
            else _Context.People.Update(person);

        await _Context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
        }
return View(person);
    }

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
