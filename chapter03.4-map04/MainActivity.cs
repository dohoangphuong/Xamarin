using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;

namespace chapter03._4_map04
{
    [Activity(Label = "chapter03_4_map04", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        GoogleMap map;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            SetUpGoogleMap();
        }
        
        bool SetUpGoogleMap()
        {
            if (null != map) return false;

            var frag = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map);
            var mapReadyCallback = new OnMapReadyClass();

            mapReadyCallback.MapReadyAction += delegate (GoogleMap googleMap)
            {
                map = googleMap;
            };

            frag.GetMapAsync(mapReadyCallback);
            return true;
        }
    }
    //OnMapReadyClass
    public class OnMapReadyClass : Java.Lang.Object, IOnMapReadyCallback
    {
        public GoogleMap Map { get; private set; }
        public event Action<GoogleMap> MapReadyAction;

        public void OnMapReady(GoogleMap googleMap)
        {
            Map = googleMap;

            if (MapReadyAction != null)
                MapReadyAction(Map);
        }
    }
}

