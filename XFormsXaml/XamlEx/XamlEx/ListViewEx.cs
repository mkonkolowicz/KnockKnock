using Xamarin.Forms;

namespace XamlEx
{
    public class ListViewEx : ContentPage
    {
        public ListViewEx()
        {
            var classNames = new[]
            {
                "Building Cross Platform Apps with Xamarin Part1",
                "Building Cross Platform Apps with Xamarin Part2",
                "Building Cross Platform Apps with Xamarin Part3"
            };

            //TODO: Translate into XAML
            Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            var listView = new ListView();
            //listView.ItemsSource = classNames;
            listView.ItemsSource = PluralsightCourse.GetCourseList();

            var cell = new DataTemplate(typeof(TextCell));
            //cell.SetBinding(TextCell.TextProperty, new Binding("."));
            cell.SetBinding(TextCell.TextProperty, new Binding("Title"));
            cell.SetBinding(TextCell.DetailProperty, new Binding("Author"));
            cell.SetValue(TextCell.TextColorProperty, Color.Red);
            cell.SetValue(TextCell.DetailColorProperty,Color.Yellow);

            listView.ItemTemplate = cell;
            Content = listView;
        }
    }
}
