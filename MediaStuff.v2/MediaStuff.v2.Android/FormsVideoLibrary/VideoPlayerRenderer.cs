using System;
using System.IO;
using Android.Content;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using FormsVideoLibrary;
using Android.App;
using Android.Views;
using Com.Google.Android.Exoplayer2.UI;
using Com.Google.Android.Exoplayer2.Source.Hls;
using Com.Google.Android.Exoplayer2.Trackselection;
using Com.Google.Android.Exoplayer2;
using Com.Google.Android.Exoplayer2.Upstream;
using Com.Google.Android.Exoplayer2.Source;
using Com.Google.Android.Exoplayer2.Util;
using Java.Lang;
using Android.Text;
using Android.Support.V4.Content;
using Android.Content.PM;
using Android.Util;
using Android.OS;
using Android.Preferences;
using Xamarin.Essentials;

[assembly: ExportRenderer(typeof(FormsVideoLibrary.VideoPlayer),
                          typeof(MediaStuff.v2.Droid.FormsVideoLibrary.VideoPlayerRenderer))]
namespace MediaStuff.v2.Droid.FormsVideoLibrary
{
    public class VideoPlayerRenderer : ViewRenderer<VideoPlayer, PlayerView>, IPlayerEventListener, PlayerView.IOnFocusChangeListener
    {
        private PlayerView _playerView;
        private SimpleExoPlayer _player;

        private DefaultTrackSelector trackSelector;
        private int INITIAL_HEIGHT = -1;
        static private Activity _context;
        ImageView fullscreenView;

        private bool isFullscreen = false;

        ScreenOrientation fullscreenOrientation;
        ISharedPreferences prefs;

        DefaultHttpDataSourceFactory defaultHttpDataSourceFactory;
        DefaultDataSourceFactory defaultDataSourceFactory;

        SystemUiFlags uiFullScreenOptions =
            SystemUiFlags.HideNavigation |
            SystemUiFlags.LayoutHideNavigation |
            SystemUiFlags.LayoutFullscreen |
            SystemUiFlags.Fullscreen |
            SystemUiFlags.LayoutStable |
            SystemUiFlags.ImmersiveSticky;

 
        public static void Init(Activity context)
        {
            _context = context;
        }

        public VideoPlayerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<VideoPlayer> args)
        {
            base.OnElementChanged(args);

            prefs = PreferenceManager.GetDefaultSharedPreferences(Context);


            if (_player == null)
            {
                InitializePlayer();
            }


            if (_player.IsPlayingAd || _player.IsLoading)
            {
                _player.Stop();
            }

            fullscreenOrientation = ScreenOrientation.Landscape;

            Play();
            SetupFunctionality(args);
            fullscreenView = (ImageView)_playerView.FindViewById(Resource.Id.exo_fullscreen_icon);

            fullscreenView.Click += delegate
            {
                if (isFullscreen)
                {
                    setMiniPlayer();
                    ((IVideoPlayerController)Element).Fullscreen = false;
                    ISharedPreferencesEditor editor = prefs.Edit();
                    editor.PutBoolean("isFullscreen", false);
                    editor.Apply();

                }
                else
                {
                    setFullScreenPlayer();
                    ((IVideoPlayerController)Element).Fullscreen = true;
                    ISharedPreferencesEditor editor = prefs.Edit();
                    editor.PutBoolean("isFullscreen", true);
                    editor.Apply();
                }
            };
        }


        private void setMiniPlayer()
        {
            fullscreenView.SetImageDrawable(ContextCompat.GetDrawable(Context, Resource.Drawable.exo_controls_fullscreen_enter));
            if (_context != null)
            {
                _context.RequestedOrientation = ScreenOrientation.Portrait;
                Element.HeightRequest = INITIAL_HEIGHT;
            }
            isFullscreen = false;
        }

