﻿using ClinicManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence
{
    public class ClinicDbContext : DbContext
    {
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options)
            : base(options)
        {

        }

        public DbSet<CustomerService> CustomerServices { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Configuração de CustomerService
            builder
                .Entity<CustomerService>(e =>
                {
                    e.HasKey(c => c.Id);

                    e.HasOne(c => c.Patient)
                        .WithMany(p => p.CustomerServices)
                        .HasForeignKey(c => c.PatientId)
                        .OnDelete(DeleteBehavior.Restrict);
                        

                    e.HasOne(c => c.Doctor)
                        .WithMany(d => d.CustomerServices)
                        .HasForeignKey(c => c.DoctorId)
                        .OnDelete(DeleteBehavior.Restrict);

                    e.HasOne(s => s.Service)
                        .WithMany(s => s.CustomerServices)
                        .HasForeignKey(c => c.ServiceId)
                        .OnDelete(DeleteBehavior.Restrict);

                    e.HasIndex(c => c.PatientId);
                    e.HasIndex(c => c.DoctorId);
                    e.HasIndex(c => c.ServiceId);
                });

            // Configuração para Doctor
            builder
                .Entity<Doctor>(e =>
                {
                    e.HasKey(d => d.Id);

                    e.Property(d => d.Name)
                        .IsRequired()
                        .HasMaxLength(100);
                    
                    e.Property(d => d.LastName)
                        .IsRequired()
                        .HasMaxLength(100);

                    e.Property(d => d.CPF)
                        .IsRequired()
                        .HasMaxLength(11);

                    e.Property(d => d.Email)
                        .IsRequired()
                        .HasMaxLength(100);

                    e.Property(d => d.CRM)
                        .IsRequired()
                        .HasMaxLength(20);

                    e.HasIndex(d => d.CPF)
                        .IsUnique();

                    e.HasIndex(d => d.CRM)
                        .IsUnique();

                    e.HasIndex(d => d.Email)
                        .IsUnique();

                    e.HasMany(d => d.CustomerServices) 
                        .WithOne(c => c.Doctor)
                        .HasForeignKey(c => c.DoctorId)
                        .OnDelete(DeleteBehavior.Restrict);

                    e.HasMany(d => d.Patients)
                        .WithOne(p => p.Doctor)
                        .HasForeignKey(p => p.DoctorId);
                });

            // Configuração para Patient
            builder
                .Entity<Patient>(e =>
                {
                    e.HasKey(p => p.Id);

                    e.HasOne(p => p.Doctor)
                        .WithMany(d => d.Patients)
                        .HasForeignKey(p => p.DoctorId)
                        .OnDelete(DeleteBehavior.Restrict);

                    e.HasMany(p => p.CustomerServices)
                        .WithOne(cs => cs.Patient)
                        .HasForeignKey(cs => cs.PatientId)
                        .OnDelete(DeleteBehavior.Restrict);

                    e.HasMany(p => p.Services)
                        .WithOne(s => s.Patients)
                        .HasForeignKey(s => s.PatientId)
                        .OnDelete(DeleteBehavior.Cascade);

                    e.Property(p => p.Name)
                        .IsRequired()
                        .HasMaxLength(100);

                    e.Property(p => p.LastName)
                        .IsRequired()
                        .HasMaxLength(100);

                    e.HasIndex(p => p.CPF).IsUnique();
                        

                });

            // Configuração Service
            builder
                .Entity<Service>(e =>
                {
                    e.HasKey(s => s.Id);

                    e.HasMany(s => s.CustomerServices)
                        .WithOne(cs => cs.Service)
                        .HasForeignKey(cs => cs.ServiceId);

                    e.HasOne(s => s.Patients)
                        .WithMany(p => p.Services)
                        .HasForeignKey(s => s.PatientId);

                });

            base.OnModelCreating(builder);
        }
    }
}
