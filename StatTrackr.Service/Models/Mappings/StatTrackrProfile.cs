using AutoMapper;
using StatTrackr.Model.Data;
using StatTrackr.ServiceModel.Request;
using StatTrackr.ServiceModel.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.Service.Models.Mappings
{
    public class StatTrackrProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<PlayerRequest, Player>();
            CreateMap<Player, PlayerResponse>();

            CreateMap<GameRequest, Game>();
            CreateMap<Game, GameResponse>();

            CreateMap<TeamRequest, Team>();
            CreateMap<Team, TeamResponse>();

            CreateMap<StatLineRequest, StatLine>();
            CreateMap<StatLine, StatLineResponse>();


            CreateMap<StatType, StatTypeResponse>();

            //for cloning
            CreateMap<PlayerResponse, PlayerResponse>();

           // //CreateMap<Player, PlayerViewModel>();

           // CreateMap<GameResponse, Game>().ReverseMap()
           //      .ForAllMembers(opt => opt.Condition(srs => !srs.IsSourceValueNull));
           //// CreateMap<Game, GameViewModel>();

           // CreateMap<TeamViewModel, Team>().ReverseMap()
           //     .ForAllMembers(opt => opt.Condition(srs => !srs.IsSourceValueNull));
           //// CreateMap<Team, TeamViewModel>();


        }
        public override string ProfileName
        {
            get { return this.GetType().Name; }
        } 

       
    }

   
}
