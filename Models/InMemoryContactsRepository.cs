using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace contacts.Models
{
    public class InMemoryContactsRepository : IContactsRepository
    {
        private ConcurrentDictionary<int, Contact> contacts;

        public InMemoryContactsRepository() {
            contacts = new ConcurrentDictionary<int, Contact>();
            contacts.TryAdd(0, new Contact {
                Id = 0,
                FirstName = "Анелия",
                LastName = "Петрова",
                Email = "ani@example.com",
                BirthDate = new DateTime(1982, 6, 23)
            });
            contacts.TryAdd(1, new Contact {
                Id = 1,
                FirstName = "Иван",
                LastName = "Иванов",
                Email = "ivan@example.com",
                BirthDate = new DateTime(1982, 6, 22)
            });
        }

        public IEnumerable<Contact> Contacts => contacts.Values;

        public Contact findById(int id) => contacts[id];
        public int add(Contact contact)
        {
            int newId = contacts.Count;
            contact.Id = newId;
            contacts[newId] = contact;

            return newId;
        }

        public void save(int id, Contact contact) => contacts[id] = contact;
    }
}
