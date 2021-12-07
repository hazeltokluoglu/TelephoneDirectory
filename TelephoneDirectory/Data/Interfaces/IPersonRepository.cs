using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Interfaces
{
    public interface IPersonRepository
    {
        Person GetById(int Id);
        IQueryable<Person> GetAll();
        void AddPerson(Person entity);
        void UpdatePerson(Person entity);
        void DeletePerson(int Id);
        void SavePerson(Person entity);
    }
}
