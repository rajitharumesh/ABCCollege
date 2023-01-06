using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infrastructure
{
    public class ABCCollegeDbContext : DbContext
    {
        public ABCCollegeDbContext(DbContextOptions<ABCCollegeDbContext> options) : base(options) { }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<CourseSubject> CourseSubjects { get; set; }
        public DbSet<Enrollments> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Course>()
                .HasData(
                    new Course
                    {
                        ID = 1,
                        Title = "Information Technology",
                        Description = "Information Technology",
                    },
                    new Course
                    {
                        ID = 2,
                        Title = "Master Science Of Computer",
                        Description = "Master Science Of Computer",
                    }
            );

            modelBuilder.Entity<Subject>()
            .HasData(
                    new Subject
                    {
                        ID = 1,
                        Name = "C#",
                        Description = "Using Visual Studio",
                    },
                    new Subject
                    {
                        ID = 2,
                        Name = "JAVA",
                        Description = "Using Eclips",
                    }
                );

            modelBuilder.Entity<Teacher>()
                .HasData(
                    new Teacher
                    {
                        ID = 1,
                        FirstName = "Teacher 1",
                        LastName = "Teacher 1",
                        BirthDate = DateTime.Now,
                    },
                    new Teacher
                    {
                        ID = 2,
                        FirstName = "Teacher 2",
                        LastName = "Teacher 2",
                        BirthDate = DateTime.Now,
                    }
                ); ;

            modelBuilder.Entity<CourseSubject>()
                .HasData(
                    new CourseSubject
                    {
                        ID = 1,
                        CourseID = 1,
                        SubjectID = 1,
                        TeacherID = 1,

                    },
                    new CourseSubject
                    {
                        ID = 2,
                        CourseID = 1,
                        SubjectID = 2,
                        TeacherID = 1,
                    },
                    new CourseSubject
                    {
                        ID = 3,
                        CourseID = 2,
                        SubjectID = 2,
                        TeacherID = 1,
                    }
                );

            modelBuilder.Entity<Student>()
                .HasData(
                    new Student
                    {
                        ID = 1,
                        FirstName = "Marilyn",
                        LastName = "Monroe",
                        RegistrationNo = "",
                        EnrollmentDate = new DateTime(2023, 01, 01),
                        BirthDate = new DateTime(1926, 12, 25),

                    },
                    new Student
                    {
                        ID = 2,
                        FirstName = "Abraham",
                        LastName = "Lincoln",
                        RegistrationNo = "",
                        EnrollmentDate = new DateTime(2023, 01, 01),
                        BirthDate = new DateTime(1809, 01, 01),
                    },
                    new Student
                    {
                        ID = 3,
                        FirstName = "Nelson",
                        LastName = "Mandela",
                        RegistrationNo = "",
                        EnrollmentDate = new DateTime(2023, 01, 01),
                        BirthDate = new DateTime(1918, 01, 01),
                    }
                );

            modelBuilder.Entity<Enrollments>()
                .HasData(
                    new Enrollments
                    {
                        ID = 1,
                        StudentID=1,
                        CourseSubjectID=1
                    },
                    new Enrollments
                    {
                        ID = 2,
                        StudentID = 1,
                        CourseSubjectID = 2
                    },
                    new Enrollments
                    {
                        ID = 3,
                        StudentID = 1,
                        CourseSubjectID = 3
                    },
                    new Enrollments
                    {
                        ID = 4,
                        StudentID = 2,
                        CourseSubjectID = 2
                    },
                    new Enrollments
                    {
                        ID = 5,
                        StudentID = 3,
                        CourseSubjectID = 3
                    }
                );

        }

    }
}