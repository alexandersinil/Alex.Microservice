using Alex.Persistance.Repositories;
using Alex.Model.Dto;
using Alex.Model;
using System.Collections.Generic;
using Alex.Entities;

namespace Alex.BusinessLogic
{
    public class Service : IService
    {
        private readonly IPersonRepository _personRepository;

        public Service(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void AddPerson(PersonDto request)
        {
            var entity = new PersonEntity
            {
                Id = request.Id,
                FisrtName = request.FisrtName,
                LastName = request.LastName,
                Age = request.Age
            };
            _personRepository.AddPerson(entity);
        }

        public List<PersonDto> GetAllPersons()
        {
            List<PersonDto> dtos = new List<PersonDto>();
            var entities = _personRepository.GetAllPersons();
            foreach (var entity in entities)
            {
                dtos.Add(new PersonDto
                {
                    Id = entity.Id,
                    FisrtName = entity.FisrtName,
                    LastName = entity.LastName,
                    Age = entity.Age
                });
            }
            return dtos;
        }

        public PersonDto GetPerson(long id)
        {
            var entity = _personRepository.GetPerson(id);
            return new PersonDto
            {
                Id = entity.Id,
                FisrtName = entity.FisrtName,
                LastName = entity.LastName,
                Age = entity.Age
            };
        }

        public int Multiple(int x, int y)
        {
            return x * y;
        }
    }
}