namespace DemoAPIProvicesVN.Applications.Queries
{
    public record GetAllProvincesByAdminisTrativeRegionCodeQuery(int Id) : IRequest<ResponseModel>;
    public class GetAllProvincesByAdminisTrativeRegionCodeQueryHandler(IDbServices _dbServices) : IRequestHandler<GetAllProvincesByAdminisTrativeRegionCodeQuery, ResponseModel>
    {
        public async Task<ResponseModel> Handle(GetAllProvincesByAdminisTrativeRegionCodeQuery request, CancellationToken cancellationToken)
        {
            var data = await _dbServices.GetAllProvincesByAdminisTrativeRegionCodeAsync(request.Id);
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
