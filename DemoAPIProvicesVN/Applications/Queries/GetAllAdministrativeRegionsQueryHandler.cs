namespace DemoAPIProvicesVN.Applications.Queries
{
    public record GetAllAdministrativeRegionsQuery : IRequest<ResponseModel>;

    public class GetAllAdministrativeRegionsQueryHandler(IDbServices _dbServices) : IRequestHandler<GetAllAdministrativeRegionsQuery, ResponseModel>
    {
        public async Task<ResponseModel> Handle(
            GetAllAdministrativeRegionsQuery request,
            CancellationToken cancellationToken)
        {
            var data = await _dbServices.GetAllAdministrativeRegionsAsync();
            if (data == null)
            {
                return ResponseModel.GetFailtureResponse("Failed To Fetch");
            }
            return new ResponseDataModel<IEnumerable<AdministrativeRegion>>
            {
                Code              = 1,
                Data              = data,
                IsSuccessResponse = true,
                Message           = "Fetch Success"
            };
        }
    }
}
