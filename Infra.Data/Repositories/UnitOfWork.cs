using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infra.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbcontext;
    private IDbContextTransaction _transaction;

    public UnitOfWork(AppDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task BeginTransaction()
    {
        _transaction = await _dbcontext.Database.BeginTransactionAsync();
    }

    public async Task Commit()
    {
        await _transaction.CommitAsync();
    }

    public async Task Rollback()
    {
       await _transaction.RollbackAsync();
    }
    public void Dispose()
    {
        _transaction?.Dispose();
    }
}
