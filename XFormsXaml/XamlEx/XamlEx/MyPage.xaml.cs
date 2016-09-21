using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamlEx
{
    public partial class MyPage : ContentPage
    {
        public MyPage()
        {
            //InitializeComponent();
            //boxViewColour.Color = Color.Blue;
            var classNames = new[]
            {
                "Building Cross Platform Apps with Xamarin Part1",
                "Building Cross Platform Apps with Xamarin Part2",
                "Building Cross Platform Apps with Xamarin Part3"
            };

            //TODO: Translate into XAML
            Padding = new Thickness(0,Device.OnPlatform(20,0,0),0,0);
            var listView = new ListView();
            //listView.ItemsSource = classNames;
            //listView.ItemsSource =
            //    from c in classNames
            //    where c.StartsWith("Building")
            //    select c;
            listView.ItemsSource = PluralsightCourse.GetCourseList();

            listView.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem != null)
                {
                    Debug.WriteLine("Selected: " + e.SelectedItem);
                }
                listView.SelectedItem = null;
            };

            Content = listView;

        }
        //public void OnColorSliderChanged(Object sender, EventArgs e)
        //{
        //    var red = sliderRed.Value;
        //    var green = sliderGreen.Value;
        //    var blue = sliderBlue.Value;

        //    boxViewColour.Color = Color.FromRgb(red, green, blue);
        //}
    }
}
