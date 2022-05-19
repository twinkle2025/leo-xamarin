using Leo.Services;
using Leo.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Leo.Models.APITemplate;
using System.Threading.Tasks;


namespace Leo
{
    public partial class App : Application
    {
        public static LoginSuccess LoggedUser = null;

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            if(Task.Run(async() => await Accounts.GetToken()).GetAwaiter().GetResult())
            {
                MainPage = new AppShell();
            }
            else
            {
                MainPage = new LoginPage();
            }
            //MainPage = new LoginPage();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
