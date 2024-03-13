using App.DTOs;

namespace App.Services.Interfaces
{
    public interface IPurchaseService
    {
        Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO dto);
        Task<ResultService<PurchaseDetailsDTO>> GetByIdAsync(int id);
        Task<ResultService<ICollection<PurchaseDetailsDTO>>> GetPurchaseAsync();
        Task<ResultService<PurchaseDTO>> UpdateAsync(PurchaseDTO dto);
        Task<ResultService> DeleteAsync(int id);

    }
}
