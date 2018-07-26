﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using YemekTenceremCom.Data;

namespace YemekTenceremCom.Migrations
{
    [DbContext(typeof(YemekContext))]
    [Migration("20180311160628_Yorum")]
    partial class Yorum
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("YemekTenceremCom.Models.Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("KAdi")
                        .IsRequired();

                    b.Property<string>("Sifre")
                        .IsRequired();

                    b.Property<string>("Turu");

                    b.HasKey("Id");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("YemekTenceremCom.Models.Yemek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ad");

                    b.Property<string>("Hazirlanisi");

                    b.Property<string>("Malzemeler");

                    b.Property<string>("Resim");

                    b.HasKey("Id");

                    b.ToTable("Yemekler");
                });

            modelBuilder.Entity("YemekTenceremCom.Models.Yorum", b =>
                {
                    b.Property<int>("YorumId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("YemekId");

                    b.Property<string>("YorumMetni");

                    b.Property<string>("YorumOnay");

                    b.HasKey("YorumId");

                    b.HasIndex("YemekId");

                    b.ToTable("Yorumlar");
                });

            modelBuilder.Entity("YemekTenceremCom.Models.YorumIslemleriViewModels.YorumEkleViewModel", b =>
                {
                    b.Property<int>("YemekID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("YapilanYorum");

                    b.Property<string>("YemekAdi");

                    b.Property<string>("YemekResmi");

                    b.HasKey("YemekID");

                    b.ToTable("YorumEkleViewModel");
                });

            modelBuilder.Entity("YemekTenceremCom.Models.Yorum", b =>
                {
                    b.HasOne("YemekTenceremCom.Models.Yemek", "Yemek")
                        .WithMany("Yorumlar")
                        .HasForeignKey("YemekId");
                });
#pragma warning restore 612, 618
        }
    }
}
