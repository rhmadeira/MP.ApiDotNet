using App.DTOs;
using App.DTOs.Validations;
using App.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace App.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IMapper _mapper;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseService(IPurchaseRepository purchaseRepository, IProductRepository productRepository, IPersonRepository personRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _purchaseRepository = purchaseRepository;
            _productRepository = productRepository;
            _personRepository = personRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO dto)
        {
            if(dto == null)
                return ResultService.Fail<PurchaseDTO>("Objeto deve ser informado");

            var validate = new PurchaseDTOValidator().Validate(dto);

            if (!validate.IsValid)
                return ResultService.RequestError<PurchaseDTO>("Problemas de validação", validate);

            try
            {
                await _unitOfWork.BeginTransaction();

                var productId = await _productRepository.GetIdByCodErpAsync(dto.CodErp);
                if (productId == 0)
                {
                    var product = new Product(dto.ProductName, dto.CodErp, dto.Price ?? 0);
                    await _productRepository.CreateAsync(product);
                    productId = product.Id;
                }
                var personId = await _personRepository.GetIdByDocumentAsync(dto.Document);

                if (productId == null || personId == null)
                    return ResultService.Fail<PurchaseDTO>("Produto não encontrado");

                var purchase = new Purchase(productId, personId);

                var data = await _purchaseRepository.CreateAsync(purchase);

                dto.Id = data.Id;

                await _unitOfWork.Commit();
                return ResultService.Ok<PurchaseDTO>(dto);
            }
            catch(Exception ex) 
            {
                await _unitOfWork.Rollback();
                return ResultService.Fail<PurchaseDTO>(ex.Message);
            }

        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(id);

            if (purchase == null)
                return ResultService.Fail("Compra não encontrada");

            await _purchaseRepository.DeleteAsync(purchase);

            return ResultService.Ok("Compra deletada");

        }

        public async Task<ResultService<PurchaseDetailsDTO>> GetByIdAsync(int id)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(id);
            if (purchase == null)
                return ResultService.Fail<PurchaseDetailsDTO>("Compra não encontrada");
            
            var purchaseDTO = _mapper.Map<PurchaseDetailsDTO>(purchase);

            return ResultService.Ok(purchaseDTO);
        }

        public async Task<ResultService<ICollection<PurchaseDetailsDTO>>> GetPurchaseAsync()
        {
            var purchases = await _purchaseRepository.GetPurchaseAsync();
            var purchasesDTO = _mapper.Map<ICollection<PurchaseDetailsDTO>>(purchases);

            return ResultService.Ok(purchasesDTO);
        }

        public async Task<ResultService<PurchaseDTO>> UpdateAsync(PurchaseDTO dto)
        {
            if (dto == null)
                return ResultService.Fail<PurchaseDTO>("Objeto deve ser informado");

            var validate = new PurchaseDTOValidator().Validate(dto);

            if (!validate.IsValid)
                return ResultService.RequestError<PurchaseDTO>("Problemas de validação", validate);


            var purchase = await _purchaseRepository.GetByIdAsync(dto.Id.Value);

            if (purchase == null)
                return ResultService.Fail<PurchaseDTO>("Compra não encontrada");

            var productId = await _productRepository.GetIdByCodErpAsync(dto.CodErp);
            var personId = await _personRepository.GetIdByDocumentAsync(dto.Document);

            purchase.Edit(purchase.Id, productId, personId);
            await _purchaseRepository.UpdateAsync(purchase);
            

            return ResultService.Ok(dto);
        }
    }
}
