using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopGunSyllabus.Core.Model;

namespace TopGunSyllabus.Core.Repository
{
    public class PhaseRepository
    {
        private static List<Phase> SyllabusPhases = new List<Phase>()
        {
            new Phase()
            {
                Id = 1,
                Name = "Introduction to a Coding Environment",
                LearningObjectives ="Intro to TFS including source control, the development environment \r\n A review of basic development including types, operators, arrays, loops, classes \r\n A review of basic OOP principles including interfaces and abstract classes in a C# context",
                Length = 1,
                Summary ="Students will become familiar with coding in a C# environment. The week will include an introduction to Title Source specific tools and programming concepts"
            }
        };

        public IEnumerable<Phase> GetAllPhases()
        {
            IEnumerable<Phase> phases =
                from Phase in SyllabusPhases
                select Phase;
            return phases;
        }

        public Phase GetPhaseById(int phaseId)
        {
            IEnumerable<Phase> phases =
                from Phase in SyllabusPhases
                where Phase.Id == phaseId
                select Phase;
            return phases.FirstOrDefault();
        }
    }
}
