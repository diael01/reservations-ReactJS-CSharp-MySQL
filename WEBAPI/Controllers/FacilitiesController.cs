using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using WEBAPI.Infrastructure;
using System.Web.Http.Cors;
using System.Threading.Tasks;
using Services;
using Contracts.Interfaces;


namespace WEBAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/facilities")]
    public class FacilitiesController : ApiController
    {
        IFacilitiesService svc;
        public FacilitiesController(IFacilitiesService _svc)
        {
            svc = _svc;
        }

        [Route("GetFacilities")]
        [HttpGet]
        public async Task<IHttpActionResult> GetFacilities()
        {
            return Ok(svc.GetFacilities());
        }

        [Route("GetFacilitiesByCriteria/{token}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetFacilitiesByCriteria(string token)
        {
            return Ok(svc.GetFacilitiesBySearchCriteria(token));
        }
    }
}