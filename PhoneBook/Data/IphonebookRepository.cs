using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Data
{
    using Phonebook.Data.Entities;

    public interface IPhonebookRepository
    {
        IEnumerable<PhoneContact> GetAllContacts();
        PhoneContact GetContactById(int id);
        void AddContact(PhoneContact newContact);
        bool SaveAll();
        void Delete(int id);
    }
}
