using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace HookUp
{
    public partial class IndexPage : ContentPage
    {
        API api = new API();
        ObservableCollection<Trip> tripList = new ObservableCollection<Trip>();

        public IndexPage()
        {
            InitializeComponent();
            //GetTrips();
            //TODO pull weather/tide updates 
        }

        public async void GetTrips()
        {
            ServerTripResponse response = (ServerTripResponse) await api.getTrips(API.tripRoute, "");

            if (response.error)
            {
                await DisplayAlert("Error", "Failed to retrieve Trips!", "OK");
            }
            else
            {
                TripListView.ItemsSource = tripList;
                foreach (var trip in response.payload)
                {
                    tripList.Add(new Trip {
                        name = trip.name,
                        location=trip.location,
                        boat=trip.boat,
                        start=trip.start,
                        end=trip.end
                    });
                }
            }
        }

        public async void OnTripSelected(object sender, ItemTappedEventArgs e)
        {
            //await DisplayAlert("TripSelected", "A trip was selected.", "OK");
            Trip trip = (Trip) e.Item;
            await Navigation.PushAsync(new TripPage(trip));
        }

        public async void OnCreateTripPageButtonClicked(object sender, EventArgs e)
        {
            //CreateTrip();
            await Navigation.PushAsync(new CreateTripPage());
        }

        private async void CreateTrip()
        {
            Trip trip = new Trip { name = "Test" };
            ServerResponse response = await api.POST(API.appRoute + API.tripRoute, trip);
        }

        public void GetWeatherUpdate()
        {
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            tripList = new ObservableCollection<Trip>();
            GetTrips();
        }
    }
}
