package mono.com.google.android.exoplayer2.source;


public class MediaSource_SourceInfoRefreshListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.exoplayer2.source.MediaSource.SourceInfoRefreshListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSourceInfoRefreshed:(Lcom/google/android/exoplayer2/source/MediaSource;Lcom/google/android/exoplayer2/Timeline;Ljava/lang/Object;)V:GetOnSourceInfoRefreshed_Lcom_google_android_exoplayer2_source_MediaSource_Lcom_google_android_exoplayer2_Timeline_Ljava_lang_Object_Handler:Com.Google.Android.Exoplayer2.Source.IMediaSourceSourceInfoRefreshListenerInvoker, ExoPlayer.Core\n" +
			"";
		mono.android.Runtime.register ("Com.Google.Android.Exoplayer2.Source.IMediaSourceSourceInfoRefreshListenerImplementor, ExoPlayer.Core", MediaSource_SourceInfoRefreshListenerImplementor.class, __md_methods);
	}


	public MediaSource_SourceInfoRefreshListenerImplementor ()
	{
		super ();
		if (getClass () == MediaSource_SourceInfoRefreshListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Google.Android.Exoplayer2.Source.IMediaSourceSourceInfoRefreshListenerImplementor, ExoPlayer.Core", "", this, new java.lang.Object[] {  });
	}


	public void onSourceInfoRefreshed (com.google.android.exoplayer2.source.MediaSource p0, com.google.android.exoplayer2.Timeline p1, java.lang.Object p2)
	{
		n_onSourceInfoRefreshed (p0, p1, p2);
	}

	private native void n_onSourceInfoRefreshed (com.google.android.exoplayer2.source.MediaSource p0, com.google.android.exoplayer2.Timeline p1, java.lang.Object p2);

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
