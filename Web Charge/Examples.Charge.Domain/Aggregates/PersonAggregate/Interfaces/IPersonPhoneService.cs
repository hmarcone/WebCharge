using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneService
    {
        Task<List<PersonPhone>> FindAllAsync();
        Task<List<PersonPhone>> FindByIdPersonPhoneAsync(int id);
        Task<PersonPhone> FindAsync(PersonPhone personPhone);
        Task<PersonPhone> UpdateAsync(PersonPhone personPhone);
        Task<PersonPhone> AddAsync(PersonPhone personPhone);
        Task<PersonPhone> RemoveAsync(PersonPhone personPhone);
    }
}
