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
using StatTrackr.Service.Models.Response;
using StatTrackr.Service.Models.Request;
using System.Web.Http.Description;

namespace StatTrackr.WebApi.Controllers
{
    public class TeamController : ApiController
    {

        ITeamService _service;
        public TeamController(ITeamService service)
        {
            _service = service;
        }
        // GET: api/Team
        [ResponseType(typeof(IEnumerable<TeamResponse>))]
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        // GET: api/Team/5
        [ResponseType(typeof(TeamResponse))]
        public IHttpActionResult Get(int id)
        {
            var response = _service.GetById(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        // POST: api/Team
        [ResponseType(typeof(TeamResponse))]
        public IHttpActionResult Post([FromBody]TeamRequest team)
        {
          if (!ModelState.IsValid)
              return BadRequest();
            
            var response = _service.Create(team);

            return CreatedAtRoute("DefaultApi", new { id = response.TeamId }, response);
        }

        // PUT: api/Team/5
        [ResponseType(typeof(TeamResponse))]
        public IHttpActionResult Put(int id, [FromBody]TeamRequest team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = _service.Update(id, team);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [ResponseType(typeof(TeamResponse))]
        [Route("api/AddPlayerToTeam/{id}")]
        public IHttpActionResult AddPlayerToTeam(int id, [FromBody]PlayerRequest player)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = _service.AddPlayerToTeam(id, player);
            if (response == null)
                return NotFound();


            return Ok(response);
        }
        // DELETE: api/Team/5
        public IHttpActionResult Delete(int id)
        {
            if (!_service.Delete(id))
                return NotFound();

            return Ok();
        }
    }
}
