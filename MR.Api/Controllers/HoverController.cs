using Microsoft.AspNetCore.Mvc;
using MR.Application.Contracts;
using MR.Application.Dtos;

namespace MR.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HoverController : ControllerBase
    {
        private readonly ILogger<HoverController> _logger;
        private readonly IMoveHover _moveHover;

        public HoverController(ILogger<HoverController> logger, IMoveHover moveHover)
        {
            _logger = logger;
            _moveHover = moveHover;
        }

        [HttpPost]
        public ActionResult<List<MoveResponse>> Post(List<MoveRequest> moveRequest)
        {

            try
            {
                return Ok(_moveHover.Move(moveRequest));

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }

            return BadRequest();

        }
    }
}