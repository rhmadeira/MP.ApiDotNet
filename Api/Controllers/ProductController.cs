using App.DTOs;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{

    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] ProductDTO productDTO)
    {
        var result = await _productService.CreateAsync(productDTO);
        if (result == null)
        {
            return BadRequest(result);
        }
        
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<ActionResult<ProductDTO>> GetAll()
    {
        var result = await _productService.GetAsync();
        if (result == null)
        {
            return BadRequest(result);
        }
        
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDTO>> GetById(int id)
    {
        var result = await _productService.GetByIdAsync(id);
        if (result == null)
        {
            return BadRequest(result);
        }
        
        return Ok(result);
    }

}
