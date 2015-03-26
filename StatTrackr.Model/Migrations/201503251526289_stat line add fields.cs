namespace StatTrackr.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statlineaddfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StatLines", "TeamId", c => c.Int(nullable: false));
            AddColumn("dbo.StatLines", "StatNotes", c => c.String());
            CreateIndex("dbo.StatLines", "TeamId");
            AddForeignKey("dbo.StatLines", "TeamId", "dbo.Teams", "TeamId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StatLines", "TeamId", "dbo.Teams");
            DropIndex("dbo.StatLines", new[] { "TeamId" });
            DropColumn("dbo.StatLines", "StatNotes");
            DropColumn("dbo.StatLines", "TeamId");
        }
    }
}
