namespace StatTrackr.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStats : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StatLines",
                c => new
                    {
                        StatLineId = c.Guid(nullable: false),
                        GameId = c.Int(nullable: false),
                        StatTypeId = c.Int(nullable: false),
                        ClockTime = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Period = c.Int(nullable: false),
                        PlayerId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.StatLineId)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .ForeignKey("dbo.StatTypes", t => t.StatTypeId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.StatTypeId)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.StatTypes",
                c => new
                    {
                        StatTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StatTypeId);
            
            AlterColumn("dbo.Games", "PeriodTime", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StatLines", "StatTypeId", "dbo.StatTypes");
            DropForeignKey("dbo.StatLines", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.StatLines", "GameId", "dbo.Games");
            DropIndex("dbo.StatLines", new[] { "PlayerId" });
            DropIndex("dbo.StatLines", new[] { "StatTypeId" });
            DropIndex("dbo.StatLines", new[] { "GameId" });
            AlterColumn("dbo.Games", "PeriodTime", c => c.Int(nullable: false));
            DropTable("dbo.StatTypes");
            DropTable("dbo.StatLines");
        }
    }
}
