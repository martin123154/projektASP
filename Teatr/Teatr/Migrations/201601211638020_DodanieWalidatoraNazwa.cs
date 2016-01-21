namespace Teatr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanieWalidatoraNazwa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Scenas", "nazwa", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Scenas", "nazwa", c => c.String(nullable: false));
        }
    }
}
