using Microsoft.EntityFrameworkCore;
using RecipeBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Data
{
    public class RecipeBookDBContext: DbContext
    {
        public RecipeBookDBContext(DbContextOptions<RecipeBookDBContext> options) : base(options)
        {

        }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .HasMany(r => r.Ingredients)
                .WithMany(i => i.Recipes)
                .UsingEntity<IngredientUsage>(
                    j => j.HasOne(iu => iu.Ingredient).WithMany(i => i.IngredientUsages),
                    j => j.HasOne(iu => iu.Recipe).WithMany(r => r.IngredientUsages)
                );
        }
    }
}
