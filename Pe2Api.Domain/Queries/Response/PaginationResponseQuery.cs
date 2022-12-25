namespace Pe2Api.Domain.Queries.Response
{
    public class PaginationResponseQuery<TClass>
    {
        public PaginationResponseQuery()
        {

        }

        public PaginationResponseQuery(object data, int currentPage, int totalPages, int totalRecords)
        {
            Data = data;
            CurrentPage = currentPage;
            TotalPages = totalPages;
            TotalRecords = totalRecords;
        }

        public object Data { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    }
}
