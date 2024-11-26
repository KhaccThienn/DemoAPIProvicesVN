namespace DemoAPIProvicesVN.Applications.Queries
{
    public record SearchDistrictsQuery(string SearchTerm) : IRequest<ResponseModel>;
    public class SearchDistrictsQueryHandler(IDbServices _dbServices) : IRequestHandler<SearchDistrictsQuery, ResponseModel>
    {
        public async Task<ResponseModel> Handle(SearchDistrictsQuery request, CancellationToken cancellationToken)
        {
            var data = await _dbServices.SearchDistrictsAsync(request.SearchTerm);
            if (data == null)
            {
                return ResponseModel.GetFailtureResponse("Failed To Fetch");
            }
            return new ResponseDataModel<IEnumerable<District>>
            {
                Code              = 1,
                Data              = data,
                IsSuccessResponse = true,
                Message           = "Fetch Success"
            };
        }
    }
}
