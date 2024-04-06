using Oggetti_Usati.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class dbcontext : IdentityDbContext{
    public dbcontext(DbContextOptions<dbcontext> options) : base(options){}

    public DbSet<Oggetto> Oggetti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
     => options.UseSqlite(@"Data Source=Models/database.db");
}