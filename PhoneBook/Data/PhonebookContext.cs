using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Data
{
    using Phonebook.Data.Entities;

    public class PhonebookContext : DbContext
    {
        public PhonebookContext(DbContextOptions<PhonebookContext> options) : base(options)
        {
        }

        public DbSet<PhoneContact> PhoneContacts { get; set; }
    }
}
