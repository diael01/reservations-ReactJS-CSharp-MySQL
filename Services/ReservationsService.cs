using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Contracts.Models;


namespace Services
{
    public class ReservationsService : IReservationsService
    {
        IReservationsRepository resRepository;
        public ReservationsService(IReservationsRepository _resRepo)
        {
            resRepository = _resRepo;
        }
        Reservation IReservationsService.CreateReservation(Reservation res)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(res.StartTime);
            DateTime dtEnd = TimeZone.CurrentTimeZone.ToLocalTime(res.EndTime);
            res.StartTime = dtStart;
            res.EndTime = dtEnd;
            return resRepository.CreateReservation(res);
        }

        Reservation IReservationsService.UpdateReservation(int Id, Reservation res)
        {
            return resRepository.UpdateReservation(Id, res);
        }


        public IEnumerable<Reservation> GetReservationsByStartTime(DateTime startTime)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> GetReservationsByFacilityName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> GetReservationsByFacilityId(int id)
        {
            return resRepository.GetReservationsByFacilityId(id);
        }

        public List<Reservation> GetReservationsByCourtId(int courtId)
        {
            return resRepository.GetReservationsByCourtId(courtId);
        }

        public void DeleteReservation(int Id)
        {
            resRepository.DeleteReservation(Id);
        }


        public Reservation GetReservationBySlotAndCourt(int slot, int court)
        {
            return resRepository.GetReservationBySlotAndCourt(slot,court);
        }
    }
}
