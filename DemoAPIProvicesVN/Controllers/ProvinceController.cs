namespace DemoAPIProvicesVN.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProvinceController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ResponseModel>> GetAllProvinces()
        {
            var query  = new GetAllProvincesQuery();
            var result = await _mediator.Send(query);
            if (!result.IsSuccess())
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<ResponseModel>> GetProviceByCode(string code)
        {
            var query = new GetProvinceByCodeQuery(code);
            var result = await _mediator.Send(query);
            if (!result.IsSuccess())
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("Region/{id:int}")]
        public async Task<ActionResult<ResponseModel>> GetProviceByRegionCode(int id)
        {
            var query = new GetAllProvincesByAdminisTrativeRegionCodeQuery(id);
            var result = await _mediator.Send(query);
            if (!result.IsSuccess())
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("Unit/{id:int}")]
        public async Task<ActionResult<ResponseModel>> GetProviceByUnitCode(int id)
        {
            var query = new GetAllProvincesByAdminisTrativeUnitCodeQuery(id);
            var result = await _mediator.Send(query);
            if (!result.IsSuccess())
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("Search/{searchTerm}")]
        public async Task<ActionResult<ResponseModel>> GetProviceByUnitCode(string searchTerm)
        {
            var query = new SearchProvincesQuery(searchTerm);
            var result = await _mediator.Send(query);
            if (!result.IsSuccess())
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
