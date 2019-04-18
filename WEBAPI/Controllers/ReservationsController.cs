using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using WEBAPI.Infrastructure;
using System.Web.Http.Cors;
using System.Threading.Tasks;
using Contracts.Models;
using Contracts.Interfaces;

namespace WEBAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/reservations")]
    public class ReservationsController : ApiController
    {
        IReservationsService svc;
        public ReservationsController(IReservationsService _svc)
        {
            svc = _svc;
        }
       

        [Route("CreateReservation")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateReservation(Reservation res)
        {
            return Ok(svc.CreateReservation(res));
        }

        [Route("GetReservationBySlotAndCourt/{slot}/{court}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetReservationBySlotAndCourt(int slot, int court)
        {
            return Ok(svc.GetReservationBySlotAndCourt(slot,court));
        }

        [Route("GetReservationsByFacilityId/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetReservationsByFacilityId(int id)
        {
            return Ok(svc.GetReservationsByFacilityId(id));
        }

        [Route("UpdateReservation")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateReservation(int Id, Reservation res)
        {
            return Ok(svc.UpdateReservation(Id, res));
        }

        [Route("DeleteReservation/{id}")]
        [HttpPost]
        public void DeleteReservation(int Id)
        {
            svc.DeleteReservation(Id);
        }
    }
}