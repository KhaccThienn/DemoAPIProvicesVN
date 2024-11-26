namespace DemoAPIProvicesVN.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DistrictController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ResponseModel>> GetAll()
        {
            var query  = new GetAllDistrictsQuery();
            var result = await _mediator.Send(query);
            if (!result.IsSuccess())
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<ResponseModel>> GetDisctrictByCode(string code)
        {
            var query  = new GetDistrictByCodeQuery(code);
            var result = await _mediator.Send(query);
            if (!result.IsSuccess())
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("Province/{code}")]
        public async Task<ActionResult<ResponseModel>> GetDisctrictsByProvinceCode(string code)
        {
            var query  = new GetDistrictsByProvinceCodeQuery(code);
            var result = await _mediator.Send(query);
            if (!result.IsSuccess())
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("Search/{searchTerm}")]
        public async Task<ActionResult<ResponseModel>> SearchDistrictsAsync(string searchTerm)
        {
            var query  = new SearchDistrictsQuery(searchTerm);
            var result = await _mediator.Send(query);
            if (!result.IsSuccess())
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
