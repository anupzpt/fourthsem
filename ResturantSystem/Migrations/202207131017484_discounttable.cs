namespace ResturantSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class discounttable : DbMigration
    {
        public override void Up()

        {
            Sql(@"Create table DiscountTable(
            Id int primary key identity(1,1),
            FoodCategory nvarchar(70) NOT NULL,
            ProductName nvarchar(50) NOT NULL,
            OfferPercent nvarchar(50) NOT NULL,
            Detail nvarchar(50) NOT NULL
            )");
        }
        
        public override void Down()
        {
        }
    }
}
