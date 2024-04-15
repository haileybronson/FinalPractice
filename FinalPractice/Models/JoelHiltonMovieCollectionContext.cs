using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FinalPractice.Models;

public partial class JoelHiltonMovieCollectionContext : DbContext
{
    public JoelHiltonMovieCollectionContext()
    {
    }

    public JoelHiltonMovieCollectionContext(DbContextOptions<JoelHiltonMovieCollectionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Name=MovieConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasOne(d => d.Category).WithMany(p => p.Movies).HasForeignKey(d => d.CategoryId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
