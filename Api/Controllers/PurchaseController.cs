using App.DTOs;
using App.Services;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PurchaseController : ControllerBase
{
    private readonly IPurchaseService _purchaseService;

    public PurchaseController(IPurchaseService purchaseService)
    {
        _purchaseService = purchaseService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PurchaseDTO dto)
    {
        try
        {
            var result = await _purchaseService.CreateAsync(dto);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
        catch (Exception e)
        {
            var result = ResultService.Fail(e.Message);
            return BadRequest(result);
        }
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _purchaseService.GetPurchaseAsync();

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
        var result = await _purchaseService.GetByIdAsync(id);

        if (result == null)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] PurchaseDTO purchaseDTO)
    {
        var result = await _purchaseService.UpdateAsync(purchaseDTO);
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
        var result = await _purchaseService.DeleteAsync(id);
        if (result == null)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}
