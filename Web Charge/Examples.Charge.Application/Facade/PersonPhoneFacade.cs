using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonPhoneFacade : IPersonPhoneFacade
    {
        private IPersonPhoneService _personPhoneService;
        private IMapper _mapper;

        public PersonPhoneFacade(IPersonPhoneService personPhoneService, IMapper mapper)
        {
            _personPhoneService = personPhoneService;
            _mapper = mapper;
        }

        public async Task<PersonPhoneListResponse> FindAllAsync()
        {
            try
            {
                var result = await _personPhoneService.FindAllAsync();

                var response = new PersonPhoneListResponse();
                response.PersonPhoneObjects = new List<PersonPhoneDto>();
                response.PersonPhoneObjects.AddRange(result.Select(x => _mapper.Map<PersonPhoneDto>(x)));
                
                return response;
            }
            catch (Exception ex)
            {
                return new PersonPhoneListResponse { Success = false, Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<PersonPhoneListResponse> FindByIdPersonPhoneAsync(int id)
        {
            try
            {
                var result = await _personPhoneService.FindByIdPersonPhoneAsync(id);

                var response = new PersonPhoneListResponse();
                response.PersonPhoneObjects = new List<PersonPhoneDto>();
                response.PersonPhoneObjects.AddRange(result.Select(x => _mapper.Map<PersonPhoneDto>(x)));

                return response;
            }
            catch (Exception ex)
            {
                return new PersonPhoneListResponse { Success = false, Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<PersonPhoneResponse> AddAsync(PersonPhoneDto personPhone)
        {
            try
            {
                var personPhoneFound = await _personPhoneService.FindAsync(_mapper.Map<PersonPhone>(personPhone));

                if (personPhoneFound != null)
                    return new PersonPhoneResponse { Success = false, Errors = new List<string> { "Telefone Pessoal já existe." } };

                var personPhoneAdded = await _personPhoneService.AddAsync(_mapper.Map<PersonPhone>(personPhone));

                return new PersonPhoneResponse { PersonPhoneObject = _mapper.Map<PersonPhoneDto>(personPhoneAdded) };
            }
            catch (Exception ex)
            {
                return new PersonPhoneResponse { Success = false, Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<PersonPhoneResponse> UpdateAsync(PersonPhoneDto personPhoneOld, PersonPhoneDto personPhoneNew)
        {
            try
            {
                var personPhoneFound = await _personPhoneService.FindAsync(_mapper.Map<PersonPhone>(personPhoneOld));

                if (personPhoneFound == null)
                    return new PersonPhoneResponse { Success = false, Errors = new List<string> { "Telefone pessoal não existe." } };

                personPhoneNew.BusinessEntityId = personPhoneFound.BusinessEntityId;
                var personPhoneRemoved = await _personPhoneService.RemoveAsync(personPhoneFound);
                var personPhoneAdded = await _personPhoneService.AddAsync(_mapper.Map<PersonPhone>(personPhoneNew));

                return new PersonPhoneResponse { PersonPhoneObject = _mapper.Map<PersonPhoneDto>(personPhoneAdded) };
            }
            catch (Exception ex)
            {
                return new PersonPhoneResponse { Success = false, Errors = new List<string> { ex.Message } };
            }
        }


        public async Task<PersonPhoneResponse> RemoveAsync(PersonPhoneDto personPhone)
        {
            try
            {
                var personPhoneFound = await _personPhoneService.FindAsync(_mapper.Map<PersonPhone>(personPhone));

                if (personPhoneFound == null)
                    return new PersonPhoneResponse { Success = false, Errors = new List<string> { "O telefone pessoal não existe." } };

                var personPhoneRemoved = await _personPhoneService.RemoveAsync(personPhoneFound);

                return new PersonPhoneResponse { PersonPhoneObject = _mapper.Map<PersonPhoneDto>(personPhoneRemoved) };
            }
            catch (Exception ex)
            {
                return new PersonPhoneResponse { Success = false, Errors = new List<string> { ex.Message } };
            }
        }
    }
}
