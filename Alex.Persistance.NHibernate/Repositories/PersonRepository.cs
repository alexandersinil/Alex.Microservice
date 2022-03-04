using Alex.Entities;
using Alex.Persistance.Repositories;
using System.Collections.Generic;

namespace Alex.Persistance.NHibernate.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddPerson(PersonEntity entity)
        {
            _unitOfWork.Insert<PersonEntity, long>(entity);
        }

        public IList<PersonEntity> GetAllPersons()
        {
            return _unitOfWork.GetAll<PersonEntity, long>();
        }

        public PersonEntity GetPerson(long id)
        {
            return _unitOfWork.GetById<PersonEntity, long>(id);
        }
    }
}