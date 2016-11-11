using System;
using Android.App;
using Android.OS;
using Android.Gms.Maps;
using Android.Support.V4.App;
using Android.Gms.Maps.Model;
using Android.Util;

namespace Chapter03._3_Maps_Google_Finish
{
    [Activity(Label = "Here", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IOnMapReadyCallback//OnMapReadyCallback
    {
        private GoogleMap mMap;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Log.Warn("aaaaaaaaaaaaaaaaaaaaaaaa", "0");
            SetUpMap();
        }


        //Set map
        public void SetUpMap()
        {
            //SupportMapFragment mapFragment = (SupportMapFragment)getSupportFragmentManager()
            //   .findFragmentById(R.id.map);
            //mapFragment.getMapAsync(this);
            Log.Warn("aaaaaaaaaaaaaaaaaaaaaaaa", "01");
            if (mMap == null)
            {
                Log.Warn("aaaaaaaaaaaaaaaaaaaaaaaa", "02");
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
                Log.Warn("aaaaaaaaaaaaaaaaaaaaaaaa", "03");
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            Log.Warn("aaaaaaaaaaaaaaaaaaaaaaaa", "04");
            mMap = googleMap;
            Log.Warn("aaaaaaaaaaaaaaaaaaaaaaaa", "05");
            // Add a marker in Sydney and move the camera
            LatLng sydney = new LatLng(-34, 151);
            mMap.AddMarker(new MarkerOptions().SetPosition(sydney).SetTitle("Marker in Sydney"));
            mMap.MoveCamera(CameraUpdateFactory.NewLatLng(sydney));
            Log.Warn("aaaaaaaaaaaaaaaaaaaaaaaa", "06");
        }
    }
}     
//        GoogleMap map;
//        bool SetUpMap()
//        {
//            if (null != map) return false;

//            var frag = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map);
//            var mapReadyCallback = new OnMapReadyClass();

//            mapReadyCallback.MapReadyAction += delegate (GoogleMap googleMap)
//            {
//                map = googleMap;
//            };

//            frag.GetMapAsync(mapReadyCallback);
//            return true;
//        }
//    }
//    //OnMapReadyClass
//    public class OnMapReadyClass : Java.Lang.Object, IOnMapReadyCallback
//    {
//        public GoogleMap Map { get; private set; }
//        public event Action<GoogleMap> MapReadyAction;

//        public void OnMapReady(GoogleMap googleMap)
//        {
//            Map = googleMap;

//            if (MapReadyAction != null)
//                MapReadyAction(Map);
//        }
//    }
//}