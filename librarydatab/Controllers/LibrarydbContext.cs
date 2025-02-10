﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RestFull.Models;

public partial class LibrarydbContext : DbContext
{
    public LibrarydbContext()
    {
    }

    public LibrarydbContext(DbContextOptions<LibrarydbContext> options)
        : base(options)
    {
    }

   

    public virtual DbSet<Book> Books { get; set; }

    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=librarydb;user=root;password=;ssl mode=none;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PRIMARY");

            entity.ToTable("books");

            entity.HasIndex(e => e.AuthorId, "author_id");

            entity.HasIndex(e => e.CategoryId, "category_id");

            entity.Property(e => e.BookId)
                .HasColumnType("int(11)")
                .HasColumnName("book_id");
            entity.Property(e => e.AuthorId)
                .HasColumnType("int(11)")
                .HasColumnName("author_id");
            entity.Property(e => e.CategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("category_id");
            entity.Property(e => e.PublishDate)
                .HasColumnType("date")
                .HasColumnName("publish_date");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");

        });

      

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
