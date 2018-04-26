using System;
using System.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HookUp
{
    public partial class LoginPage : ContentPage
    {
        API api = new API();

        public LoginPage()
        {
            InitializeComponent();
        }

        public async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            ServerResponse response = await api.Authenticate(LoginEmailField.Text, LoginPasswordField.Text);

            if(response.error)
            {
                LoginErrorLabel.Text = "There was an error logging in!";  
            }
            else
            {
                LoginErrorLabel.Text = "";
                await Navigation.PushAsync(new IndexPage());
            }
        }

        //private bool Login()
        //{
        //}
    }
}
