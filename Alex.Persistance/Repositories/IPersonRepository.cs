using Alex.Entities;
using System.Collections.Generic;

namespace Alex.Persistance.Repositories
{
    public interface IPersonRepository
    {
        PersonEntity GetPerson(long id);
        IList<PersonEntity> GetAllPersons();
        void AddPerson(PersonEntity entity);
    }
}