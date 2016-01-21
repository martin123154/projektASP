namespace Teatr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMiddleName1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Scenas", "wielkosc", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Scenas", "wielkosc", c => c.String());
        }
    }
}
