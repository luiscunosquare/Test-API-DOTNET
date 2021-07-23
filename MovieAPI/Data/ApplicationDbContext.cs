using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;
using MovieAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {       
        }

        public DbSet<Category> Category { get; set; }
    }
}
