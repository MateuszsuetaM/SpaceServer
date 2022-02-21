using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadFilesServer.Models;

namespace UploadFilesServer.Context
{
    public class UserContext: IdentityDbContext<User>
    {
        public UserContext(DbContextOptions options)
            :base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            var server = "172.18.0.2";
            //            var server = "localhost";
            //            var server = "192.168.0.150";
            //var port = "5432";
            //var name = "your_db";
            //var user = "your_user";
            //var password = "your_password";

            var port = "5432";
            var name = "test1";
            var user = "test";
            var password = "test";


            optionsBuilder.UseNpgsql($"Host={server};Port={port};Database={name};Username={user};Password={password}");
            //optionsBuilder.UseNpgsql();
        }
        */
    }
}
