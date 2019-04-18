using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Models;
using Contracts.Interfaces;
using Drapper;

namespace Reservations.Repositories
{

    public class ReservationsRepository : IReservationsRepository
    {
        IDbCommander dbCommander;
        private Object thisLock = new Object();  
        public ReservationsRepository(IDbCommander _dbC)
        {
            dbCommander = _dbC;
        }

        int GetReservationId(Reservation res)
        {
            int id;
            var model = new Reservation
            {               
                CourtId = res.CourtId,
                PriceId = res.PriceId,
                UserId = res.UserId,
                StatusId = res.StatusId,
                Comments = res.Comments,
                StartTime = res.StartTime,
                EndTime = res.EndTime,
                FacilityId = res.FacilityId,
                PlayersNo = res.PlayersNo,
                SlotNo = res.SlotNo
            };

            try
            {
                id = dbCommander.Query<int>(model).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }

        public Reservation CreateReservation(Reservation res)
        {
            
                try
                {
                    lock (thisLock)
                    {
                        res.Id = GetReservationId(res);
                        if (res.Id == 0)
                        {
                            dbCommander.Execute(res);
                            res.Id = GetReservationId(res);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return res;
        }

        public Reservation UpdateReservation(int Id, Reservation res)
        {
            var model = new Reservation
            {
                Id = Id,
                CourtId = res.CourtId,
                PriceId = res.PriceId,
                UserId = res.UserId,
                StatusId = res.StatusId,
                Comments = res.Comments,
                StartTime = res.StartTime,
                EndTime = res.EndTime,
                FacilityId = res.FacilityId,
                PlayersNo = res.PlayersNo,
                SlotNo = res.SlotNo,
                Players = res.Players
            };

            try
            {
                var result = dbCommander.Execute(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
            return res;
        }


        public List<Reservation> GetReservationsByCourtId(int courtId)
        {
            return dbCommander.Query<Reservation>(new { CourtId = courtId }).ToList();
        }

        public IEnumerable<Reservation> GetReservationsByStartTime(DateTime startTime)
        {
            return dbCommander.Query<Reservation>(new { StartTime = startTime }).ToList();
        }

        public IEnumerable<Reservation> GetReservationsByFacilitySearchCriteria(string searchCriteria)
        {
            return dbCommander.Query<Reservation>(new { FacilitySearchCriteria = searchCriteria }).ToList();
        }

        public IEnumerable<Reservation> GetReservationsByFacilityId(int facilityId)
        {
            return dbCommander.Query<Reservation>(new { FacilityId = facilityId }).ToList();
        }
      
        public void DeleteReservation(int id)
        {
            dbCommander.Execute(new { Id = id });
        }


        public List<Reservation> GetReservationById(int id)
        {
            return dbCommander.Query<Reservation>(new { Id = id }).ToList();
        }


        public Reservation GetReservationBySlotAndCourt(int slot, int court)
        {
            return dbCommander.Query<Reservation>(new { Slot = slot, Court=court }).FirstOrDefault();
        }
    }
}
