using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HookUp
{
    public partial class RegisterPage : ContentPage
    {
        API api = new API();

        public RegisterPage()
        {
            InitializeComponent();
        }

        public async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            RegisterButton.IsEnabled = false;

            User user = new User{
                email=RegisterEmailField.Text,
                password=RegisterPasswordField.Text
            };

            AuthResponse response = await api.Register(user);

            if (response.error)
            {
                await DisplayAlert("Error", "There was an error logging in!", "OK");
                RegisterButton.IsEnabled = true;
            }
            else
            {
                RegisterButton.IsEnabled = true;
                RegisterErrorLabel.Text = "";
                await Navigation.PushAsync(new IndexPage());
            }
        }
    }
}
