namespace DemoAPIProvicesVN.Applications.Queries
{
    public record GetWardsByDistrictCodeQuery(string Code, int PageNumber, int PageSize) : IRequest<ResponseModel>;
    public class GetWardsByDistrictCodeQueryHandler(IDbServices _dbServices) : IRequestHandler<GetWardsByDistrictCodeQuery, ResponseModel>
    {
        public async Task<ResponseModel> Handle(GetWardsByDistrictCodeQuery request, CancellationToken cancellationToken)
        {
            var data = await _dbServices.GetWardsByDistrictCodeAsync(request.Code, request.PageNumber, request.PageSize);
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
