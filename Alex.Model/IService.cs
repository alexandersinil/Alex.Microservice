using Alex.Model.Dto;
using System.Collections.Generic;

namespace Alex.Model
{
    public interface IService
    {
        int Multiple(int x, int y);

        PersonDto GetPerson(long id);
        List<PersonDto> GetAllPersons();
        void AddPerson(PersonDto request);
    }
}