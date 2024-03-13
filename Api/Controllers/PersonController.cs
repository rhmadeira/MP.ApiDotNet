using App.DTOS;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

//[Authorize]
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

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _personService.GetAsync();

        if (result == null)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _personService.GetByIdAsync(id);
        
        if(result == null)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] PersonDTO personDTO)
    {
        var result = await _personService.UpdetateAsync(personDTO);

        if (result == null)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
   
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _personService.DeleteAsync(id);

        if (result == null)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}
