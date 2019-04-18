using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Models;

namespace Contracts.Interfaces
{
    public interface IFacilitiesRepository
    {
        IEnumerable<Facility> GetFacilities();
        List<Facility> GetFacilitiesBySearchCriteria(string _searchCriteria);
    }

    public interface IFacilitiesService
    {
        IEnumerable<Facility> GetFacilities();
        List<Facility> GetFacilitiesBySearchCriteria(string _searchCriteria);
    }
}