        private void setFullScreenPlayer()
        {
            fullscreenView.SetImageDrawable(ContextCompat.GetDrawable(Context, Resource.Drawable.exo_controls_fullscreen_exit));
            if (_context != null)
            {

                /*
                    ============================================================================================================
                    PORTRAIT IMPLEMENTATION: [LEAVING HERE IF REQUIRED - FOR VIDEOS]
                    [Check video resolution and if it's portrait set fullscreenOrientation to portrait and carry out code below]
                    ============================================================================================================
                    int height = (int)(Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density);
                    bool hasMenuKey = ViewConfiguration.Get(Context).HasPermanentMenuKey;
                    int resourceId = Resources.GetIdentifier("navigation_bar_height", "dimen", "android");
                    int navbarheight = 0;
                    if (resourceId > 0 && !hasMenuKey)
                    {
                        navbarheight = (int) (Resources.GetDimensionPixelSize(resourceId) / Resources.DisplayMetrics.Density);
                    }

                    Element.HeightRequest = height+navbarheight;
                    =============================================================================================================
                */

                _context.RequestedOrientation = fullscreenOrientation;
                Element.HeightRequest = Xamarin.Forms.Application.Current.MainPage.Width;


            }
            isFullscreen = true;
        }

        private void SetupFunctionality(ElementChangedEventArgs<VideoPlayer> args)
        {
            if (args.NewElement != null)
            {
                args.NewElement.UpdateStatus += OnUpdateStatus;
                args.NewElement.PlayRequested += OnPlayRequested;
                args.NewElement.PauseRequested += OnPauseRequested;
                args.NewElement.StopRequested += OnStopRequested;
            }
            if (args.OldElement != null)
            {
                args.OldElement.UpdateStatus -= OnUpdateStatus;
                args.OldElement.PlayRequested -= OnPlayRequested;
                args.OldElement.PauseRequested -= OnPauseRequested;
                args.OldElement.StopRequested -= OnStopRequested;
            }
        }

        private void Play()
        {
            var userAgent = Util.GetUserAgent(Context, "App1");
            defaultHttpDataSourceFactory = new DefaultHttpDataSourceFactory(userAgent);
            defaultDataSourceFactory = new DefaultDataSourceFactory(Context, null, defaultHttpDataSourceFactory);

            if (Element.Source is UriVideoSource)
            {
                string uri = (Element.Source as UriVideoSource).Uri;

                if (!System.String.IsNullOrWhiteSpace(uri))
                {
                    _player.Prepare(BuildMediaSource(Android.Net.Uri.Parse(uri), ""));

                }
            }
            else if (Element.Source is FileVideoSource)
            {
                string filename = (Element.Source as FileVideoSource).File;

                if (!System.String.IsNullOrWhiteSpace(filename))
                {
                    //TODO: Implement File Input
                }
            }
            else if (Element.Source is ResourceVideoSource)
            {
                string package = Context.PackageName;
                string path = (Element.Source as ResourceVideoSource).Path;

                if (!System.String.IsNullOrWhiteSpace(path))
                {
                    string filename = Path.GetFileNameWithoutExtension(path).ToLowerInvariant();
                    string uri = "android.resource://" + package + "/raw/" + filename;
                    _player.Prepare(new ExtractorMediaSource.Factory(defaultDataSourceFactory).CreateMediaSource(Android.Net.Uri.Parse(uri)));
                }
            }
            _player.AddListener(this);

        }

        //Identifies if URI is HLS or another format of video.
        private IMediaSource BuildMediaSource(Android.Net.Uri uri, string overrideExtension)
        {

            int type = TextUtils.IsEmpty(overrideExtension) ? Util.InferContentType(uri) : Util.InferContentType("." + overrideExtension);

            switch (type)
            {
                case C.TypeHls:
                    return new HlsMediaSource.Factory(defaultDataSourceFactory).CreateMediaSource(uri);
                case C.TypeOther:
                    return new ExtractorMediaSource.Factory(defaultDataSourceFactory).CreateMediaSource(uri);
                default:
                    throw new IllegalStateException("Unsupported type: " + type);
            }
        }

