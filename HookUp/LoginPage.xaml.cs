using System;
using Xamarin.Forms;

namespace HookUp
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public void OnLoginButtonClicked(object sender, EventArgs e)
        {
            LoginErrorLabel.Text = "There was an error logging in!";
            Navigation.PushAsync(new IndexPage());
        }
    }
}
