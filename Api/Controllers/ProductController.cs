using App.DTOs;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController : Controller
{

    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductDTO productDTO)
    {
        var result = await _productService.CreateAsync(productDTO);
        if (result == null)
        {
            return BadRequest(result);
        }

        return Ok(result);

    }
}
