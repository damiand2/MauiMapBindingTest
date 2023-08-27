using CoreLocation;
using Foundation;
using MapUtilsBinding;
using Maui.GoogleMaps;

namespace MauiMapBindingTest;


public partial class MainPage : ContentPage
{
	int count = 0;
	ClusterManager clusterManager;

    public MainPage()
	{
		InitializeComponent();
		map.CameraIdled += mapIdled;
		
	}

	private void mapIdled(object sender, CameraIdledEventArgs ea)
	{
		if (clusterManager == null)
			return;
		clusterManager.Cluster();
	}


    public void OnCLusterClicked(object sender, EventArgs ea)
	{
		var alg = new NonHierarchicalDistanceBasedAlgorithm();
		var iconGenerator = new DefaultClusterIconGenerator();

        var clusterRenderer = new DefaultClusterRenderer((Google.Maps.MapView)map.Handler.PlatformView, iconGenerator);		

        clusterManager = new ClusterManager((Google.Maps.MapView)map.Handler.PlatformView, alg, clusterRenderer);
		double lat = 50.0745160;
		double lng = 14.437;
		for (int i = 0; i < 100; i++)
		{
			double offset = 0.0001 * i;
            //var lat1 = lat + offset;
            lat = lat + offset;
            lng = lng + offset;
			var item = new ClusterItem(lat, lng);
			clusterManager.AddItem(item);
		}
		clusterManager.Cluster();

    }



}

public class ClusterItem: Google.Maps.Marker, IClusterItem
{
	public ClusterItem(double lat, double lon)
	{
		Position = new CLLocationCoordinate2D(lat, lon);
	}
}

