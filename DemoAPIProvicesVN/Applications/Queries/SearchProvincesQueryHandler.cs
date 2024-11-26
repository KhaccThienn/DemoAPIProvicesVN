namespace DemoAPIProvicesVN.Applications.Queries
{
    public record SearchProvincesQuery(string SearchTerm) : IRequest<ResponseModel>;
    public class SearchProvincesQueryHandler(IDbServices _dbServices) : IRequestHandler<SearchProvincesQuery, ResponseModel>
    {
        public async Task<ResponseModel> Handle(SearchProvincesQuery request, CancellationToken cancellationToken)
        {
            var data = await _dbServices.SearchProvincesAsync(request.SearchTerm);
            if (data == null)
            {
                return ResponseModel.GetFailtureResponse("Failed To Fetch");
            }
            return new ResponseDataModel<IEnumerable<Province>>
            {
                Code              = 1,
                Data              = data,
                IsSuccessResponse = true,
                Message           = "Fetch Success"
            };
        }
    }
}
