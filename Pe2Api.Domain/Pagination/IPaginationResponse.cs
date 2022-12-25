namespace Pe2Api.Domain.Pagination
{
    public interface IPaginationResponse<TData> where TData : class
    {
        IEnumerable<TData> Data { get; set; }

        int CurrentPage { get; set; }
        int TotalPages { get; set; }

        long TotalRecords { get; set; }  


    }
}