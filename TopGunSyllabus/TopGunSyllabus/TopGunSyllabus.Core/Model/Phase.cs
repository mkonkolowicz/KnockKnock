using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGunSyllabus.Core.Model
{
    public class Phase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public int Length { get; set; }
        public string LearningObjectives { get; set; }
    }
}
