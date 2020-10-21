package mono.com.google.android.exoplayer2.ui.spherical;


public class SphericalSurfaceView_SurfaceListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.exoplayer2.ui.spherical.SphericalSurfaceView.SurfaceListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_surfaceChanged:(Landroid/view/Surface;)V:GetSurfaceChanged_Landroid_view_Surface_Handler:Com.Google.Android.Exoplayer2.UI.Spherical.SphericalSurfaceView/ISurfaceListenerInvoker, ExoPlayer.UI\n" +
			"";
		mono.android.Runtime.register ("Com.Google.Android.Exoplayer2.UI.Spherical.SphericalSurfaceView+ISurfaceListenerImplementor, ExoPlayer.UI", SphericalSurfaceView_SurfaceListenerImplementor.class, __md_methods);
	}


	public SphericalSurfaceView_SurfaceListenerImplementor ()
	{
		super ();
		if (getClass () == SphericalSurfaceView_SurfaceListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Google.Android.Exoplayer2.UI.Spherical.SphericalSurfaceView+ISurfaceListenerImplementor, ExoPlayer.UI", "", this, new java.lang.Object[] {  });
	}


	public void surfaceChanged (android.view.Surface p0)
	{
		n_surfaceChanged (p0);
	}

	private native void n_surfaceChanged (android.view.Surface p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
