using Core.Models;
using Infrastructure;
using Infrastructure.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace Maried.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController(
    ILogger<PersonController> logger,
    ICSVReader<PersonDTO> csvReader,
    IMarriedContext context,
    IPersonService personService)
    : ControllerBase
{
    private readonly ILogger<PersonController> _logger = logger;
    private IMarriedContext _context = context;
    
    [HttpPost(Name = "AddFile")]
    public async Task<IActionResult> Post(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }
        using (var reader = new StreamReader(file.OpenReadStream()))
        {
            var list = csvReader.Read(reader);
            var listPerson = list.Select(x => new Person(x.Name, x.DateOfBirth, x.Married, x.Phone, x.Salary)).ToList();
            await personService.AddPersonAsync(listPerson);
            return Ok();
        }
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var listPerson = await personService.GetPersonAsync();
        return Ok(listPerson);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        await personService.DeletePersonAsync(id);
        return Ok();
    }
    [HttpPut]
    public async Task<IActionResult> Put(Person person)
    {
        var personAnswer = await personService.UpdatePersonAsync(person);
        return Ok(personAnswer);
    }
}