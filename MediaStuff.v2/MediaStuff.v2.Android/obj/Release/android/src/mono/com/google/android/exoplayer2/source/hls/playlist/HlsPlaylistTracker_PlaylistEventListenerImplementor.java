package mono.com.google.android.exoplayer2.source.hls.playlist;


public class HlsPlaylistTracker_PlaylistEventListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.exoplayer2.source.hls.playlist.HlsPlaylistTracker.PlaylistEventListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPlaylistChanged:()V:GetOnPlaylistChangedHandler:Com.Google.Android.Exoplayer2.Source.Hls.Playlist.IHlsPlaylistTrackerPlaylistEventListenerInvoker, ExoPlayer.Hls\n" +
			"n_onPlaylistError:(Lcom/google/android/exoplayer2/source/hls/playlist/HlsMasterPlaylist$HlsUrl;J)Z:GetOnPlaylistError_Lcom_google_android_exoplayer2_source_hls_playlist_HlsMasterPlaylist_HlsUrl_JHandler:Com.Google.Android.Exoplayer2.Source.Hls.Playlist.IHlsPlaylistTrackerPlaylistEventListenerInvoker, ExoPlayer.Hls\n" +
			"";
		mono.android.Runtime.register ("Com.Google.Android.Exoplayer2.Source.Hls.Playlist.IHlsPlaylistTrackerPlaylistEventListenerImplementor, ExoPlayer.Hls", HlsPlaylistTracker_PlaylistEventListenerImplementor.class, __md_methods);
	}


	public HlsPlaylistTracker_PlaylistEventListenerImplementor ()
	{
		super ();
		if (getClass () == HlsPlaylistTracker_PlaylistEventListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Google.Android.Exoplayer2.Source.Hls.Playlist.IHlsPlaylistTrackerPlaylistEventListenerImplementor, ExoPlayer.Hls", "", this, new java.lang.Object[] {  });
	}


	public void onPlaylistChanged ()
	{
		n_onPlaylistChanged ();
	}

	private native void n_onPlaylistChanged ();


	public boolean onPlaylistError (com.google.android.exoplayer2.source.hls.playlist.HlsMasterPlaylist.HlsUrl p0, long p1)
	{
		return n_onPlaylistError (p0, p1);
	}

	private native boolean n_onPlaylistError (com.google.android.exoplayer2.source.hls.playlist.HlsMasterPlaylist.HlsUrl p0, long p1);

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
