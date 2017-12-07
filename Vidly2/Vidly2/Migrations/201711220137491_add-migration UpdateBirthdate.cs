namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationUpdateBirthdate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate='19810904' WHERE Id = 5");
        }
        
        public override void Down()
        {
        }
    }
}
