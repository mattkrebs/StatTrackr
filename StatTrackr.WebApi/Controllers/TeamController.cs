using AutoMapper;
using StatTrackr.WebApi.Models;
using StatTrackr.Model.Data;
using StatTrackr.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StatTrackr.WebApi.Models.Response;
using StatTrackr.WebApi.Models.Request;
using System.Web.Http.Description;

namespace StatTrackr.WebApi.Controllers
{
    public class TeamController : ApiController
    {

        ITeamService _service;
        IPlayerService _playerService;
        public TeamController(ITeamService service, IPlayerService playerService)
        {
            _service = service;
            _playerService = playerService;
        }
        // GET: api/Team
        [ResponseType(typeof(IEnumerable<TeamResponse>))]
        public IHttpActionResult Get()
        {
            return Ok(Mapper.Map<IEnumerable<TeamResponse>>(_service.GetAll()));
        }

        // GET: api/Team/5
        [ResponseType(typeof(TeamResponse))]
        public IHttpActionResult Get(int id)
        {
            var teamExisting = _service.GetById(id);
            return Ok(Mapper.Map<TeamResponse>(teamExisting));
        }

        // POST: api/Team
        [ResponseType(typeof(TeamResponse))]
        public IHttpActionResult Post([FromBody]TeamRequest team)
        {
            Team teamExisting = new Team();
            teamExisting.Name = team.Name;
            teamExisting.Hometown = team.Hometown;
            teamExisting.CoachName = team.CoachName;
            teamExisting.State = team.State;

            _service.Create(teamExisting);

            return CreatedAtRoute("DefaultApi", new { id = teamExisting.TeamId }, Mapper.Map<TeamResponse>(teamExisting));
        }

        // PUT: api/Team/5
        [ResponseType(typeof(TeamResponse))]
        public IHttpActionResult Put(int id, [FromBody]TeamRequest team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var teamExisting = _service.GetById(team.TeamId);
            if (teamExisting == null)
                return NotFound();

            teamExisting = _service.GetById(team.TeamId);
            teamExisting.Name = team.Name;
            teamExisting.Hometown = team.Hometown;
            teamExisting.CoachName = team.CoachName;
            teamExisting.State = team.State;

            _service.Update(teamExisting);

            return Ok(Mapper.Map<TeamResponse>(teamExisting));
        }

        [ResponseType(typeof(TeamResponse))]
        [Route("api/AddPlayerToTeam/{id}")]
        public IHttpActionResult AddPlayerToTeam(int id, [FromBody]PlayerRequest player)
        {
           
            var teamExisting = _service.GetById(id);
            if (teamExisting == null)
                return NotFound();

            var existingPlayer = _playerService.GetById(player.PlayerId);
            if (existingPlayer != null)
                teamExisting.Players.Add(existingPlayer);
            else
                teamExisting.Players.Add(Mapper.Map<Player>(player));

            _service.Update(teamExisting);
            return Ok(Mapper.Map<TeamResponse>(teamExisting));
        }
        // DELETE: api/Team/5
        public IHttpActionResult Delete(int id)
        {
            var teamExisting = _service.GetById(id);
            _service.Delete(teamExisting);

            return Ok();
        }
    }
}
