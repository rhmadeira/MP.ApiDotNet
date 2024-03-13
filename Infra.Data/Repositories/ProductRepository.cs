using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task DeleteAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        Product? product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        return product;
    }
    
    public async Task<IEnumerable<Product>> GetProductAsync()
    {
        var products = await _context.Products.ToListAsync();
        return products;
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }
    
    public async Task<int> GetIdByCodErpAsync(string codErp)
    {
        var query = _context.Products.AsQueryable();

        query = query.Where(x => x.CodErp == codErp);

        var sql = query.ToQueryString();
        var product = query.FirstOrDefault();

        if (product == null)
        {
            return 0;
        }
        
        return product.Id;
    }
}
