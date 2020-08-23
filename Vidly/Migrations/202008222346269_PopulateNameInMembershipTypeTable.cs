namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNameInMembershipTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay As You Go' where DurationInMonths = 0");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' where DurationInMonths = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Quarterly' where DurationInMonths = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Yearly' where DurationInMonths = 12");

        }

        public override void Down()
        {
        }
    }
}
