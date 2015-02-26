namespace StatTrackr.Model.Migrations
{
    using StatTrackr.Model.Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StatTrackr.Model.StatTrackrContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StatTrackr.Model.StatTrackrContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            if (context.Positions.Count() == 0)
            {
                context.Positions.AddOrUpdate(
                    new Position { Name = "Point Gaurd", PositionId = 1 },
                    new Position { Name = "Shooting Guard", PositionId = 2 },
                    new Position { Name = "Small Forward", PositionId = 3 },
                    new Position { Name = "Power Forward", PositionId = 4 },
                    new Position { Name = "Center", PositionId = 5 },
                    new Position { Name = "Guard", PositionId = 6 },
                    new Position { Name = "Forward", PositionId = 7 });
            }

            if (context.StatTypes.Count() == 0)
            {
                context.StatTypes.AddOrUpdate(
                    new StatType { Name="Free Throw Made", StatTypeId=1, Value=1 },
                    new StatType { Name="Free Throw Missed", StatTypeId=2, Value=1 },
                    new StatType { Name="Defensive Foul", StatTypeId=3, Value=1 },
                    new StatType { Name="Offensive Foul", StatTypeId=4, Value=1 },
                    new StatType { Name="Technical Foul", StatTypeId=5, Value=1 },
                    new StatType { Name="Intentional Foul", StatTypeId=6, Value=1 },
                    new StatType { Name="2 Point FG Made", StatTypeId=7, Value=2 },
                    new StatType { Name="2 Point FG Missed", StatTypeId=8, Value=1 },
                    new StatType { Name="3 Point FG Made", StatTypeId=9, Value=1 },
                    new StatType { Name="3 Point FG Missed", StatTypeId=10, Value=3 },
                    new StatType { Name="Offensive Rebound", StatTypeId=1, Value=1 },
                    new StatType { Name="Defensive Rebound", StatTypeId=1, Value=1 },
                    new StatType { Name="Assist", StatTypeId=1, Value=1 },
                    new StatType { Name="Turnover", StatTypeId=1, Value=1 },
                    new StatType { Name="Steal", StatTypeId=1, Value=1 },
                    new StatType { Name="Substitute In", StatTypeId=1, Value=1 },
                    new StatType { Name="Substitute Out", StatTypeId=1, Value=1 }
                    );
            }
        }
    }
}
