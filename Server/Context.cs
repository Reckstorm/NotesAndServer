using Microsoft.EntityFrameworkCore;
using NotesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Context : DbContext
    {
        public DbSet<Note>? Notes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=NotesDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
