using AutoMapper;
using StatTrackr.Model.Data;
using StatTrackr.Service.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.Service.Models.Response
{
    public class GameStatsResponse
    {
        public GameStatsResponse(Game game){

            var stats = game.StatLines.OrderBy(x=>x.Period).OrderBy(x=>x.ClockTime).ToList();
            if (stats.Count > 0)
            {
                var homeStatLines = stats.Where(s => s.TeamId == game.HomeTeamId).ToList();
                var awayStatLines = stats.Where(s => s.TeamId == game.AwayTeamId).ToList();

                HomeStatTotals = new TeamStatsResponse()
                {
                    Fouls = homeStatLines.Where(x => x.StatTypeId == 10 || x.StatTypeId == 11).Select(x => x.StatType.Value).Sum(),
                    Score = homeStatLines.Where(x => x.StatTypeId == 14 || x.StatTypeId == 16 || x.StatTypeId == 1).Select(x => x.StatType.Value).Sum()
                };
                AwayStatTotals = new TeamStatsResponse()
                {
                    Fouls = awayStatLines.Where(x => x.StatTypeId == 10 || x.StatTypeId == 11).Select(x => x.StatType.Value).Sum(),
                    Score = awayStatLines.Where(x => x.StatTypeId == 14 || x.StatTypeId == 16 || x.StatTypeId == 1).Select(x => x.StatType.Value).Sum()
                };

                this.ClockTime = stats.First().ClockTime;

                this.GameStatLines = Mapper.Map<List<StatLineResponse>>(stats);

            }
        }

        public int GameId { get; set; }
        public TeamStatsResponse HomeStatTotals { get; set; }
        public TeamStatsResponse AwayStatTotals { get; set; }
        public int Period { get; set; }
        public decimal ClockTime { get; set; }
        public List<StatLineResponse> GameStatLines { get; set; }
    }
}
