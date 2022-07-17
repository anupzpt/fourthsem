namespace ResturantSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordertable : DbMigration
    {
        public override void Up()
        {
            Sql(@"CREATE TABLE Orders(
            	Id int IDENTITY(1,1),
                 UserId int,
               ProductId int,
	           Address nvarchar(50),
               PaymentOption nvarchar(50),
              Status nvarchar(1),
              Date DateTime2 
            )");
        }
        
        public override void Down()
        {
        }
    }
}
