using System;
using Xamarin.Forms;

namespace MediaStuff.v2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            mediaPlayer.Pause();
            base.OnDisappearing();
        }


        private void mediaPlayer_SizeChanged(object sender, EventArgs e)
        {
            if(mediaPlayer.Fullscreen)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
            else
            {
                NavigationPage.SetHasNavigationBar(this, true);
            }
        }
    }
}
