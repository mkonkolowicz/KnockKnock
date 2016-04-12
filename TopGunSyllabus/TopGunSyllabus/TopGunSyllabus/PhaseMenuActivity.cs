using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TopGunSyllabus.Adapters;
using TopGunSyllabus.Core.Model;
using TopGunSyllabus.Core.Service;

namespace TopGunSyllabus
{
    [Activity(Label = "PhaseMenuActivity", MainLauncher = true)]
    public class PhaseMenuActivity : Activity
    {
        private ListView phaseListView;
        private List<Phase> allPhases;
        private PhaseDataService phaseDataService; 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PhasesMenuView);
            phaseListView = FindViewById<ListView>(Resource.Id.PhasesListView);
            phaseDataService = new PhaseDataService();
            allPhases = phaseDataService.GetAllPhases();
            phaseListView.Adapter = new PhaseListAdapter(this,allPhases);
        }
    }
}