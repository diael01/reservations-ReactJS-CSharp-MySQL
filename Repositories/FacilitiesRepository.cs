using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Contracts.Models;
using Drapper;

namespace Reservations.Repositories
{
    public class FacilitiesRepository : IFacilitiesRepository
    {
        IDbCommander dbCommander;
        public FacilitiesRepository(IDbCommander _dbC)
        {
            dbCommander = _dbC;
        }

        public IEnumerable<Facility> GetFacilities()
        {
            return dbCommander.Query<Facility>();
        }

        public List<Facility> GetFacilitiesBySearchCriteria(string SearchCriteria)
        {
            return dbCommander.Query<Facility>(new { SearchCriteria }).ToList();           
        }
    }
}
