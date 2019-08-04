using Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class NoteDbContext :DbContext
    {
        public NoteDbContext()
        {

        }
        public NoteDbContext(DbContextOptions<NoteDbContext> options) :base(options)
        {
            //Database.EnsureCreated();
        }
        public DbSet<MyNote> MyNotes { get; set; }

        public DbSet<MyLabel> MyLabels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //optionBuilder.UseSqlServer(@"data source =.\SQLEXPRESS;database = MyNoteDataBase ;Initial Catalog =UsersAPI; Integrated security = true;");
            modelBuilder.Entity<MyNote>().HasKey(c => new {c.NoteId});
            modelBuilder.Entity<MyNote>().Property(c => c.NoteId).ValueGeneratedNever();
            modelBuilder.Entity<MyNote>().Property(c => c.NoteName).IsRequired();
            modelBuilder.Entity<MyNote>().Property(c => c.Contact).IsRequired();
            modelBuilder.Entity<MyNote>().HasAlternateKey("Contact");
        }



    }
}
