using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalWeb_Sharan.Models;

namespace PersonalWeb_Sharan.Data
{
    public class PersonalWeb_SharanContext : DbContext
    {
        public PersonalWeb_SharanContext (DbContextOptions<PersonalWeb_SharanContext> options)
            : base(options)
        {
        }

        public DbSet<PersonalWeb_Sharan.Models.Comment> Comment { get; set; } = default!;
    }
}
