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
    [Authorize(Roles= "admin")]
    public class GameController : ApiController
    {

        IGameService _service;
        public GameController(IGameService service)
        {
            _service = service;
        }
        // GET: api/Game
        [ResponseType(typeof(IEnumerable<GameResponse>))]
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        // GET: api/Game/5
        [ResponseType(typeof(GameResponse))]
        public IHttpActionResult Get(int id)
        {
            var response = _service.GetById(id);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        // POST: api/Game
        [ResponseType(typeof(GameResponse))]
        public IHttpActionResult Post([FromBody]GameRequest game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = _service.Create(game);

            return CreatedAtRoute("DefaultApi", response.GameId, response);
        }

        // PUT: api/Game/5
        [ResponseType(typeof(GameResponse))]
        public IHttpActionResult Put(int id, [FromBody]GameRequest game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = _service.Update(id, game);
            if (response == null)
                return NotFound();

            return Ok(response);
        }
        [ResponseType(typeof(IEnumerable<GameStatsResponse>))]
        [Route("api/GetStatsForGame/{id}")]
        public IHttpActionResult GetStatsForGame(int id)
        {
            var response = _service.GetGameStats(id);
            return Ok(response);
        }

        // DELETE: api/Game/5
        public IHttpActionResult Delete(int id)
        {
            if (!_service.Delete(id)) 
                return NotFound();

            return Ok();
        }
    }
}
