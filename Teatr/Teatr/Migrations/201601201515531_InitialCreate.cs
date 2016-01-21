namespace Teatr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Przedstawienies",
                c => new
                    {
                        przedstawienie_id = c.Int(nullable: false, identity: true),
                        tytul = c.String(),
                        data_rozp = c.DateTime(nullable: false),
                        data_zak = c.DateTime(nullable: false),
                        scena_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.przedstawienie_id)
                .ForeignKey("dbo.Scenas", t => t.scena_id, cascadeDelete: true)
                .Index(t => t.scena_id);
            
            CreateTable(
                "dbo.Scenas",
                c => new
                    {
                        scena_id = c.Int(nullable: false, identity: true),
                        nazwa = c.String(),
                        wielkosc = c.String(),
                        numer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.scena_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Przedstawienies", "scena_id", "dbo.Scenas");
            DropIndex("dbo.Przedstawienies", new[] { "scena_id" });
            DropTable("dbo.Scenas");
            DropTable("dbo.Przedstawienies");
        }
    }
}
