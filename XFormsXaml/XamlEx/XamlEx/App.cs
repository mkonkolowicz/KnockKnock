using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XamlEx
{
    public class App : Application
    {
        public App()
        {
            //MainPage = new MyPage();
            //MainPage = new ListViewEx();
            //MainPage = new ListViewEx2();
            //MainPage = new XFPage2();
            //MainPage = new XFPage3();
            MainPage = //new CoursePage(PluralsightCourse.GetCourseList().First());
                new NavigationPage( new HomePage());
        }
        
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
