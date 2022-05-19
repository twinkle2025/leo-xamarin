using Leo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Leo.Models.APITemplate;

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

        async void SignInButton_Clicked(object sender, EventArgs e)
        {
            if (!ValidateSignInData()) return;

            _loginInfo.UserName = Username_SignIn.Text;
            _loginInfo.Password = Password_SignIn.Text;

            //APIResponse apiRes = await _loginViewModel.SignIn(_loginInfo);
        }
    }
}