using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopGunSyllabus.Core.Model;
using TopGunSyllabus.Core.Repository;

namespace TopGunSyllabus.Core.Service
{
    public class PhaseDataService
    {
        private static PhaseRepository phaseRepository = new PhaseRepository();

        public List<Phase> GetAllPhases()
        {
            return phaseRepository.GetAllPhases().ToList();
        }

        public Phase ReturnPhaseById(int phaseId)
        {
            return phaseRepository.GetPhaseById(phaseId);
        }

    }
}
