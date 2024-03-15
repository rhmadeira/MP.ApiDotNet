
using Domain.Repositories;

namespace Domain.FiltersDb;

public class PersonFilterDb : PagedBaseRequest
{
    public string Name { get; set; }
}
