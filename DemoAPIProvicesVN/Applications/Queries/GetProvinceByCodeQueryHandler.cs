namespace DemoAPIProvicesVN.Applications.Queries
{
    public record GetProvinceByCodeQuery(string Code) : IRequest<ResponseModel>;
    public class GetProvinceByCodeQueryHandler(IDbServices _dbServices) : IRequestHandler<GetProvinceByCodeQuery, ResponseModel>
    {
        public async Task<ResponseModel> Handle(GetProvinceByCodeQuery request, CancellationToken cancellationToken)
        {
            var data = await _dbServices.GetProvinceByCodeAsync(request.Code);
            if (data == null)
            {
                return ResponseModel.GetFailtureResponse("Failed To Fetch");
            }
            return new ResponseDataModel<Province>
            {
                Code              = 1,
                Data              = data,
                IsSuccessResponse = true,
                Message           = "Fetch Success"
            };
        }
    }
}
