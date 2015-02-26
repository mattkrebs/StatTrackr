using AutoMapper;
using StatTrackr.Model.Data;
using StatTrackr.Service.Interfaces;
using StatTrackr.WebApi.Models.Request;
using StatTrackr.WebApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StatTrackr.WebApi.Controllers
{
    public class StatLineController : ApiController
    {
        IStatLineService _service;
        public StatLineController(IStatLineService service)
        {
            _service = service;
        }
        // GET: api/StatLine/5
        public IHttpActionResult Get(Guid id)
        {
            var existing = _service.GetById(id);
            if (existing == null)
                return NotFound();
           
            return Ok(Mapper.Map<StatLineResponse>(existing));
        }
     

        // POST: api/StatLine
        public IHttpActionResult Post([FromBody]StatLineRequest statLine)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newStatLine = Mapper.Map<StatLine>(statLine);
            _service.Create(newStatLine);

            return Ok(Mapper.Map<StatLineResponse>(newStatLine));
        }

        // PUT: api/StatLine/5
        public IHttpActionResult Put(Guid id, [FromBody]StatLineRequest statLine)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = _service.GetById(id);
            if (existing == null)
                return NotFound();

            existing = Mapper.Map<StatLineRequest, StatLine>(statLine, existing);
            _service.Update(existing);

            return Ok(Mapper.Map<StatLineResponse>(existing));
        }

        // DELETE: api/StatLine/5
        public IHttpActionResult Delete(Guid id)
        {
            var existing = _service.GetById(id);
            if (existing == null)
                return NotFound();

            _service.Delete(existing);

            return Ok();
        }
    }
}
