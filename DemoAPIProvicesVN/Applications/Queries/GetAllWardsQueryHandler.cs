namespace DemoAPIProvicesVN.Applications.Queries
{
    public record GetAllWardsQuery(int PageNumber, int PageSize) : IRequest<ResponseModel>;

    public class GetAllWardsQueryHandler(IDbServices _dbServices) : IRequestHandler<GetAllWardsQuery, ResponseModel>
    {
        public async Task<ResponseModel> Handle(GetAllWardsQuery request, CancellationToken cancellationToken)
        {
            var data = await _dbServices.GetAllWardsAsync(request.PageNumber, request.PageSize);
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
