namespace ResturantSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customertable : DbMigration
    {
        public override void Up()
        {
            Sql(@"Create table CustomerTables(
            Id int primary key identity(1,1),
            Username nvarchar(70) NOT NULL,
            Password nvarchar(50) NOT NULL,
            Contactno nvarchar(50) NOT NULL,
            Address nvarchar(50) NOT NULL,
            Email nvarchar(50) NOT NULL
            )");
        }
        
        public override void Down()
        {
        }
    }
}
