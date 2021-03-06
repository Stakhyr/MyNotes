using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNotes.Data
{
    public class MyNotesDbContext:DbContext
    {
        public MyNotesDbContext(DbContextOptions<MyNotesDbContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }
    }
}
