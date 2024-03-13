using App.DTOs;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [Route("token")]
    public async Task<ActionResult> Post([FromForm] UserDTO user)
    {
        var token = await _userService.GenerateTokenAsync(user);
        if (!token.IsSuccess)
            return BadRequest("Invalid user or password");

        return Ok(token);
    }
}
