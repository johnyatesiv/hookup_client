using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HookUp
{
    public partial class TripPage : ContentPage
    {
        public TripPage(Trip trip)
        {
            InitializeComponent();
            PopulateTripDetails(trip);
        }

        public void PopulateTripDetails(Trip trip)
        {
            //TripName.Text = trip.name;
            TripBoat.Text = trip.boat;
            TripLocation.Text = "Departing from "+trip.location+" at";
            TripStart.Text = trip.start;
            TripEnd.Text = trip.end;

        }
    }
}
