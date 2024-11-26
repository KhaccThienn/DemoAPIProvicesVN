namespace DemoAPIProvicesVN.Applications.Queries
{
    public record GetAllProvincesByAdminisTrativeUnitCodeQuery(int Id) : IRequest<ResponseModel>;
    public class GetAllProvincesByAdminisTrativeUnitCodeQueryHandler(IDbServices _dbServices) : IRequestHandler<GetAllProvincesByAdminisTrativeUnitCodeQuery, ResponseModel>
    {
        public async Task<ResponseModel> Handle(GetAllProvincesByAdminisTrativeUnitCodeQuery request, CancellationToken cancellationToken)
        {
            var data = await _dbServices.GetAllProvincesByAdminisTrativeUnitCodeAsync(request.Id);
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
