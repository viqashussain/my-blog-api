﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBlog.EntityFramework;

namespace MyBlog.EntityFramework.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190604205630_add about me table")]
    partial class addaboutmetable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyBlog.Domain.AboutMeData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HtmlContent");

                    b.HasKey("Id");

                    b.ToTable("AboutMeData");
                });

            modelBuilder.Entity("MyBlog.Domain.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArticleCategoryId");

                    b.Property<int?>("ArticleDataId");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("PreviewImageFileName");

                    b.Property<string>("PreviewText");

                    b.Property<DateTime>("PublishDate");

                    b.Property<string>("ThumbnailImageFileName");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ArticleCategoryId");

                    b.HasIndex("ArticleDataId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("MyBlog.Domain.ArticleCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ArticleCategories");
                });

            modelBuilder.Entity("MyBlog.Domain.ArticleData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArticleImageFileName");

                    b.Property<string>("Html");

                    b.HasKey("Id");

                    b.ToTable("ArticleData");
                });

            modelBuilder.Entity("MyBlog.Domain.ArticleTag", b =>
                {
                    b.Property<int>("ArticleId");

                    b.Property<int>("TagId");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("ArticleId", "TagId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("TagId");

                    b.ToTable("ArticleTags");
                });

            modelBuilder.Entity("MyBlog.Domain.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("MyBlog.Domain.Article", b =>
                {
                    b.HasOne("MyBlog.Domain.ArticleCategory", "ArticleCategory")
                        .WithMany()
                        .HasForeignKey("ArticleCategoryId");

                    b.HasOne("MyBlog.Domain.ArticleData", "ArticleData")
                        .WithMany()
                        .HasForeignKey("ArticleDataId");
                });

            modelBuilder.Entity("MyBlog.Domain.ArticleTag", b =>
                {
                    b.HasOne("MyBlog.Domain.Article", "Article")
                        .WithMany("ArticleTags")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyBlog.Domain.Tag", "Tag")
                        .WithMany("ArticleTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
