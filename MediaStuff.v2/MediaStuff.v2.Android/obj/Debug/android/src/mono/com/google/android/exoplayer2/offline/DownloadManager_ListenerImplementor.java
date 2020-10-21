package mono.com.google.android.exoplayer2.offline;


public class DownloadManager_ListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.exoplayer2.offline.DownloadManager.Listener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onIdle:(Lcom/google/android/exoplayer2/offline/DownloadManager;)V:GetOnIdle_Lcom_google_android_exoplayer2_offline_DownloadManager_Handler:Com.Google.Android.Exoplayer2.Offline.DownloadManager/IListenerInvoker, ExoPlayer.Core\n" +
			"n_onInitialized:(Lcom/google/android/exoplayer2/offline/DownloadManager;)V:GetOnInitialized_Lcom_google_android_exoplayer2_offline_DownloadManager_Handler:Com.Google.Android.Exoplayer2.Offline.DownloadManager/IListenerInvoker, ExoPlayer.Core\n" +
			"n_onTaskStateChanged:(Lcom/google/android/exoplayer2/offline/DownloadManager;Lcom/google/android/exoplayer2/offline/DownloadManager$TaskState;)V:GetOnTaskStateChanged_Lcom_google_android_exoplayer2_offline_DownloadManager_Lcom_google_android_exoplayer2_offline_DownloadManager_TaskState_Handler:Com.Google.Android.Exoplayer2.Offline.DownloadManager/IListenerInvoker, ExoPlayer.Core\n" +
			"";
		mono.android.Runtime.register ("Com.Google.Android.Exoplayer2.Offline.DownloadManager+IListenerImplementor, ExoPlayer.Core", DownloadManager_ListenerImplementor.class, __md_methods);
	}


	public DownloadManager_ListenerImplementor ()
	{
		super ();
		if (getClass () == DownloadManager_ListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Google.Android.Exoplayer2.Offline.DownloadManager+IListenerImplementor, ExoPlayer.Core", "", this, new java.lang.Object[] {  });
	}


	public void onIdle (com.google.android.exoplayer2.offline.DownloadManager p0)
	{
		n_onIdle (p0);
	}

	private native void n_onIdle (com.google.android.exoplayer2.offline.DownloadManager p0);


	public void onInitialized (com.google.android.exoplayer2.offline.DownloadManager p0)
	{
		n_onInitialized (p0);
	}

	private native void n_onInitialized (com.google.android.exoplayer2.offline.DownloadManager p0);


	public void onTaskStateChanged (com.google.android.exoplayer2.offline.DownloadManager p0, com.google.android.exoplayer2.offline.DownloadManager.TaskState p1)
	{
		n_onTaskStateChanged (p0, p1);
	}

	private native void n_onTaskStateChanged (com.google.android.exoplayer2.offline.DownloadManager p0, com.google.android.exoplayer2.offline.DownloadManager.TaskState p1);

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
