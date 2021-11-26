using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EfCore
{
    public class EfPersonRepository : IPersonRepository
    {
        public void AddPerson(Person entity)
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public Person GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void SavePerson(Person entity)
        {
            throw new NotImplementedException();
        }

        public void UpdatePerson(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
