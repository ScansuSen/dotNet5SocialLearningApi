using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialLearning.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace SocialLearning.DataAccess
{
   public class SLDbContext : IdentityDbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        
        


              => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=SocialLearning;User Id=postgres;Password=postgre.9802;");

       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

       
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }


        public SLDbContext(DbContextOptions<SLDbContext> options)
            : base(options)
        {
        }

       public SLDbContext()
        {
        }

   


        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Answer> Answers { get; set; }
    


    }

}
    
    
   

