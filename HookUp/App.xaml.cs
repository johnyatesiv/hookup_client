using System.Collections.Generic;
using Xamarin.Forms;

namespace HookUp
{
    public class AuthData
    {
        public AuthData() { }
        public string token { get; set; }
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

    public class User
    {
        public User()
        {
            
        }

        public string email { get; set; }
        public string password { get; set; }
        //public int age { get; set; }
        public bool drink { get; set; }
        public bool smoke { get; set; }
        public bool weed { get; set; }
        public bool noise { get; set; }
    }

    public partial class ServerResponse
    {
        public bool error;
        public string message;
    }

    public partial class AuthResponse : ServerResponse
    {
        public AuthData payload;
    }

    public class ServerTripResponse : ServerResponse
    {
        public List<Trip> payload;
    }

    public partial class ServerUserResponse : ServerResponse
    {
        public List<User> payload;
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
