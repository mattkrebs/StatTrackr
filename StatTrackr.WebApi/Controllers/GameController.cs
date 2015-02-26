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
            return Ok(Mapper.Map<IEnumerable<GameResponse>>(_service.GetAll()));
        }

        // GET: api/Game/5
        [ResponseType(typeof(GameResponse))]
        public IHttpActionResult Get(int id)
        {
            var gameExisting = _service.GetById(id);
            if (gameExisting == null)
                return NotFound();

            return Ok(Mapper.Map<GameResponse>(gameExisting));
        }

        // POST: api/Game
        [ResponseType(typeof(GameResponse))]
        public IHttpActionResult Post([FromBody]GameRequest game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           
               var gameExisting = Mapper.Map<Game>(game);
                _service.Create(gameExisting);

                return CreatedAtRoute("DefaultApi", gameExisting.GameId, Mapper.Map<GameResponse>(gameExisting));
        }

        // PUT: api/Game/5
        [ResponseType(typeof(GameResponse))]
        public IHttpActionResult Put(int id, [FromBody]GameRequest game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var gameExisting = _service.GetById(game.GameId);
            if (gameExisting == null)
                return NotFound();


            gameExisting = Mapper.Map<GameRequest, Game>(game, gameExisting);
            _service.Update(gameExisting);

            return Ok(Mapper.Map<GameResponse>(gameExisting));
        }

        // DELETE: api/Game/5
        public IHttpActionResult Delete(int id)
        {
            var gameExisting = _service.GetById(id);
            if (gameExisting == null)
                return NotFound();

            _service.Delete(gameExisting);

            return Ok();
        }
    }
}
