using System;
using System.Collections.Generic;
using Libreria1.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria1.Context;

public partial class LibrosContext : DbContext
{

    public LibrosContext(DbContextOptions<LibrosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__author__3213E83F763A092A");

            entity.ToTable("author");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameA)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nameA");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__book__3213E83FC65F77BA");

            entity.ToTable("book");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Chapters).HasColumnName("chapters");
            entity.Property(e => e.IdAuthor).HasColumnName("idAuthor");
            entity.Property(e => e.Pages).HasColumnName("pages");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdAuthor)
                .HasConstraintName("FK__book__idAuthor__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
