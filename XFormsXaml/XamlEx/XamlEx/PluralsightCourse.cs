using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlEx
{
    public class PluralsightCourse
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string TitleShort { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return this.Title;
        }

        public static List<PluralsightCourse> GetCourseList()
        {
            return new List<PluralsightCourse>()
            {
                new PluralsightCourse() {Author = "Maciek",Title = "Running Xamarin Natively", TitleShort = "Run Xamarin Native", Description = "Running xamarin natively on iOS and Android"},
                new PluralsightCourse() {Author = "Mike Y.", Title = "Getting  Azure at Title Source", TitleShort = "Azure at TSI", Description = "How to get TSI to use Azure as it's IT infrastructure"}
            };

        }
    }
}
