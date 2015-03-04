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
    public class StatTypeController : ApiController
    {
         IStatTypeService _service;
         public StatTypeController(IStatTypeService service)
        {
            _service = service;
        }
        // GET: api/Position
        [ResponseType(typeof(IEnumerable<StatType>))]
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAll());
        }
    }
}
