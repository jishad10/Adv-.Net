namespace IntroEFCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentForiegnKey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Students", "DeptId");
            AddForeignKey("dbo.Students", "DeptId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "DeptId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "DeptId" });
        }
    }
}
