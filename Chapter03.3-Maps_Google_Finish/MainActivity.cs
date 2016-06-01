using System;
using Android.App;
using Android.OS;
using Android.Gms.Maps;

namespace Chapter03._3_Maps_Google_Finish
{
    [Activity(Label = "Chapter03._3_Maps_Google_Finish", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IOnMapReadyCallback
    {
        private GoogleMap mMap;

        public void OnMapReady(GoogleMap googleMap)
        {
            mMap = googleMap;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            SetUpMap();
        }

        //Set map
        private void SetUpMap()
        {
            if (mMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }
        }        
    }
}