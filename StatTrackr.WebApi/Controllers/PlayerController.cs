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
            return Ok(Mapper.Map<IEnumerable<PlayerResponse>>(_service.GetAll()));
        }

        // GET: api/Player/5
        [ResponseType(typeof(PlayerResponse))]
        public IHttpActionResult Get(int id)
        {
            var playerExisting = _service.GetById(id);

            if (playerExisting == null) 
                return NotFound();

            return Ok(Mapper.Map<PlayerResponse>(playerExisting));
        }

        // POST: api/Player
        [ResponseType(typeof(PlayerResponse))]
        public IHttpActionResult Post([FromBody]PlayerRequest player)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newPlayer = Mapper.Map<Player>(player);
            _service.Create(newPlayer);

            return CreatedAtRoute("DefaultApi", newPlayer.PlayerId, Mapper.Map<PlayerResponse>(newPlayer));
        }

        // PUT: api/Player/5
        [ResponseType(typeof(PlayerResponse))]
        public IHttpActionResult Put(int id, [FromBody]PlayerRequest player)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var playerExisting = _service.GetById(player.PlayerId);
            if (playerExisting == null)
                return NotFound();

            playerExisting.FirstName = player.FirstName;
            playerExisting.LastName = player.LastName;
            playerExisting.Number = player.Number;
            playerExisting.PositionId = player.PositionId;
            playerExisting.Age = player.Age;

            _service.Update(playerExisting);

            return Ok(Mapper.Map<PlayerResponse>(playerExisting));
        }

        // DELETE: api/Player/5
        public IHttpActionResult Delete(int id)
        {
            var playerExisting = _service.GetById(id);
            if (playerExisting == null)
                return NotFound();

            _service.Delete(playerExisting);

            return Ok();
        }
    }
}
