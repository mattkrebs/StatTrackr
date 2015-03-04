using StatTrackr.Model.Data;
using StatTrackr.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace StatTrackr.WebApi.Controllers
{
    public class PositionController : ApiController
    {
        IPositionService _service;
        public PositionController(IPositionService service)
        {
            _service = service;
        }
        // GET: api/Position
        [ResponseType(typeof(IEnumerable<Position>))]
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAll());
        }
    }
}
