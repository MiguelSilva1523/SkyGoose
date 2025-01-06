using Microsoft.AspNetCore.Mvc;
using SkyGoose.Models;
using System.Linq;

namespace SkyGoose.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JetController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public JetController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetJets()
        {
            return Ok(_context.Jets.ToList());
        }

        [HttpPost("contact")]
        public IActionResult SaveContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok(new { message = "Contact saved successfully." });
        }
    }
}
