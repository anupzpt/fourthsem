namespace ResturantSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_table_contact : DbMigration
    {
        public override void Up()
        {
            Sql(@"Create table ContactUS(
                Id int primary key identity(1,1),
                Name nvarchar(50) NOT NULL,
                Email nvarchar(50) NOT NULL,
                Phone_no int unique NOT NULL,
                Message varchar(255) NOT NULL
)");
        }
        
        public override void Down()
        {
        }
    }
}
