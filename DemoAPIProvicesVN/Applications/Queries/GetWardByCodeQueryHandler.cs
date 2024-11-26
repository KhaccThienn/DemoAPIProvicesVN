namespace DemoAPIProvicesVN.Applications.Queries
{
    public record GetWardByCodeQuery(string Code) : IRequest<ResponseModel>;
    public class GetWardByCodeQueryHandler(IDbServices _dbServices) : IRequestHandler<GetWardByCodeQuery, ResponseModel>
    {
        public async Task<ResponseModel> Handle(GetWardByCodeQuery request, CancellationToken cancellationToken)
        {
            var data = await _dbServices.GetWardByCodeAsync(request.Code);
            if (data == null)
            {
                return ResponseModel.GetFailtureResponse("Failed To Fetch");
            }
            return new ResponseDataModel<Ward>
            {
                Code              = 1,
                Data              = data,
                IsSuccessResponse = true,
                Message           = "Fetch Success"
            };
        }
    }
}
