using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonFacade(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        //public async Task<PersonResponse> FindAllAsync()
        //{
        //    var result = await _personService.FindAllAsync();
        //    var response = new PersonResponse();
        //    response.PersonObjects = new List<PersonDto>();
        //    response.PersonObjects.AddRange(result.Select(x => _mapper.Map<PersonDto>(x)));
        //    return response;
        //}

        public async Task<PersonListResponse> FindAllAsync()
        {
            try
            {
                var result = await _personService.FindAllAsync();

                var response = new PersonListResponse
                {
                    PersonObjects = new List<PersonDto>()
                };

                response.PersonObjects.AddRange(result.Select(x => _mapper.Map<PersonDto>(x)));

                return response;

            }
            catch (Exception ex)
            {
                return new PersonListResponse { Success = false, Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<PersonResponse> FindByIdAsync(int id)
        {
            try
            {
                var result = await _personService.FindByIdAsync(id);

                var response = new PersonResponse
                {
                    PersonObject = _mapper.Map<PersonDto>(result)
                };

                return response;
            }
            catch (Exception ex)
            {
                return new PersonResponse { Success = false, Errors = new List<string> { ex.Message } };
            }
        }

    }
}
