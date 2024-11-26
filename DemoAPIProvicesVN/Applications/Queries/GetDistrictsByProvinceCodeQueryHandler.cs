namespace DemoAPIProvicesVN.Applications.Queries
{
    public record GetDistrictsByProvinceCodeQuery(string Code) : IRequest<ResponseModel>;
    public class GetDistrictsByProvinceCodeQueryHandler(IDbServices _dbServices) : IRequestHandler<GetDistrictsByProvinceCodeQuery, ResponseModel>
    {
        public async Task<ResponseModel> Handle(GetDistrictsByProvinceCodeQuery request, CancellationToken cancellationToken)
        {
            var data = await _dbServices.GetDistrictsByProvinceCodeAsync(request.Code);
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
