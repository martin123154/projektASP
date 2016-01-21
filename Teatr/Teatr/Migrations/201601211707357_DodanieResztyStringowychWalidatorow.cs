namespace Teatr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanieResztyStringowychWalidatorow : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Scenas", "wielkosc", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Scenas", "wielkosc", c => c.String(nullable: false));
        }
    }
}
