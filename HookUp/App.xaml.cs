using System.Collections.Generic;
using Xamarin.Forms;

namespace HookUp
{
    public partial class ServerResponse
    {
        public bool error;
        public string message;
    }

    public class Trip
    {
        public Trip()
        {
            
        }

        //public string _id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string boat { get; set; }
        public int numPeople { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Person
    {
        public Person()
        {
            
        }

        public string name { get; set; }
        public int age { get; set; }
        public int drink { get; set; }
        public int smoke { get; set; }
        public int noise { get; set; }
    }

    public class ServerTripResponse : ServerResponse
    {
        public List<Trip> payload;
    }

    public partial class ServerPeopleResponse : ServerResponse
    {
        public List<Person> payload;
    }

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var page = new NavigationPage(new LoginPage());
            MainPage = page;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
