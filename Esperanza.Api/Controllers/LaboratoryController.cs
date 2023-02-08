using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Esperanza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaboratoryController : ControllerBase
    {
        private readonly ILaboratoryService LaboratoryService;

        public LaboratoryController(
            ILaboratoryService laboratoryService
            )
        {
            LaboratoryService = laboratoryService;
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await LaboratoryService.GetAll());
        }

        [HttpGet("GetTopFive")]
        public async Task<ActionResult> GetTopFive()
        {
            return Ok(await LaboratoryService.GetTopFive());
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            return Ok(await LaboratoryService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Laboratory laboratory)
        {
            await LaboratoryService.Insert(laboratory, User.Identity.Name);
            return Ok();
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Put([FromBody] Laboratory laboratory)
        {
            await LaboratoryService.Update(laboratory, User.Identity.Name);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(string id)
        {
            await LaboratoryService.Delete(id, User.Identity.Name);
            return Ok();
        }
    }
}
