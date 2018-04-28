using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HookUp
{
    public partial class CreateTripPage : ContentPage
    {
        API api = new API();

        public CreateTripPage()
        {
            InitializeComponent();
            Start.Date = DateTime.Now;
            End.Date = DateTime.Now;
        }

        public async void OnCreateTripButtonClicked(object sender, EventArgs e)
        {
            Trip newTrip = new Trip
            {
                boat = Boat.Text,
                location = Location.Text,
                start = Start.Date.ToString(),
                end = End.Date.ToString()
            };

            ServerTripResponse response = (ServerTripResponse) await api.createTrip(newTrip);

            if (response.error)
            {
                await DisplayAlert("Error", "Failed to create Trip!", "OK");
            }
            else
            {
                Boat.Text = "";
                Location.Text = "";
                Start.Date = DateTime.Now;
                End.Date = DateTime.Now;
            }
        }


    }
}
