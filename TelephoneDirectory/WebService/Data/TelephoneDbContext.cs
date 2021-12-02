using Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebService.Data
{
    public class TelephoneDbContext:DbContext
    {
        public TelephoneDbContext(DbContextOptions<TelephoneDbContext> options) : base(options) { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
