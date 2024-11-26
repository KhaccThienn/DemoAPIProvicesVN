namespace DemoAPIProvicesVN.Applications.Queries
{
    public record GetDistrictByCodeQuery(string Code) : IRequest<ResponseModel>;
    public class GetDistrictByCodeQueryHandler(IDbServices _dbServices) : IRequestHandler<GetDistrictByCodeQuery, ResponseModel>
    {
        public async Task<ResponseModel> Handle(GetDistrictByCodeQuery request, CancellationToken cancellationToken)
        {
            var data = await _dbServices.GetDistrictByCodeAsync(request.Code);
            if (data == null)
            {
                return ResponseModel.GetFailtureResponse("Failed To Fetch");
            }
            return new ResponseDataModel<District>
            {
                Code              = 1,
                Data              = data,
                IsSuccessResponse = true,
                Message           = "Fetch Success"
            };
        }
    }
}
