using System;

namespace FormsVideoLibrary
{ 
    public interface IVideoPlayerController
    {
        VideoStatus Status { set; get; }

        TimeSpan Duration { set; get; }

        Boolean Fullscreen { set; get; }
    }
}
