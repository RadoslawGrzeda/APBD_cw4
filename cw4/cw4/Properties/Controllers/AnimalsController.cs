using System.Collections;
using cw4.Properties.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw4.Properties.Controllers;


[ApiController]
[Route("animals")]
public class AnimalsController: ControllerBase
{
    public static List<Animal> animals = new List<Animal>();
    
    [HttpGet ("getAnimals")]
    public IActionResult getAnimals()
    {
        return Ok(animals);
    }
    [HttpGet ("getAnimals/{id}")]
    public IActionResult getAnimal(int id )
    {
        var animal=animals.Where(a => a.id == id);
        return Ok(animal);
    }

    [HttpPost("insertAnimals")]
    public void InsterAnimals(Animal animal)
    {
     animals.Add(animal);   
        
    }
    [HttpPut("updateAnimals")]
    public void UpdateAnimals()
    {
        
    }
    [HttpDelete("deleteAnimals")]
    public void deleteAnimals()
    {
        
    }
   
}