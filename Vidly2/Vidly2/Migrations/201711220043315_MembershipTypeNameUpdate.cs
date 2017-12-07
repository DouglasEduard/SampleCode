namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembershipTypeNameUpdate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name = '6 Months' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Year' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
