﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WiFind.Data;

#nullable disable

namespace WiFind.Migrations
{
    [DbContext(typeof(WiFindDbContext))]
    [Migration("20230415225924_added_payment_and_wifi_connection_tables")]
    partial class added_payment_and_wifi_connection_tables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WiFind.Entities.Payment", b =>
                {
                    b.Property<Guid>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimeModified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<double>("PaymentAmount")
                        .HasColumnType("float");

                    b.Property<Guid>("WiFindUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WifiId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PaymentId");

                    b.HasIndex("WiFindUserId");

                    b.HasIndex("WifiId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("WiFind.Entities.WiFindUser", b =>
                {
                    b.Property<Guid>("WiFindUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimeModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WifiId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("WiFindUserId");

                    b.HasIndex("WifiId");

                    b.ToTable("WifindUsers");
                });

            modelBuilder.Entity("WiFind.Entities.Wifi", b =>
                {
                    b.Property<Guid>("WifiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AmountEarned")
                        .HasColumnType("float");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfUsers")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Speed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WiFindUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WifiName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WifiId");

                    b.HasIndex("WiFindUserId");

                    b.ToTable("Wifis");
                });

            modelBuilder.Entity("WiFind.Entities.WifiConnection", b =>
                {
                    b.Property<Guid>("WifiConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ConnectionEndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ConnectionStartTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimeModified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsExpired")
                        .HasColumnType("bit");

                    b.Property<Guid>("WiFindUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WifiId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("WifiConnectionId");

                    b.HasIndex("WiFindUserId");

                    b.HasIndex("WifiId");

                    b.ToTable("WifiConnections");
                });

            modelBuilder.Entity("WiFind.Entities.Payment", b =>
                {
                    b.HasOne("WiFind.Entities.WiFindUser", "WiFindUser")
                        .WithMany()
                        .HasForeignKey("WiFindUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WiFind.Entities.Wifi", "Wifi")
                        .WithMany()
                        .HasForeignKey("WifiId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("WiFindUser");

                    b.Navigation("Wifi");
                });

            modelBuilder.Entity("WiFind.Entities.WiFindUser", b =>
                {
                    b.HasOne("WiFind.Entities.Wifi", "Wifi")
                        .WithMany()
                        .HasForeignKey("WifiId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Wifi");
                });

            modelBuilder.Entity("WiFind.Entities.Wifi", b =>
                {
                    b.HasOne("WiFind.Entities.WiFindUser", "WiFindUser")
                        .WithMany()
                        .HasForeignKey("WiFindUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("WiFindUser");
                });

            modelBuilder.Entity("WiFind.Entities.WifiConnection", b =>
                {
                    b.HasOne("WiFind.Entities.WiFindUser", "WiFindUser")
                        .WithMany()
                        .HasForeignKey("WiFindUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WiFind.Entities.Wifi", "Wifi")
                        .WithMany()
                        .HasForeignKey("WifiId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("WiFindUser");

                    b.Navigation("Wifi");
                });
#pragma warning restore 612, 618
        }
    }
}
