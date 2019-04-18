using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contracts.Models
{
    public class Reservation 
    {
        public int Id {get; set;}
        public int CourtId {get; set;}
        public int PriceId {get; set;}
        public int UserId {get; set;}
        public int StatusId {get; set;}
        public string Comments {get; set;}
        public DateTime StartTime {get; set;}
        public DateTime EndTime {get; set;}
        public int FacilityId {get; set;}
        public int PlayersNo {get; set;}
        public int SlotNo { get; set; }
        public string Players { get; set; }
    }
}
