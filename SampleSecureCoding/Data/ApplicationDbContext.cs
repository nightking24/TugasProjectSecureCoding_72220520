using System;
using Microsoft.EntityFrameworkCore;
using SampleSecureCoding.Models;

namespace SampleSecureCoding.Data;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; } = null!;
    }
