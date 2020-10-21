using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MediaStuff.v2
{
    public partial class MyPage : ContentPage
    {
        public MyPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            nextButton.IsEnabled = true;
        }

        async void Button_Pressed(System.Object sender, System.EventArgs e)
        {
            nextButton.IsEnabled = false;
            await Navigation.PushAsync(new MainPage());

        }

    }
}
