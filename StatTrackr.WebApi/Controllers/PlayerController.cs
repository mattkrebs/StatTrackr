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
    [Authorize(Roles = "admin")]
    public class PlayerController : ApiController
    {
        IPlayerService _service;
        public PlayerController(IPlayerService playerService)
        {
            _service = playerService;
        }
        // GET: api/Player
        [ResponseType(typeof(IEnumerable<PlayerResponse>))]
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        // GET: api/Player/5
        [ResponseType(typeof(PlayerResponse))]
        public IHttpActionResult Get(int id)
        {
            var playerExisting = _service.GetById(id);

            if (playerExisting == null) 
                return NotFound();

            return Ok(playerExisting);
        }
        // GET: api/Player/5        
        [ResponseType(typeof(IEnumerable<PlayerResponse>))]
        [Route("api/GetAvailablePlayers/{teamId}")]
        public IHttpActionResult GetAvailablePlayers(int teamId)
        {
            var players = _service.GetAvailablePlayersByTeamId(teamId);

            if (players == null)
                return NotFound();

            return Ok(players);
        }
        // POST: api/Player
        [ResponseType(typeof(PlayerResponse))]
        public IHttpActionResult Post([FromBody]PlayerRequest player)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           var response =  _service.Create(player);

           return CreatedAtRoute("DefaultApi", response.PlayerId, response);
        }

        // PUT: api/Player/5
        [ResponseType(typeof(PlayerResponse))]
        public IHttpActionResult Put(int id, [FromBody]PlayerRequest player)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = _service.Update(id, player);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        // DELETE: api/Player/5
        public IHttpActionResult Delete(int id)
        {
            if (!_service.Delete(id))
                return NotFound();

            return Ok();
        }
    }
}
