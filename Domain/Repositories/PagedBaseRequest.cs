namespace Domain.Repositories;

public class PagedBaseRequest
{
    public int Page { get; set; }
    public int Take { get; set; }
    public string OrderBy { get; set; }

    //public PageBaseRequest(int page, int take, string orderBy)
    //{
    //    Page = page;
    //    Take = take;
    //    OrderBy = orderBy;
    //}

    public PagedBaseRequest()
    {
        Page = 1;
        Take = 10;
        OrderBy = "Id";
    }

}
