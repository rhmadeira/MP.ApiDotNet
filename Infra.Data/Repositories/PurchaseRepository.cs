using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class PurchaseRepository : IPurchaseRepository
{
    private readonly AppDbContext _context;

    public PurchaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Purchase> CreateAsync(Purchase purchase)
    {
        _context.Purchases.Add(purchase);
        await _context.SaveChangesAsync();
        return purchase;

    }

    public async Task DeleteAsync(Purchase purchase)
    {
        _context.Purchases.Remove(purchase);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Purchase purchase)
    {
        _context.Purchases.Update(purchase);
        await _context.SaveChangesAsync();

    }

    public async Task<Purchase> GetByIdAsync(int id)
    {
        return await _context.Purchases
            .Include(x => x.Person)
            .Include(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Purchase>> GetPurchaseAsync()
    {
        return await _context.Purchases
            .Include(x => x.Person)
            .Include(x => x.Product)
            .ToListAsync();
    }


    public async Task<IEnumerable<Purchase>> GetPurchaseByPersonIdAsync(int personId)
    {
        return await _context.Purchases
            .Include(x => x.Person)
            .Include(x => x.Product)
            .Where(x => x.PersonId == personId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Purchase>> GetPurchaseByProductIdAsync(int productId)
    {
        return await _context.Purchases
            .Include(x => x.Person)
            .Include(x => x.Product)
            .Where(x => x.ProductId == productId)
            .ToListAsync();
    }
}
