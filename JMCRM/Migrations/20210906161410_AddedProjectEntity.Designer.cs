﻿// <auto-generated />
using JMCRM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JMCRM.Migrations
{
    [DbContext(typeof(JMCRMDbContext))]
    [Migration("20210906161410_AddedProjectEntity")]
    partial class AddedProjectEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JMCRM.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ContactId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("JMCRM.Models.Project", b =>
                {
                    b.Property<string>("ProjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Control")
                        .HasColumnType("bit");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("JMCRM.Models.Contact", b =>
                {
                    b.HasOne("JMCRM.Models.Project", null)
                        .WithMany("Contacts")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("JMCRM.Models.Project", b =>
                {
                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}
