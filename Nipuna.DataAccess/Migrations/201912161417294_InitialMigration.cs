namespace Nipuna.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        RegistrationId = c.String(),
                        StudentID = c.String(),
                        StudentName = c.String(),
                        CourseId = c.String(),
                        CourseName = c.String(),
                        LecturerId = c.String(),
                        LecturerName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseEnrollments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.String(),
                        RegisteredDate = c.DateTime(nullable: false),
                        RegistrationId = c.String(),
                        StudentName = c.String(),
                        CourseId = c.String(),
                        CourseName = c.String(),
                        LecturerId = c.String(),
                        LecturerName = c.String(),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RefNo = c.String(),
                        Title = c.String(),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RefNo = c.String(),
                        Name = c.String(),
                        Nic = c.String(),
                        Dob = c.DateTime(nullable: false),
                        School = c.String(),
                        Address = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        Type = c.String(),
                        Pname = c.String(),
                        Pmobile = c.String(),
                        Plandline = c.String(),
                        Registereddate = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LecturerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LecturerId = c.String(),
                        LecturerName = c.String(),
                        CourseId = c.String(),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lecturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LecturerId = c.String(),
                        SurName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Nic = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceNo = c.String(),
                        RegistrationId = c.String(),
                        StudentName = c.String(),
                        CourseId = c.String(),
                        CourseName = c.String(),
                        LecturerId = c.String(),
                        LectuerName = c.String(),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaidDate = c.DateTime(nullable: false),
                        Invoicedate = c.DateTime(nullable: false),
                        Username = c.String(),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RegistrationIds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.String(),
                        StudentName = c.String(),
                        CourseId = c.String(),
                        CourseName = c.String(),
                        RegistrationId = c.String(),
                        IssuedDate = c.DateTime(nullable: false),
                        IssuedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Samples",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        SurName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Nic = c.String(),
                        ContactNo = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseCourseEnrollments",
                c => new
                    {
                        Course_Id = c.Int(nullable: false),
                        CourseEnrollment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_Id, t.CourseEnrollment_Id })
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .ForeignKey("dbo.CourseEnrollments", t => t.CourseEnrollment_Id, cascadeDelete: true)
                .Index(t => t.Course_Id)
                .Index(t => t.CourseEnrollment_Id);
            
            CreateTable(
                "dbo.StudentCourseEnrollments",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        CourseEnrollment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.CourseEnrollment_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.CourseEnrollments", t => t.CourseEnrollment_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.CourseEnrollment_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourseEnrollments", "CourseEnrollment_Id", "dbo.CourseEnrollments");
            DropForeignKey("dbo.StudentCourseEnrollments", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.CourseCourseEnrollments", "CourseEnrollment_Id", "dbo.CourseEnrollments");
            DropForeignKey("dbo.CourseCourseEnrollments", "Course_Id", "dbo.Courses");
            DropIndex("dbo.StudentCourseEnrollments", new[] { "CourseEnrollment_Id" });
            DropIndex("dbo.StudentCourseEnrollments", new[] { "Student_Id" });
            DropIndex("dbo.CourseCourseEnrollments", new[] { "CourseEnrollment_Id" });
            DropIndex("dbo.CourseCourseEnrollments", new[] { "Course_Id" });
            DropTable("dbo.StudentCourseEnrollments");
            DropTable("dbo.CourseCourseEnrollments");
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Samples");
            DropTable("dbo.RegistrationIds");
            DropTable("dbo.Payments");
            DropTable("dbo.Lecturers");
            DropTable("dbo.LecturerCourses");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseEnrollments");
            DropTable("dbo.Attendances");
        }
    }
}
