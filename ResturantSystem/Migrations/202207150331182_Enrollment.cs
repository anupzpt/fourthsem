namespace ResturantSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Enrollment : DbMigration
    {
        public override void Up()
        {
            Sql(@"create table Enrollment(
                ID int primary key identity(1,1),
                FirstName varchar(50) not null,
                LastName varchar(50) not null,
                UserName nvarchar(50) not null,
                Email nvarchar(50) not null,
                Password nvarchar(30) not null,
                Phone varchar(15) not null,
                SecurityAnswer nvarchar(50) not null,
                Gender varchar(15)
            )");
        }
        
        public override void Down()
        {
        }
    }
}
