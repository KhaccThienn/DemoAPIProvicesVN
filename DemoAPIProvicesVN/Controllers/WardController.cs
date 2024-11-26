namespace DemoAPIProvicesVN.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WardController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ResponseModel>> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            pageNumber = pageNumber > 1 ? pageNumber : 1;
            pageSize   = pageSize > 10  ? pageSize   : 10;

            var query  = new GetAllWardsQuery(pageNumber, pageSize);
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
            var query = new GetWardByCodeQuery(code);
            var result = await _mediator.Send(query);
            if (!result.IsSuccess())
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("District/{code}")]
        public async Task<ActionResult<ResponseModel>> GetDisctrictsByProvinceCode(string code, int pageNumber = 1, int pageSize = 10)
        {
            pageNumber = pageNumber > 1 ? pageNumber : 1;
            pageSize   = pageSize > 10  ? pageSize   : 10;

            var query  = new GetWardsByDistrictCodeQuery(code, pageNumber, pageSize);
            var result = await _mediator.Send(query);
            if (!result.IsSuccess())
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("Search/{searchTerm}")]
        public async Task<ActionResult<ResponseModel>> SearchDistrictsAsync(string searchTerm, int pageNumber = 1, int pageSize = 10)
        {
            pageNumber = pageNumber > 1 ? pageNumber : 1;
            pageSize   = pageSize > 10  ? pageSize   : 10;

            var query  = new SearchWardsQuery(searchTerm, pageNumber, pageSize);
            var result = await _mediator.Send(query);
            if (!result.IsSuccess())
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
