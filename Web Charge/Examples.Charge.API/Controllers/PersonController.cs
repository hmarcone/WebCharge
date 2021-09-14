using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {
        private readonly IPersonFacade _personFacade;

        public PersonController(IPersonFacade personFacade)
        {
            _personFacade = personFacade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonListResponse>> Get() => Response(await _personFacade.FindAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonResponse>> Get(int id) => Response(await _personFacade.FindByIdAsync(id));
    }
}
