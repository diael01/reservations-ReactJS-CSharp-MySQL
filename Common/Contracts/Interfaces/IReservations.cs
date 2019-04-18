using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Models;

namespace Contracts.Interfaces
{
    public interface IReservationsRepository
    {
         List<Reservation> GetReservationById(int Id);
         List<Reservation> GetReservationsByCourtId(int courtId);
         IEnumerable<Reservation> GetReservationsByStartTime(DateTime startTime);
         IEnumerable<Reservation> GetReservationsByFacilitySearchCriteria(string name);
         IEnumerable<Reservation> GetReservationsByFacilityId(int id);
         Reservation CreateReservation(Reservation res);
         Reservation UpdateReservation(int Id, Reservation res);
         void DeleteReservation(int Id);
         Reservation GetReservationBySlotAndCourt(int slot, int court);
    }

    public interface IReservationsService
    {
        List<Reservation> GetReservationsByCourtId(int courtId);
        IEnumerable<Reservation> GetReservationsByStartTime(DateTime startTime);
        IEnumerable<Reservation> GetReservationsByFacilityName(string name);
        IEnumerable<Reservation> GetReservationsByFacilityId(int id);
        Reservation CreateReservation(Reservation res);
        Reservation UpdateReservation(int Id, Reservation res);
        void DeleteReservation(int Id);
        Reservation GetReservationBySlotAndCourt(int slot, int court);

    }
}
