namespace ResturantSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_table1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"Create table Category(
            Id int primary key identity(1,1),
            FoodCategory nvarchar(70) NOT NULL,
            Action nvarchar(50) 
)");
        }
        
        public override void Down()
        {
        }
    }
}
