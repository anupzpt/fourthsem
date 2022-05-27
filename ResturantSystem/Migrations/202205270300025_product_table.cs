namespace ResturantSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product_table : DbMigration
    {
        public override void Up()
        {
            Sql(@"Create table ProductTable(
            Id int primary key identity(1,1),
            ProductName nvarchar(50) NOT NULL,
            FoodCategory nvarchar(70) NOT NULL,
            ProductDetail nvarchar(100) NOT NULL,
            ProductPrice nvarchar(50) NOT NULL,
            ProductImage varchar(255) NOT NULL
            )");
        }
        
        public override void Down()
        {
        }
    }
}
