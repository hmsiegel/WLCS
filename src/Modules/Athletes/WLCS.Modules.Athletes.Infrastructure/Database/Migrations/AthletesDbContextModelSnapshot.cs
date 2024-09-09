﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WLCS.Modules.Athletes.Infrastructure.Database;

#nullable disable

namespace WLCS.Modules.Athletes.Infrastructure.Database.Migrations
{
    [DbContext(typeof(AthletesDbContext))]
    partial class AthletesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("athletes")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WLCS.Common.Infrastructure.Outbox.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("jsonb")
                        .HasColumnName("content");

                    b.Property<string>("Error")
                        .HasColumnType("text")
                        .HasColumnName("error");

                    b.Property<DateTime>("OccurredOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("occurred_on_utc");

                    b.Property<DateTime?>("ProcessedOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("processed_on_utc");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_outbox_messages");

                    b.ToTable("outbox_messages", "athletes");
                });

            modelBuilder.Entity("WLCS.Modules.Athletes.Domain.Athletes.Athlete", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Coach")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("coach");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("first_name");

                    b.Property<int>("Gender")
                        .HasColumnType("integer")
                        .HasColumnName("gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("last_name");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("phone_number");

                    b.HasKey("Id")
                        .HasName("pk_athletes");

                    b.ToTable("athletes", "athletes");
                });

            modelBuilder.Entity("WLCS.Modules.Athletes.Domain.Athletes.Athlete", b =>
                {
                    b.OwnsOne("WLCS.Modules.Athletes.Domain.Athletes.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("AthleteId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("city");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("country");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("character varying(2)")
                                .HasColumnName("state");

                            b1.Property<string>("Street1")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("street1");

                            b1.Property<string>("Street2")
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("street2");

                            b1.Property<string>("Street3")
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("street3");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("character varying(10)")
                                .HasColumnName("zip_code");

                            b1.HasKey("AthleteId");

                            b1.ToTable("athletes", "athletes");

                            b1.WithOwner()
                                .HasForeignKey("AthleteId")
                                .HasConstraintName("fk_athletes_athletes_id");
                        });

                    b.OwnsOne("WLCS.Modules.Athletes.Domain.Athletes.ValueObjects.Club", "Club", b1 =>
                        {
                            b1.Property<Guid>("AthleteId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("ClubCode")
                                .IsRequired()
                                .HasMaxLength(8)
                                .HasColumnType("character varying(8)")
                                .HasColumnName("club_code");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("club_name");

                            b1.HasKey("AthleteId");

                            b1.ToTable("athletes", "athletes");

                            b1.WithOwner()
                                .HasForeignKey("AthleteId")
                                .HasConstraintName("fk_athletes_athletes_id");
                        });

                    b.OwnsOne("WLCS.Modules.Athletes.Domain.Athletes.ValueObjects.Membership", "Membership", b1 =>
                        {
                            b1.Property<Guid>("AthleteId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<DateTime?>("ExpirationDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("member_expiration_date");

                            b1.Property<string>("MembershipId")
                                .IsRequired()
                                .HasMaxLength(8)
                                .HasColumnType("character varying(8)")
                                .HasColumnName("memberId");

                            b1.HasKey("AthleteId");

                            b1.HasIndex("MembershipId")
                                .IsUnique()
                                .HasDatabaseName("ix_athletes_member_id");

                            b1.ToTable("athletes", "athletes");

                            b1.WithOwner()
                                .HasForeignKey("AthleteId")
                                .HasConstraintName("fk_athletes_athletes_id");
                        });

                    b.Navigation("Address");

                    b.Navigation("Club");

                    b.Navigation("Membership")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
