using System.Collections;
using cw4.Properties.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw4.Properties.Controllers;


[ApiController]
[Route("animals")]
public class AnimalsController : ControllerBase
{
    public static List<Animal> animals = new List<Animal>();

    [HttpGet("getAnimals")]
    public IActionResult getAnimals()
    {
        return Ok(animals);
    }

    [HttpGet("getAnimalByName/{name}")]
    public IActionResult getAnimalByName(String name)
    {
        Animal animal = animals.FirstOrDefault(x => x.name == name);
        if (animal == null)
            return NotFound();
        return Ok(animal);
    }
    [HttpGet("{id}/visits")]
    public IActionResult GetVisitsForAnimal(int id)
    {
        var visitsForAnimal = VisitsController.visit.Where(v => v.Animal.id == id).ToList();
        return Ok(visitsForAnimal);
    }

    [HttpGet("getAnimalById/{id}")]
    public IActionResult getAnimalById(int id)
    {
        var animal = animals.Where(a => a.id == id);
        if (animal == null)
            return NotFound();
        return Ok(animal);
    }

    [HttpPost("insertAnimals")]
    public void InsterAnimals(Animal animal)
    {
        animals.Add(animal);
    }


[HttpPut("updateAnimal")]
    public IActionResult UpdateAnimals([FromQuery] int id,[FromBody] Animal anotherAnimal)
    {
        var animal = animals.FirstOrDefault(x => x.id == id);
        if (animal == null)
            return NotFound();
        animal.name = anotherAnimal.name;
        animal.category = anotherAnimal.category;
        animal.weight = anotherAnimal.weight;
        animal.coatColor = anotherAnimal.coatColor;
    return Ok(animal);
    }


[HttpDelete("deleteAnimal/{id}")]
public void deleteAnimals(int id )
{
    animals.RemoveAll(a => a.id == id);
}

}