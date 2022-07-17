namespace ResturantSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddToCart : DbMigration
    {
        public override void Up()
        {

            Sql(@" CREATE TABLE AddToCart(
            Id INT IDENTITY(1, 1) NOT NULL,
            ProductId INT NULL,
            UserId INT NULL,
            ProductName NVARCHAR(50) NULL,
            ProductPrice NVARCHAR(50) NULL,
            Quantity NVARCHAR(50) NULL
            )");
        }

        public override void Down()
        {
        }
    }
}
