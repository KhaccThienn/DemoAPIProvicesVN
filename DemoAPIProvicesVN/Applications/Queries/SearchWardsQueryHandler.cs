namespace DemoAPIProvicesVN.Applications.Queries
{
    public record SearchWardsQuery(string SearchTerm, int PageNumber, int PageSize) : IRequest<ResponseModel>;
    public class SearchWardsQueryHandler(IDbServices _dbServices) : IRequestHandler<SearchWardsQuery, ResponseModel>
    {
        public async Task<ResponseModel> Handle(SearchWardsQuery request, CancellationToken cancellationToken)
        {
            var data = await _dbServices.SearchWardsAsync(request.SearchTerm, request.PageNumber, request.PageSize);
            if (data == null)
            {
                return ResponseModel.GetFailtureResponse("Failed To Fetch");
            }
            return new ResponseDataModel<IEnumerable<Ward>>
            {
                Code              = 1,
                Data              = data,
                IsSuccessResponse = true,
                Message           = "Fetch Success"
            };
        }
    }
}
