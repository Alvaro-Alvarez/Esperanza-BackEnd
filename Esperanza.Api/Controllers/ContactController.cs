using Esperanza.Core.Interfaces.Business;
using Esperanza.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Esperanza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost("SendMessage")]
        public async Task<ActionResult> SendMessage(ContactMessage message)
        {
            await _contactService.SendContactMessage(message);
            return Ok();
        }
    }
}
