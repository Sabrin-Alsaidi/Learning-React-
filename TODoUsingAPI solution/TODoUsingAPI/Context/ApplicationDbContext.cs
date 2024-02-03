using System;
using Microsoft.EntityFrameworkCore;
using TODoUsingAPI.Models;

namespace TODoUsingAPI.Context
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base (options)
		{
		}
        public DbSet<Todo> todo { get; set; }

    }
}

