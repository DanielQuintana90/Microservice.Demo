﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microservices.Demo.Report.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Demo.Report.API.Infrastructure.Data.Context
{
    public partial class ReportDbContext : DbContext
    {
        public ReportDbContext()
        {
        }

        public ReportDbContext(DbContextOptions<ReportDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Offer> Offer { get; set; }
        public virtual DbSet<OfferCover> OfferCover { get; set; }
        public virtual DbSet<OfferStatus> OfferStatus { get; set; }
        public virtual DbSet<Policy> Policy { get; set; }
        public virtual DbSet<PolicyCover> PolicyCover { get; set; }
        public virtual DbSet<PolicyHolder> PolicyHolder { get; set; }
        public virtual DbSet<PolicyStatus> PolicyStatus { get; set; }
        public virtual DbSet<PolicyValidityPeriod> PolicyValidityPeriod { get; set; }
        public virtual DbSet<PolicyVersion> PolicyVersion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.City)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Type)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.Property(e => e.AgentLogin)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Number)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.OfferStatus)
                    .WithMany(p => p.Offer)
                    .HasForeignKey(d => d.OfferStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfferOfferStatus");

                entity.HasOne(d => d.PolicyHolder)
                    .WithMany(p => p.Offer)
                    .HasForeignKey(d => d.PolicyHolderId)
                    .HasConstraintName("FK_OfferPolicyHolder");

                entity.HasOne(d => d.PolicyValidityPeriod)
                    .WithMany(p => p.Offer)
                    .HasForeignKey(d => d.PolicyValidityPeriodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfferPolicyValidityPeriod");
            });

            modelBuilder.Entity<OfferCover>(entity =>
            {
                entity.Property(e => e.Code)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.OfferCover)
                    .HasForeignKey(d => d.OfferId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfferCoverOffer");
            });

            modelBuilder.Entity<OfferStatus>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.Property(e => e.AgentLogin)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Number)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.PolicyStatus)
                    .WithMany(p => p.Policy)
                    .HasForeignKey(d => d.PolicyStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PolicyPolicyStatus");
            });

            modelBuilder.Entity<PolicyCover>(entity =>
            {
                entity.Property(e => e.Code)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Premium).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.PolicyValidityPeriod)
                    .WithMany(p => p.PolicyCover)
                    .HasForeignKey(d => d.PolicyValidityPeriodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PolicyCoverPolicyValidityPeriod");

                entity.HasOne(d => d.PolicyVersion)
                    .WithMany(p => p.PolicyCover)
                    .HasForeignKey(d => d.PolicyVersionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PolicyCoverPolicyVersion");
            });

            modelBuilder.Entity<PolicyHolder>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Pesel)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.PolicyHolder)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PolicyHolderAddress");
            });

            modelBuilder.Entity<PolicyStatus>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PolicyVersion>(entity =>
            {
                entity.Property(e => e.TotalPremiumAmount).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.CoverPeriodPolicyValidityPeriod)
                    .WithMany(p => p.PolicyVersionCoverPeriodPolicyValidityPeriod)
                    .HasForeignKey(d => d.CoverPeriodPolicyValidityPeriodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PolicyVersionCoverPeriodPolicyValidityPeriod");

                entity.HasOne(d => d.PolicyHolder)
                    .WithMany(p => p.PolicyVersion)
                    .HasForeignKey(d => d.PolicyHolderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PolicyVersionPolicyHolder");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.PolicyVersion)
                    .HasForeignKey(d => d.PolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PolicyVersionPolicy");

                entity.HasOne(d => d.VersionValidityPeriodPolicyValidityPeriod)
                    .WithMany(p => p.PolicyVersionVersionValidityPeriodPolicyValidityPeriod)
                    .HasForeignKey(d => d.VersionValidityPeriodPolicyValidityPeriodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PolicyVersionVersionValidityPeriodPolicyValidityPeriod");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}