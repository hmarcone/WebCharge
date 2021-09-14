using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    {
        Task<PersonListResponse> FindAllAsync();
        Task<PersonResponse> FindByIdAsync(int id);
        //ToDo: retirar depois
        //Task<PersonPhoneResponse> AddAsync(PersonPhoneDto personPhone);
    }
}