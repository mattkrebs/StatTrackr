using AutoMapper;
using StatTrackr.Model.Data;
using StatTrackr.Service.Interfaces;
using StatTrackr.Service.Models.Request;
using StatTrackr.Service.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace StatTrackr.WebApi.Controllers
{
    [Authorize(Roles = "admin")]
    public class StatLineController : ApiController
    {
        IStatLineService _service;
        public StatLineController(IStatLineService service)
        {
            _service = service;
        }
        // GET: api/StatLine/5
        [ResponseType(typeof(StatLineResponse))]
        public IHttpActionResult Get(Guid id)
        {
            var existing = _service.GetById(id);
            if (existing == null)
                return NotFound();
           
            return Ok(existing);
        }
     

        // POST: api/StatLine
        [ResponseType(typeof(StatLineResponse))]
        public IHttpActionResult Post([FromBody]StatLineRequest statLine)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           var response =  _service.Create(statLine);

           return Ok(response);
        }

       

        // DELETE: api/StatLine/5
        public IHttpActionResult Delete(Guid id)
        {
            if (!_service.Delete(id))
                return NotFound();

            return Ok();
        }
    }
}
