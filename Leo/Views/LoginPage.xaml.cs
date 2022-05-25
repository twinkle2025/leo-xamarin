using Leo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Leo.Models.APITemplate;
using Leo.Services;
using Xamarin.Essentials;

namespace Leo.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel _loginViewModel;
        Login _loginInfo;

        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
            _loginInfo = new Login();

            _loginViewModel = new LoginViewModel();
        }

        bool ValidateSignInData()
        {
            if(string.IsNullOrEmpty(Username_SignIn.Text) || string.IsNullOrEmpty(Password_SignIn.Text))
            {
                return false;
            }

            return true;
        }

        async Task SaveUserInfo()
        {
            try
            {
                await SecureStorage.SetAsync("username", Username_SignIn.Text);
                await SecureStorage.SetAsync("password", Password_SignIn.Text);
            }
            catch(Exception ex)
            {

            }
        }

        async void SignInButton_Clicked(object sender, EventArgs e)
        {
            if (!ValidateSignInData()) return;
            LoadingPage.IsVisible = true;

            _loginInfo.UserName = Username_SignIn.Text;
            _loginInfo.Password = Password_SignIn.Text;

            //APIResponse apiRes = await _loginVixewModel.SignIn(_loginInfo);
            //Debug_SignIn.Text = "Please check your network connection.";
            SignInTab.IsVisible = true;

            await SaveUserInfo();

            //await Accounts.SaveToken(App.LoggedUser.Token);
            App.Current.MainPage = new AppShell();
        }
    }
}