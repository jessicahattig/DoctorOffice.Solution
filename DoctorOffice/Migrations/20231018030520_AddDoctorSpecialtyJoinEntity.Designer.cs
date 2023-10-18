﻿// <auto-generated />
using DoctorOffice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoctorOffice.Migrations
{
    [DbContext(typeof(DoctorOfficeContext))]
    [Migration("20231018030520_AddDoctorSpecialtyJoinEntity")]
    partial class AddDoctorSpecialtyJoinEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DoctorOffice.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DoctorName")
                        .HasColumnType("longtext");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("DoctorOffice.Models.DoctorSpecialty", b =>
                {
                    b.Property<int>("DoctorSpecialtyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("SpecialtyId")
                        .HasColumnType("int");

                    b.HasKey("DoctorSpecialtyId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("SpecialtyId");

                    b.ToTable("DoctorSpecialties");
                });

            modelBuilder.Entity("DoctorOffice.Models.Patient", b =>
                {
                    b.Property<int>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("PatientName")
                        .HasColumnType("longtext");

                    b.HasKey("PatientID");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("DoctorOffice.Models.Specialty", b =>
                {
                    b.Property<int>("SpecialtyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.HasKey("SpecialtyId");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("DoctorOffice.Models.Doctor", b =>
                {
                    b.HasOne("DoctorOffice.Models.Patient", "Patient")
                        .WithMany("Doctors")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DoctorOffice.Models.DoctorSpecialty", b =>
                {
                    b.HasOne("DoctorOffice.Models.Doctor", "Doctor")
                        .WithMany("JoinEntities")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorOffice.Models.Specialty", "Specialty")
                        .WithMany("JoinEntities")
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("DoctorOffice.Models.Doctor", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("DoctorOffice.Models.Patient", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("DoctorOffice.Models.Specialty", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
