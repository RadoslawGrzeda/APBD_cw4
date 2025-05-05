using cw4.Properties.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw4.Properties.Controllers;

[ApiController]
[Route ("visits")]
public class VisitsController:ControllerBase
{
    public static List<Visit> visit = new List<Visit>();
    
    [HttpGet("getVisits")]
    public IActionResult getVisits()
    {
        return Ok(visit);
    }

    [HttpGet("getVisitByDate/{dateOfVisit}")]
    public IActionResult getAnimalByName(String dateOfVisit)
    {
        Visit visit2 = visit.Where(a=>a.dateOfVisists==dateOfVisit).FirstOrDefault();
        if (visit2 == null)
            return NotFound();
        return Ok(visit2);
    }
    [HttpGet("getVisitWithAnimal/{Animal}")]
    public IActionResult getAnimalByName(Animal animal)
    {
    // public static List<Visit> animalvis = new List<Visit>();
    var visit2 = visit.Where(a => a.Animal == animal);
    if (visit2 == null)
        return NotFound();
    return Ok(visit2);
    }
    

    [HttpPost("insertVisit")]
    public void InsterVisit(Visit visit2)
    {
        visit.Add(visit2);
    }
    
}