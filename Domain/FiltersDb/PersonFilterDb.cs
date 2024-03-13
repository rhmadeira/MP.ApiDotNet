
using Domain.Repositories;

namespace Domain.FiltersDb;

internal class PersonFilterDb : PagedBaseRequest
{
    public string Name { get; set; }
}
