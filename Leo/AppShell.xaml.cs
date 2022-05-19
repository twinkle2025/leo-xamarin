using Leo.ViewModels;
using Leo.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Leo
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public Dictionary<string, Type> Routes { get; set; } = new Dictionary<string, Type>();
        public AppShell()
        {
            InitializeComponent();
            registerRoute();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        void registerRoute()
        {
            Routes.Add("LoginPage", typeof(LoginPage));
            Routes.Add("Home", typeof(HomePage));
            foreach(var item in Routes )
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
