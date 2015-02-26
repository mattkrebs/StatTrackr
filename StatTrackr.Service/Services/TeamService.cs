using StatTrackr.Data.Interfaces;
using StatTrackr.Model.Data;
using StatTrackr.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackr.Service.Services
{
    public class TeamService : EntityService<Team>, ITeamService
    {
        IUnitOfWork _unitOfWork;
        ITeamRepository _teamRespository;

        public TeamService(IUnitOfWork unitOfWork, ITeamRepository teamRespository)
            : base(unitOfWork, teamRespository)
        {
            _unitOfWork = unitOfWork;
            _teamRespository = teamRespository;
        }
        public Team GetById(int id)
        {
            return _teamRespository.GetById(id);
        }
    }
}
