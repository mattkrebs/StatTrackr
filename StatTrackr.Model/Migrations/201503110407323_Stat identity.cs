namespace StatTrackr.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Statidentity : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.StatLines");
            AlterColumn("dbo.StatLines", "StatLineId", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.StatLines", "StatLineId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.StatLines");
            AlterColumn("dbo.StatLines", "StatLineId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.StatLines", "StatLineId");
        }
    }
}
