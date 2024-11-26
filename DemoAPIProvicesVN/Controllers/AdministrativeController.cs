namespace DemoAPIProvicesVN.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AdministrativeController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("Region")]
        public async Task<ActionResult<ResponseModel>> GetAllRegion()
        {
            var query  = new GetAllAdministrativeRegionsQuery();
            var result = await _mediator.Send(query);
            if (!result.IsSuccess())
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("Unit")]
        public async Task<ActionResult<ResponseModel>> GetAllUnit()
        {
            var query  = new GetAllAdministrativeUnitsQuery();
            var result = await _mediator.Send(query);
            if (!result.IsSuccess())
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
