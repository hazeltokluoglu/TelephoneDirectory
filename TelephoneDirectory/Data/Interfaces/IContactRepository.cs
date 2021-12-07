using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IContactRepository
    {
        Contact GetById(int Id);
        IQueryable<Contact> GetAll();
        void AddContact(Contact entity);
        void UpdateContact(Contact entity);
        void DeleteContact(int Id);
        void SaveContact(Contact entity);
    }
}
