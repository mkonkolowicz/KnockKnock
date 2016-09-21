using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamlEx
{
    public class CourseMasterDetailDB : MasterDetailPage
    {
        public CourseMasterDetailDB()
        {
            var listView = new ListView() {ItemsSource = PluralsightCourse.GetCourseList()};
            listView.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem != null)
                {
                    Detail.BindingContext = e.SelectedItem;
                    IsPresented = false;
                }
            };
            Master = new ContentPage() {Title = "Courses", Content = listView};
            Detail = new CoursePageDB();
            Detail.BindingContext = PluralsightCourse.GetCourseList().First();
        }
    }
}
