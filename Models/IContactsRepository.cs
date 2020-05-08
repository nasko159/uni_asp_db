using System.Collections.Generic;

namespace contacts.Models
{
    public interface IContactsRepository
    {
        IEnumerable<Contact> Contacts { get; }

        Contact findById(int id);
        int add(Contact contact);

        void save(int id, Contact contact);
    }
}
