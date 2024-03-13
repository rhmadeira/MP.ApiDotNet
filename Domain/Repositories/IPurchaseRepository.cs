using Domain.Entities;

namespace Domain.Repositories;

public interface IPurchaseRepository
{
    Task<Purchase> GetByIdAsync(int id);
    Task<IEnumerable<Purchase>> GetPurchaseAsync();
    Task<Purchase> CreateAsync(Purchase purchase);
    Task UpdateAsync(Purchase purchase);
    Task DeleteAsync(Purchase purchase);
    Task<IEnumerable<Purchase>> GetPurchaseByPersonIdAsync(int personId);
    Task<IEnumerable<Purchase>> GetPurchaseByProductIdAsync(int productId);
}