        private void InitializePlayer()
        {
            trackSelector = new DefaultTrackSelector();
            trackSelector.SetParameters(new DefaultTrackSelector.ParametersBuilder()
                    .SetRendererDisabled(C.TrackTypeVideo, true)
                    .Build()
            );
            _player = ExoPlayerFactory.NewSimpleInstance(Context, trackSelector);
            _playerView = new PlayerView(Context) { Player = _player };

            ((IVideoPlayerController)Element).Fullscreen = false;

            SetNativeControl(_playerView);
            SetBackgroundColor(Android.Graphics.Color.Black);

            _playerView.UseController = Element.AreTransportControlsEnabled;
            _player.PlayWhenReady = Element.AutoPlay;
            INITIAL_HEIGHT = (int)Element.HeightRequest;
        }

        protected override void Dispose(bool disposing)
        {
            _player.Stop();
            _player.Release();

            trackSelector.Dispose();

            base.Dispose(disposing);
            _playerView = null;
            trackSelector = null;
            _player = null;
        }

        protected override void OnDetachedFromWindow()
        {
            base.OnDetachedFromWindow();
            _player.Stop();
            _player.Release();
        }


        void OnUpdateStatus(object sender, EventArgs args)
        {
            if (_player != null && _playerView != null)
            {
                TimeSpan timeSpan = TimeSpan.FromMilliseconds(_player.CurrentPosition);
                if(Element != null) ((IElementController)Element).SetValueFromRenderer(VideoPlayer.PositionProperty, timeSpan);

                if (_context.HasWindowFocus)
                {
                    if (isFullscreen)
                    {
                        _playerView.SystemUiVisibility = (StatusBarVisibility)uiFullScreenOptions;
                    }
                    else
                    {
                        _playerView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.Visible;

                    }
                }

                if (prefs.GetBoolean("backHit", true))
                {
                    ISharedPreferencesEditor editor = prefs.Edit();
                    editor.PutBoolean("backHit", false);
                    editor.PutBoolean("isFullscreen", false);
                    ((IVideoPlayerController)Element).Fullscreen = false;
                    editor.Apply();

                    setMiniPlayer();
                }
            }
        }

        // Play the player
        void OnPlayRequested(object sender, EventArgs args)
        {
            _player.PlayWhenReady = true;
        }

        // Pause the player
        void OnPauseRequested(object sender, EventArgs args)
        {
            _player.PlayWhenReady = false;
        }

        // Stop the player
        void OnStopRequested(object sender, EventArgs args)
        {
            //videoView.StopPlayback();
            _player.Stop();
        }

        //Is called when the player changes state.
        public void OnPlayerStateChanged(bool playWhenReady, int playbackState)
        {
            //Once the player is ready the duration of the video is set.
            if (playbackState == Player.StateReady) ((IVideoPlayerController)Element).Duration = TimeSpan.FromMilliseconds((double)_player.Duration);

            //If the player is idle it is not ready.
            if (playbackState == Player.StateIdle)
            {
                ((IVideoPlayerController)Element).Status = VideoStatus.NotReady;
            }
            else if (playWhenReady)
            {
                ((IVideoPlayerController)Element).Status = VideoStatus.Playing;
            }
            else if (!playWhenReady)
            {
                ((IVideoPlayerController)Element).Status = VideoStatus.Paused;
            }
        }

        public void OnLoadingChanged(bool isLoading)
        {
        }

        public void OnPlaybackParametersChanged(PlaybackParameters playbackParameters)
        {
        }

        public void OnPlayerError(ExoPlaybackException error)
        {
        }

        public void OnPositionDiscontinuity(int reason)
        {
        }

        public void OnRepeatModeChanged(int repeatMode)
        {
        }

        public void OnSeekProcessed()
        {
        }

        public void OnShuffleModeEnabledChanged(bool shuffleModeEnabled)
        {
        }

        public void OnTimelineChanged(Timeline timeline, Java.Lang.Object manifest, int reason)
        {
        }

        public void OnTracksChanged(TrackGroupArray trackGroups, TrackSelectionArray trackSelections)
        {
        }


    }
}