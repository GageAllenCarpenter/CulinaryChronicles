using Microsoft.EntityFrameworkCore;
using Recipes.API.Models;
using System.Reflection;
using System.Security.Principal;

namespace Recipes.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<T> GetDbSet<T>() where T : class, IEntityBase
        {
            return Set<T>();
        }

        /// <summary>
        /// Instatiate the DbSet properties through reflection
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Get all types from the assembly that implement the IEntityBase interface
            var entityTypes = typeof(IEntityBase).Assembly?.GetTypes()
                .Where(t => !t.IsAbstract && typeof(IEntityBase).IsAssignableFrom(t));

            // Add DbSet properties for each entity type found
            if (entityTypes != null)
            {
                foreach (var entityType in entityTypes)
                {
                    modelBuilder.Entity(entityType);
                }
            }
        }
    }
}
