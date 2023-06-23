namespace Zadacha13_Animals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Zadacha13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnimalName = c.String(),
                        Age = c.Int(nullable: false),
                        Description = c.String(),
                        BreedId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Breeds", t => t.BreedId, cascadeDelete: true)
                .Index(t => t.BreedId);
            
            CreateTable(
                "dbo.Breeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BreedName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "BreedId", "dbo.Breeds");
            DropIndex("dbo.Animals", new[] { "BreedId" });
            DropTable("dbo.Breeds");
            DropTable("dbo.Animals");
        }
    }
}
