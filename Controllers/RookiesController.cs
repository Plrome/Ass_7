using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ass_6.Models;
using System.Globalization;
using Ass_6.Services;

namespace Ass_6.Controllers;

// [Route("")]
// [Route("NashTech")]
public class RookiesController : Controller
{
    private readonly IPersonService _personService;
    public RookiesController(IPersonService personService)
    {
        _personService = personService;
    }
    public IActionResult Index()
    {
        var people = _personService.GetAll();
        return View(people);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Person model)
    {
        if (!ModelState.IsValid) return View();

        _personService.Create(model);
        return RedirectToAction("Index");

    }
    // [Route("rookies/edit")]
    public IActionResult Edit(int index)
    {
        try
        {
            var person = _personService.GetOne(index);
            ViewBag.PersonIndex = index;
            return View(person);
        }
        catch (System.Exception)
        {
            return RedirectToAction("Index");
        }
    }
    [HttpPost]
    public IActionResult Edit(int index, Person model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.PersonIndex = index;
            return View();
        }

        _personService.Update(index, model);
        return RedirectToAction("Index");

    }
    [HttpPost]
    public IActionResult Delete(int index)
    {
        try
        {
            _personService.Delete(index);
        }
        catch (System.Exception)
        {

        }
        return RedirectToAction("Index");

    }

    public IActionResult Detail(int index)
    {
        try
        {
            var person = _personService.GetOne(index);
            ViewBag.PersonIndex = index;
            return View(person);
        }
        catch (System.Exception)
        {
            return RedirectToAction("Index");
        }
    }
    [HttpPost]
    public IActionResult DeleteWithResult(int index)
    {
        
        try
        {
            var person = _personService.GetOne(index);
            
            HttpContext.Session.SetString("DELETED_USER_NAME",person.FullName);
            _personService.Delete(index);
        }
        catch (System.Exception)
        {

        }
        return RedirectToAction("Result" );

    }
    public IActionResult Result()
    {
        
            var deletedUsername = HttpContext.Session.GetString("DELETED_USER_NAME");
            ViewBag.DeletedUsername = deletedUsername;
            return View();
        
    }




}