using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;

namespace Chapter03._2_Maps.GoogleFix
{
    //[Activity(MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    [Activity(Label = "Chapter03._2_Maps.GoogleFix", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IOnMapReadyCallback
    {
        private GoogleMap mMap;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            //SupportMapFragment mapFragment = (SupportMapFragment)GetSupportFragmentManager().FindFragmentById(Resource.Id.map);
            //mapFragment.GetMapAsync(this);

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

        public void onMapReady(GoogleMap googleMap)
        {
            mMap = googleMap;

            // Add a marker in Sydney and move the camera
            //LatLng sydney = new LatLng(10.7, 106);//(-34, 151);
            //mMap.AddMarker(new MarkerOptions().SetPosition(sydney).SetTitle("HP"));
            //mMap.MoveCamera(CameraUpdateFactory.NewLatLng(sydney));
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            throw new NotImplementedException();
        }
    }
}

