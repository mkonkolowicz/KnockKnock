using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlEx
{
    class PluralsightCourse
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return this.Title;
        }

        public static List<PluralsightCourse> GetCourseList()
        {
            return new List<PluralsightCourse>()
            {
                new PluralsightCourse() {Author = "Maciek",Title = "Running Xamarin Natively"},
                new PluralsightCourse() {Author = "Mike Y.", Title = "Getting  Azure at Title Source"}
            };

        }
    }
}
