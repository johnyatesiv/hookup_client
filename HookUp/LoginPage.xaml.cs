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
            LoginButton.IsEnabled = false;
            AuthResponse response = await api.Authenticate(LoginEmailField.Text, LoginPasswordField.Text);

            if(response.error)
            {
                await DisplayAlert("Error", "There was an error logging in!", "OK");
                LoginButton.IsEnabled = true;
            }
            else
            {
                LoginButton.IsEnabled = true;
                LoginErrorLabel.Text = "";
                await Navigation.PushAsync(new IndexPage());
            }
        }

        public async void OnRegisterPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}
