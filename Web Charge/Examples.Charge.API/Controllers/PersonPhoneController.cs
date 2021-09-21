using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPhoneController : BaseController
    {
        private readonly IPersonPhoneFacade _facade;

        public PersonPhoneController(IPersonPhoneFacade facade)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonPhoneListResponse>> Get() //=> Response(await _facade.FindAllAsync());
        {
            return Response(await _facade.FindAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonPhoneListResponse>> GetByPersonId([FromRoute] int id)  // =>  Response(await _facade.FindByPersonIdAsync(id));
        {
            return Response(await _facade.FindByIdPersonPhoneAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<PersonPhoneListResponse>> Post([FromBody] PersonPhoneDto personPhone) // => Response(await _facade.AddAsync(personPhone));
        {
            return Response(await _facade.AddAsync(personPhone));
        }

        [HttpPut]
        public async Task<ActionResult<PersonPhoneListResponse>> Put(int businessEntityId, string phoneNumber, 
            int phoneNumberTypeId, [FromBody] PersonPhoneDto personPhoneNew)
        {
            return Response(await _facade.UpdateAsync(
                      new PersonPhoneDto
                      {
                          BusinessEntityId = businessEntityId,
                          PhoneNumber = phoneNumber,
                          PhoneNumberTypeId = phoneNumberTypeId
                      },
                      personPhoneNew
                  ));
        }

        [HttpDelete]
        public async Task<ActionResult<PersonPhoneListResponse>> Delete(int businessEntityId, string phoneNumber, int phoneNumberTypeId) //=>
        {
            return Response(await _facade.RemoveAsync(
                new PersonPhoneDto
                {
                    BusinessEntityId = businessEntityId,
                    PhoneNumber = phoneNumber,
                    PhoneNumberTypeId = phoneNumberTypeId
                }
            ));

        }
    }
}
