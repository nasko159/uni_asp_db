using contacts.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace contacts.Models
{
    public class InDBContactsRepository : IContactsRepository
    {

        private readonly ContactContext ctx;

        public InDBContactsRepository(ContactContext context) {
            ctx = context;
        }

        public IEnumerable<Contact> Contacts => ctx.Contact.ToListAsync().Result;

        public Contact findById(int id) => ctx.Contact.FirstOrDefaultAsync(m => m.Id == id).Result;
        public int add(Contact contact)
        {
            var item = ctx.Contact.Add(contact);
            
            return item.Entity.Id;
        }

        public void save(int id, Contact contact){
            ctx.Entry(findById(id)).CurrentValues.SetValues(contact);
            ctx.SaveChanges();
        }
    }
}
