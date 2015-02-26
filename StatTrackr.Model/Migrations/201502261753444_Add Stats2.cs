namespace StatTrackr.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStats2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StatLines", "ShotLocation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StatLines", "ShotLocation");
        }
    }
}
