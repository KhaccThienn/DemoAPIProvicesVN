namespace DemoAPIProvicesVN.Applications.Queries
{
    public record GetAllDistrictsQuery : IRequest<ResponseModel>;

    public class GetAllDistrictsQueryHandler(IDbServices _dbServices) : IRequestHandler<GetAllDistrictsQuery, ResponseModel>
    {
        public async Task<ResponseModel> Handle(GetAllDistrictsQuery request, CancellationToken cancellationToken)
        {
            var data = await _dbServices.GetAllDistrictsAsync();
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
