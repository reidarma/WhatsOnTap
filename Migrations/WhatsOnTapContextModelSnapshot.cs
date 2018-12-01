﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WhatsOnTap.Models;

namespace WhatsOnTap.Migrations
{
    [DbContext(typeof(WhatsOnTapContext))]
    partial class WhatsOnTapContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("WhatsOnTap.Models.Beer", b =>
                {
                    b.Property<long?>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("abv");

                    b.Property<string>("description");

                    b.Property<double>("fg");

                    b.Property<double>("ibu");

                    b.Property<byte[]>("label");

                    b.Property<string>("name");

                    b.Property<double>("og");

                    b.Property<double>("srm");

                    b.Property<int>("styleId");

                    b.HasKey("id");

                    b.ToTable("Beer");
                });

            modelBuilder.Entity("WhatsOnTap.Models.Setting", b =>
                {
                    b.Property<long?>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("boolValue");

                    b.Property<string>("key");

                    b.Property<string>("stringValue");

                    b.Property<string>("type");

                    b.HasKey("id");

                    b.ToTable("Setting");
                });

            modelBuilder.Entity("WhatsOnTap.Models.Style", b =>
                {
                    b.Property<long?>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("Style");
                });

            modelBuilder.Entity("WhatsOnTap.Models.Tap", b =>
                {
                    b.Property<long?>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("beerId");

                    b.Property<bool>("isEmpty");

                    b.Property<int>("order");

                    b.HasKey("id");

                    b.ToTable("Tap");
                });
#pragma warning restore 612, 618
        }
    }
}
