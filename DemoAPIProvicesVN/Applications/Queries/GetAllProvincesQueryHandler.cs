namespace DemoAPIProvicesVN.Applications.Queries
{
    public record GetAllProvincesQuery : IRequest<ResponseModel>;

    public class GetAllProvincesQueryHandler(IDbServices _dbServices) : IRequestHandler<GetAllProvincesQuery, ResponseModel>
    {
        public async Task<ResponseModel> Handle(GetAllProvincesQuery request, CancellationToken cancellationToken)
        {
            var data = await _dbServices.GetAllProvincesAsync();
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
