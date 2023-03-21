using Draw.BLL.DiagramBLL;
using Draw.BLL.ReponseBLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Draw.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles ="User")]
    [ApiController]
    public class DiagramController : ControllerBase
    {

        private readonly DiagramService _diagramService;
        public DiagramController(DiagramService _diagramService)
        {
            this._diagramService = _diagramService;
        }


        [HttpPost()]
        public async Task<ActionResult<IResponse<DiagramDTO>>> Create([FromBody] DiagramModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           var Reponse=  this._diagramService.Create(model, User.FindFirst("uid").Value);
            if (!Reponse.IsSuccess)
            {
                return BadRequest(Reponse);
            }

            return Ok(Reponse);
        }

        [HttpPut()]
        public async Task<ActionResult<IResponse<DiagramDTO>>> Edit([FromBody] DiagramModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Reponse = this._diagramService.Update(model, User.FindFirst("uid").Value);
            if (!Reponse.IsSuccess)
            {
                return BadRequest(Reponse);
            }
            return Ok(Reponse);

        }

        [HttpDelete()]
        public async Task<ActionResult<IResponse<DiagramDTO>>> Delete([FromQuery]int id)
        {
            var Reponse = this._diagramService.Remove(id, User.FindFirst("uid").Value);
            if (!Reponse.IsSuccess)
            {
                return BadRequest(Reponse);
            }
            return Ok(Reponse);

        }

        [HttpGet()]
        public async Task<ActionResult<IResponse<DiagramDTO>>> Get([FromQuery]int id)
        {
            var Reponse = this._diagramService.Get(id, User.FindFirst("uid").Value);
            if (!Reponse.IsSuccess)
            {
                return BadRequest(Reponse);
            }
            return Ok(Reponse);

        }

        [HttpGet("list")]
        public async Task<ActionResult<IResponse<List<DiagramDTO>>>> List()
        {
           
            var Reponse =await this._diagramService.SelectByUser( User.FindFirst("uid").Value);
            if (!Reponse.IsSuccess)
            {
                return BadRequest(Reponse);
            }
            return Ok(Reponse);
        }



    }
}
