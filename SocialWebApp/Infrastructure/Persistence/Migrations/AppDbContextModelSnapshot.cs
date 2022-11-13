﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Domain.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("Domain.Entities.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<int>("TriggerUserId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TriggerUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("Domain.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfComments")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfLikes")
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Post");
                });

<<<<<<< HEAD
            modelBuilder.Entity("SocialWebApp.Models.User", b =>
=======
            modelBuilder.Entity("Domain.Entities.User", b =>
>>>>>>> fd830e6 (feat: add refresh token and integrate API)
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

<<<<<<< HEAD
                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

=======
>>>>>>> fd830e6 (feat: add refresh token and integrate API)
                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

<<<<<<< HEAD
=======
                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

>>>>>>> fd830e6 (feat: add refresh token and integrate API)
                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

<<<<<<< HEAD
=======
                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

>>>>>>> fd830e6 (feat: add refresh token and integrate API)
                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

<<<<<<< HEAD
            modelBuilder.Entity("SocialWebApp.Models.UserFriends", b =>
=======
            modelBuilder.Entity("Domain.Entities.UserFriends", b =>
>>>>>>> fd830e6 (feat: add refresh token and integrate API)
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("FriendId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("SourceUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FriendId");

                    b.HasIndex("SourceUserId");

                    b.ToTable("UserFriends");
                });

<<<<<<< HEAD
            modelBuilder.Entity("SocialWebApp.Models.Comment", b =>
                {
                    b.HasOne("SocialWebApp.Models.Post", "Post")
=======
            modelBuilder.Entity("Domain.Entities.Comment", b =>
                {
                    b.HasOne("Domain.Entities.Post", "Post")
>>>>>>> fd830e6 (feat: add refresh token and integrate API)
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

<<<<<<< HEAD
                    b.HasOne("SocialWebApp.Models.User", "User")
=======
                    b.HasOne("Domain.Entities.User", "User")
>>>>>>> fd830e6 (feat: add refresh token and integrate API)
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

<<<<<<< HEAD
            modelBuilder.Entity("SocialWebApp.Models.Message", b =>
                {
                    b.HasOne("SocialWebApp.Models.User", "Receiver")
=======
            modelBuilder.Entity("Domain.Entities.Message", b =>
                {
                    b.HasOne("Domain.Entities.User", "Receiver")
>>>>>>> fd830e6 (feat: add refresh token and integrate API)
                        .WithMany("MessagesReceive")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

<<<<<<< HEAD
                    b.HasOne("SocialWebApp.Models.User", "Sender")
=======
                    b.HasOne("Domain.Entities.User", "Sender")
>>>>>>> fd830e6 (feat: add refresh token and integrate API)
                        .WithMany("MessagesSend")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

<<<<<<< HEAD
            modelBuilder.Entity("SocialWebApp.Models.Notification", b =>
                {
                    b.HasOne("SocialWebApp.Models.User", "TriggerUser")
=======
            modelBuilder.Entity("Domain.Entities.Notification", b =>
                {
                    b.HasOne("Domain.Entities.User", "TriggerUser")
>>>>>>> fd830e6 (feat: add refresh token and integrate API)
                        .WithMany("UserTriggerNotifications")
                        .HasForeignKey("TriggerUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

<<<<<<< HEAD
                    b.HasOne("SocialWebApp.Models.User", "User")
=======
                    b.HasOne("Domain.Entities.User", "User")
>>>>>>> fd830e6 (feat: add refresh token and integrate API)
                        .WithMany("UserNotifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("TriggerUser");

                    b.Navigation("User");
                });

<<<<<<< HEAD
            modelBuilder.Entity("SocialWebApp.Models.Post", b =>
                {
                    b.HasOne("SocialWebApp.Models.User", "User")
=======
            modelBuilder.Entity("Domain.Entities.Post", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
>>>>>>> fd830e6 (feat: add refresh token and integrate API)
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

<<<<<<< HEAD
            modelBuilder.Entity("SocialWebApp.Models.UserFriends", b =>
                {
                    b.HasOne("SocialWebApp.Models.User", "Friend")
=======
            modelBuilder.Entity("Domain.Entities.UserFriends", b =>
                {
                    b.HasOne("Domain.Entities.User", "Friend")
>>>>>>> fd830e6 (feat: add refresh token and integrate API)
                        .WithMany("Friends")
                        .HasForeignKey("FriendId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

<<<<<<< HEAD
                    b.HasOne("SocialWebApp.Models.User", "SourceUser")
=======
                    b.HasOne("Domain.Entities.User", "SourceUser")
>>>>>>> fd830e6 (feat: add refresh token and integrate API)
                        .WithMany()
                        .HasForeignKey("SourceUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Friend");

                    b.Navigation("SourceUser");
                });

<<<<<<< HEAD
            modelBuilder.Entity("SocialWebApp.Models.Post", b =>
=======
            modelBuilder.Entity("Domain.Entities.Post", b =>
>>>>>>> fd830e6 (feat: add refresh token and integrate API)
                {
                    b.Navigation("Comments");
                });

<<<<<<< HEAD
            modelBuilder.Entity("SocialWebApp.Models.User", b =>
=======
            modelBuilder.Entity("Domain.Entities.User", b =>
>>>>>>> fd830e6 (feat: add refresh token and integrate API)
                {
                    b.Navigation("Comments");

                    b.Navigation("Friends");

                    b.Navigation("MessagesReceive");

                    b.Navigation("MessagesSend");

                    b.Navigation("Posts");

                    b.Navigation("UserNotifications");

                    b.Navigation("UserTriggerNotifications");
                });
#pragma warning restore 612, 618
        }
    }
}
