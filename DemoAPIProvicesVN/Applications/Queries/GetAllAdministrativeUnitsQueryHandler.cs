namespace DemoAPIProvicesVN.Applications.Queries
{
    public record GetAllAdministrativeUnitsQuery : IRequest<ResponseModel>;

    public class GetAllAdministrativeUnitsQueryHandler(IDbServices _dbServices) : IRequestHandler<GetAllAdministrativeUnitsQuery, ResponseModel>
    {
        public async Task<ResponseModel> Handle(GetAllAdministrativeUnitsQuery request, CancellationToken cancellationToken)
        {
            var data = await _dbServices.GetAllAdministrativeUnitsAsync();
            if (data == null)
            {
                return ResponseModel.GetFailtureResponse("Failed To Fetch");
            }
            return new ResponseDataModel<IEnumerable<AdministrativeUnit>> 
            { 
                Code              = 1,
                Data              = data,
                IsSuccessResponse = true,
                Message           = "Fetch Success"
            };
        }
    }
}
