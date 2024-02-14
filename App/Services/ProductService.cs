using App.DTOs;
using App.DTOs.Validations;
using App.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace App.Services;

public class ProductService : IProductService
{

    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO)
    {
        if (productDTO == null)
            return ResultService.Fail<ProductDTO>("Você deve enviar um objeto de produto");
        
        var validate = new ProductDTOValidator().Validate(productDTO);
        if(!validate.IsValid)
            return ResultService.RequestError<ProductDTO>("Problemas de validação", validate);

        var product = _mapper.Map<Product>(productDTO);
        var data = await _productRepository.CreateAsync(product);
        var dto = _mapper.Map<ProductDTO>(data);
            
        return ResultService.Ok(dto);
    }

    public Task<ResultService> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
    public Task<ResultService<ProductDTO>> UpdateAsync(ProductDTO productDTO)
    {
        throw new NotImplementedException();
    }

    public async Task<ResultService<ICollection<ProductDTO>>> GetAsync()
    {
        var list = await _productRepository.GetProductAsync();
        var data = _mapper.Map<ICollection<ProductDTO>>(list);

        return ResultService.Ok(data);
    }

    public async Task<ResultService<ProductDTO>> GetByIdAsync(int id)
    {
        if (id <= 0)
            return ResultService.Fail<ProductDTO>("Id inválido");

        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
            return ResultService.Fail<ProductDTO>("Produto não encontrado");

        var dto = _mapper.Map<ProductDTO>(product);
        return ResultService.Ok(dto);
    }
}
