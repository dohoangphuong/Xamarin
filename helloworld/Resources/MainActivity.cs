using Android.Gms.Maps;
using Android.OS;
using Android.App;
using Android.Support.V4.App;
using System;
using Android.Gms.Maps.Model;

namespace helloworld
{
    [Activity(Label = "helloworld", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IOnMapReadyCallback
    {
        public GoogleMap mMap { get; private set; }

        public event EventHandler MapReady;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            if (mMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }
        }

        void IOnMapReadyCallback.OnMapReady(GoogleMap googleMap)
        {
            mMap = googleMap;
            var handler = MapReady;
            if (handler != null)
                handler(this, EventArgs.Empty);
            //mMap = googleMap;

            //// Add a marker in Sydney and move the camera
            //LatLng sydney = new LatLng(-34, 151);
            //mMap.AddMarker(new MarkerOptions().SetPosition(sydney).SetTitle("Marker in Sydney"));
            //mMap.MoveCamera(CameraUpdateFactory.NewLatLng(sydney));
        }
    }
}