namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsTrainer = c.Boolean(nullable: false),
                        TitleID = c.Int(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name1 = c.String(nullable: false, maxLength: 50),
                        Name2 = c.String(nullable: false, maxLength: 50),
                        Name3 = c.String(nullable: false, maxLength: 50),
                        Name4 = c.String(nullable: false, maxLength: 50),
                        Gender = c.String(),
                        NationalID = c.String(nullable: false, maxLength: 50),
                        BirthDate = c.DateTime(nullable: false),
                        MartialState = c.String(nullable: false, maxLength: 10),
                        Address = c.String(nullable: false, maxLength: 100),
                        PhoneNo1 = c.String(nullable: false, maxLength: 15),
                        PhoneNo2 = c.String(maxLength: 15),
                        Email = c.String(maxLength: 100),
                        Image = c.Binary(),
                        IdentityImage = c.Binary(),
                        AddedOn = c.DateTime(nullable: false),
                        AddedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Titles", t => t.TitleID, cascadeDelete: true)
                .Index(t => t.TitleID);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Days = c.String(nullable: false, maxLength: 15),
                        Hours = c.String(maxLength: 20),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Hall = c.String(),
                        Count = c.Int(nullable: false),
                        MaxCount = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        AddedOn = c.DateTime(nullable: false),
                        AddedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Balance = c.Int(nullable: false),
                        MembershipStart = c.DateTime(nullable: false),
                        MembershipExpired = c.DateTime(nullable: false),
                        Name1 = c.String(nullable: false, maxLength: 50),
                        Name2 = c.String(nullable: false, maxLength: 50),
                        Name3 = c.String(nullable: false, maxLength: 50),
                        Name4 = c.String(nullable: false, maxLength: 50),
                        Gender = c.String(),
                        NationalID = c.String(nullable: false, maxLength: 50),
                        BirthDate = c.DateTime(nullable: false),
                        MartialState = c.String(nullable: false, maxLength: 10),
                        Address = c.String(nullable: false, maxLength: 100),
                        PhoneNo1 = c.String(nullable: false, maxLength: 15),
                        PhoneNo2 = c.String(maxLength: 15),
                        Email = c.String(maxLength: 100),
                        Image = c.Binary(),
                        IdentityImage = c.Binary(),
                        AddedOn = c.DateTime(nullable: false),
                        AddedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        IsSport = c.Boolean(nullable: false),
                        AddedOn = c.DateTime(nullable: false),
                        AddedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MemberClasses",
                c => new
                    {
                        Member_ID = c.Int(nullable: false),
                        Class_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Member_ID, t.Class_ID })
                .ForeignKey("dbo.Members", t => t.Member_ID, cascadeDelete: true)
                .ForeignKey("dbo.Classes", t => t.Class_ID, cascadeDelete: true)
                .Index(t => t.Member_ID)
                .Index(t => t.Class_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "TitleID", "dbo.Titles");
            DropForeignKey("dbo.MemberClasses", "Class_ID", "dbo.Classes");
            DropForeignKey("dbo.MemberClasses", "Member_ID", "dbo.Members");
            DropForeignKey("dbo.Classes", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.MemberClasses", new[] { "Class_ID" });
            DropIndex("dbo.MemberClasses", new[] { "Member_ID" });
            DropIndex("dbo.Classes", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "TitleID" });
            DropTable("dbo.MemberClasses");
            DropTable("dbo.Titles");
            DropTable("dbo.Members");
            DropTable("dbo.Classes");
            DropTable("dbo.Employees");
        }
    }
}
