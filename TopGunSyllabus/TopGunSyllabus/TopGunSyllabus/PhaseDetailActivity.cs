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
using TopGunSyllabus.Core.Model;
using TopGunSyllabus.Core.Service;
using TopGunSyllabus.Utility;

namespace TopGunSyllabus
{
    [Activity(Label = "Syllabus Phase Details", MainLauncher = false)]
    public class PhaseDetailActivity : Activity
    {
        private ImageView phaseDetailImageView;
        private TextView phaseNameTextView;
        private TextView phaseSummaryTextView;
        private TextView phaseLearningObjectivesTextView;

        private Phase selectedPhase;
        private PhaseDataService dataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PhaseDetailView);
            PhaseDataService dataService = new PhaseDataService();
            selectedPhase = dataService.ReturnPhaseById(1);
            FindViews();
            BindData();
        }

        private void FindViews()
        {
            phaseDetailImageView = FindViewById<ImageView>(Resource.Id.phaseDetailImageView);
            phaseNameTextView = FindViewById<TextView>(Resource.Id.phaseNameTextView);
            phaseSummaryTextView = FindViewById<TextView>(Resource.Id.phaseSummaryTextView);
            phaseLearningObjectivesTextView = FindViewById<TextView>(Resource.Id.phaseLearningObjectivesTextView);
        }

        private void BindData()
        {
            phaseNameTextView.Text = selectedPhase.Name;
            phaseSummaryTextView.Text = selectedPhase.Summary;
            phaseLearningObjectivesTextView.Text = selectedPhase.LearningObjectives;

            var imageBitmap =
                ImageHelper.GetImageBitmapFromUrl(
                    "https://www.google.com/imgres?imgurl=http%3A%2F%2Fwww.pleasantviewchiropractic.com%2Fimages%2Fnumber41.png&imgrefurl=http%3A%2F%2Fwww.pleasantviewchiropractic.com%2Fappointment-information.html&docid=05ahGW8tuRaltM&tbnid=d1DLp5FoMAccmM%3A&w=512&h=512&ved=0ahUKEwiC7taFq4LMAhWGw4MKHWWZDh0QMwglKAAwAA&iact=mrc&uact=8");
            phaseDetailImageView.SetImageBitmap(imageBitmap);
        }
        
    }
}