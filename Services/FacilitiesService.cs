using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Models;
using Contracts.Interfaces;

namespace Services
{
    public class FacilitiesService : IFacilitiesService
    {
        IFacilitiesRepository facilRepository;
        public FacilitiesService(IFacilitiesRepository _fRepo)
        {
            facilRepository = _fRepo;
        }

        public IEnumerable<Facility> GetFacilities()
        {
            return facilRepository.GetFacilities();
        }

        public List<Facility> GetFacilitiesBySearchCriteria(string facilitysearchCriteria)
        {
            return facilRepository.GetFacilitiesBySearchCriteria(facilitysearchCriteria);            
        }
    }
}
