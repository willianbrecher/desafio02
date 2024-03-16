using Desafio.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.EntityFramework
{
    public class DesafioDbContext : DbContext
    {
        public DesafioDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PersonEntity> People { get; set; }
    }
}
