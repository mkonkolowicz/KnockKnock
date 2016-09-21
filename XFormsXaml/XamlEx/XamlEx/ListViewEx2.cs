using Xamarin.Forms;

namespace XamlEx
{
    class ListViewEx2: ContentPage
    {
        public ListViewEx2()
        {
            Padding = new Thickness(0,Device.OnPlatform(20,0,0),0,0);
            var listView = new ListView();
            listView.ItemsSource = PluralsightCourse.GetCourseList();
            listView.ItemTemplate = new DataTemplate(typeof (CourseCell));
            Content = listView;

        }
    }
}
