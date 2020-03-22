﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model;

namespace WebApplication.Migrations
{
    [DbContext(typeof(LohynaDbContext))]
    partial class LohynaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("Model.Cabinet", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(6);

                    b.Property<int>("Size")
                        .HasColumnType("INTEGER");

                    b.HasKey("Name");

                    b.ToTable("Cabinet");
                });

            modelBuilder.Entity("Model.FAQ", b =>
                {
                    b.Property<string>("Question")
                        .HasColumnType("TEXT");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Question");

                    b.ToTable("FAQ");
                });

            modelBuilder.Entity("Model.Group", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.Property<long>("Course")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Size")
                        .HasColumnType("INTEGER");

                    b.HasKey("Name");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("Model.Lecturer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonID")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("PersonID")
                        .IsUnique();

                    b.ToTable("Lecturer");
                });

            modelBuilder.Entity("Model.News", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Photo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.ToTable("News");

                    b.HasData(
                        new
                        {
                            Name = "​​~Квартирник 8020~",
                            Photo = "DbResources/kvartyrnyk.jpeg",
                            Text = @"А що, звучить лампово, чи не так? 😉

				Хороша музика - як хороше вино, з роками лише приємніше чути її й ностальгувати за минулим! А хороша компанія прикрасить цей затишний вечір ще більше 😌
				А якщо ви ще й умієте каверити хіти вісімдесятих-дев'яностих-двотисячних, та й не згірше від оригіналів, то у вас є всі шанси стати душею компанії принаймні на цей вечір! 🤗🔥

				Ваші руки вже потягнулися за інструментом, очі загорілися чи ви почали наспівувати ""I just died in your arms tonight.."", ""Show must go o-on...""?..🎶
				Тоді чого зволікати?? Швиденько заповнюйте форму(посилання внизу⬇️) та бігом на кастинг, котрий відбудеться о 16:00, 12 березня у глядацькій залі ЦКД (головний корпус, вул. Університетська, 1) 😍

				Чекаємо на вас із нетерпінням, буде чарівно й по-домашньому! ✨",
                            Time = new DateTime(2020, 3, 22, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            Name = "​​📢Лекція «Блокчейн: як працює біткоїн»",
                            Photo = "DbResources/bitok.jpeg",
                            Text = @"👨🏻‍🎓 Спікер заходу: Роман Левкович, студент 3 курсу факультету прикладної математики та інформатики🔝

🗓Теми лекції:
👉 що таке блокчейн❓
👉 як створюють біткоїн та як це працює❓

⏰ 6 березня, з 16:30 – 18:00
📍 ауд.270

💫Реєстрація обов'язкова!👇",
                            Time = new DateTime(2020, 2, 10, 12, 23, 40, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Name = "​​Акустично-літературний вечір🎶🎹",
                            Photo = "DbResources/evening.jpeg",
                            Text = @"4 березня в ЦКД о 18:00 відбудеться акустично-літературний вечір і ми шукаємо людей, які вміють грати, співати або читати вірші🔥🚀

Реєструйся і покажи всім, що ти вмієш😉👇",
                            Time = new DateTime(2020, 2, 17, 17, 23, 40, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Name = "​​Sport time🤾‍♂⛹‍",
                            Text = @"Любиш активний відпочинок? 🤔
Давно чекаєш на можливість показати себе та позмагатися із собі рівними? 🏆🔥
Тоді, дай відповідь лиш на кілька запитань і ми виконаємо твої побажання)😉
Вибір за тобою!👇",
                            Time = new DateTime(2020, 3, 22, 17, 45, 2, 67, DateTimeKind.Local).AddTicks(9380)
                        },
                        new
                        {
                            Name = "​​Мафія на прикладній😈",
                            Photo = "DbResources/mafia.jpeg",
                            Text = @"Ти маєш шанс взяти участь у легендарній грі з веселою компанією, гарячими напоями та печеньками🤗

🕔19 лютого 17:00 в 216 ауд.

Вартість 20 грн з учасника, з нас смаколики з чайком, а з тебе компанія)🙋‍♀️🙋‍♂️

❗Реєстрація обовязкова!⬇️",
                            Time = new DateTime(2020, 2, 17, 17, 23, 40, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Model.Note", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Finished")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Materials")
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonID")
                        .HasColumnType("TEXT");

                    b.Property<string>("SubjectID")
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.HasIndex("PersonID");

                    b.HasIndex("SubjectID");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("Model.Person", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(16);

                    b.Property<string>("Photo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("Username");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Model.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Mark")
                        .HasColumnType("INTEGER");

                    b.Property<long>("StudentID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SubjectID")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StudentID");

                    b.HasIndex("SubjectID");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("Model.Specialization", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LecturerID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SubjectID")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("LecturerID");

                    b.HasIndex("SubjectID");

                    b.ToTable("Specialization");
                });

            modelBuilder.Entity("Model.Student", b =>
                {
                    b.Property<long>("TicketNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("GroupID")
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonID")
                        .HasColumnType("TEXT");

                    b.Property<long>("ReportCard")
                        .HasColumnType("INTEGER");

                    b.HasKey("TicketNumber");

                    b.HasIndex("GroupID");

                    b.HasIndex("PersonID")
                        .IsUnique();

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Model.Subject", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExamType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("Model.Time", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Finish")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.HasKey("Number");

                    b.ToTable("Time");
                });

            modelBuilder.Entity("Model.Timetable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Day")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupID")
                        .HasColumnType("TEXT");

                    b.Property<int>("LecturerID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Period")
                        .HasColumnType("TEXT");

                    b.Property<string>("SubjectID")
                        .HasColumnType("TEXT");

                    b.Property<int>("TimeID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GroupID");

                    b.HasIndex("LecturerID");

                    b.HasIndex("SubjectID");

                    b.HasIndex("TimeID");

                    b.ToTable("Timetable");
                });

            modelBuilder.Entity("Model.Lecturer", b =>
                {
                    b.HasOne("Model.Person", "Person")
                        .WithOne("Lecturer")
                        .HasForeignKey("Model.Lecturer", "PersonID");
                });

            modelBuilder.Entity("Model.Note", b =>
                {
                    b.HasOne("Model.Person", "Person")
                        .WithMany("Notes")
                        .HasForeignKey("PersonID");

                    b.HasOne("Model.Subject", "Subject")
                        .WithMany("Notes")
                        .HasForeignKey("SubjectID");
                });

            modelBuilder.Entity("Model.Rating", b =>
                {
                    b.HasOne("Model.Student", "Student")
                        .WithMany("Marks")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Subject", "Subject")
                        .WithMany("Marks")
                        .HasForeignKey("SubjectID");
                });

            modelBuilder.Entity("Model.Specialization", b =>
                {
                    b.HasOne("Model.Lecturer", "Lecturer")
                        .WithMany("Specializations")
                        .HasForeignKey("LecturerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Subject", "Subject")
                        .WithMany("Lecturers")
                        .HasForeignKey("SubjectID");
                });

            modelBuilder.Entity("Model.Student", b =>
                {
                    b.HasOne("Model.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupID");

                    b.HasOne("Model.Person", "Person")
                        .WithOne("Student")
                        .HasForeignKey("Model.Student", "PersonID");
                });

            modelBuilder.Entity("Model.Timetable", b =>
                {
                    b.HasOne("Model.Group", "Group")
                        .WithMany("Lessons")
                        .HasForeignKey("GroupID");

                    b.HasOne("Model.Lecturer", "Lecturer")
                        .WithMany("Lessons")
                        .HasForeignKey("LecturerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Subject", "Subject")
                        .WithMany("Lessons")
                        .HasForeignKey("SubjectID");

                    b.HasOne("Model.Time", "Time")
                        .WithMany("Lessons")
                        .HasForeignKey("TimeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
