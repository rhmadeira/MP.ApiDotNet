using App.DTOS;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PersonDTO personDTO)
    {
        var result = await _personService.CreateAsync(personDTO);
        if (result == null)
        {
            return BadRequest(result);
        }
        
        return Ok(result);
    }
}
