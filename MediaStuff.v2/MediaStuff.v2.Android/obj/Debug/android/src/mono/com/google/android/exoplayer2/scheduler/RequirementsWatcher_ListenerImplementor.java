package mono.com.google.android.exoplayer2.scheduler;


public class RequirementsWatcher_ListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.exoplayer2.scheduler.RequirementsWatcher.Listener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_requirementsMet:(Lcom/google/android/exoplayer2/scheduler/RequirementsWatcher;)V:GetRequirementsMet_Lcom_google_android_exoplayer2_scheduler_RequirementsWatcher_Handler:Com.Google.Android.Exoplayer2.Scheduler.RequirementsWatcher/IListenerInvoker, ExoPlayer.Core\n" +
			"n_requirementsNotMet:(Lcom/google/android/exoplayer2/scheduler/RequirementsWatcher;)V:GetRequirementsNotMet_Lcom_google_android_exoplayer2_scheduler_RequirementsWatcher_Handler:Com.Google.Android.Exoplayer2.Scheduler.RequirementsWatcher/IListenerInvoker, ExoPlayer.Core\n" +
			"";
		mono.android.Runtime.register ("Com.Google.Android.Exoplayer2.Scheduler.RequirementsWatcher+IListenerImplementor, ExoPlayer.Core", RequirementsWatcher_ListenerImplementor.class, __md_methods);
	}


	public RequirementsWatcher_ListenerImplementor ()
	{
		super ();
		if (getClass () == RequirementsWatcher_ListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Google.Android.Exoplayer2.Scheduler.RequirementsWatcher+IListenerImplementor, ExoPlayer.Core", "", this, new java.lang.Object[] {  });
	}


	public void requirementsMet (com.google.android.exoplayer2.scheduler.RequirementsWatcher p0)
	{
		n_requirementsMet (p0);
	}

	private native void n_requirementsMet (com.google.android.exoplayer2.scheduler.RequirementsWatcher p0);


	public void requirementsNotMet (com.google.android.exoplayer2.scheduler.RequirementsWatcher p0)
	{
		n_requirementsNotMet (p0);
	}

	private native void n_requirementsNotMet (com.google.android.exoplayer2.scheduler.RequirementsWatcher p0);

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
