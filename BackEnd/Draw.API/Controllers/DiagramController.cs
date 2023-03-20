using Draw.BLL.Interface;
using Draw.BLL.Model;
using Draw.BLL.Service;
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


        [HttpPost("create")]
        public async Task<ActionResult<IResponse<DiagramModel>>> Create([FromBody] DiagramModel model)
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

        [HttpPut("update")]
        public async Task<ActionResult<IResponse<DiagramModel>>> Edit([FromBody] DiagramModel model)
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



    }
}
