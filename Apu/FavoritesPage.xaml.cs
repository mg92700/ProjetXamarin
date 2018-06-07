using Apu.Models;
using Apu.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Apu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritesPage : ContentPage
    {
        FavoritesViewModel viewModel;
        public FavoritesPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new FavoritesViewModel();
        }

        public async void OnSelectedCity(object sender, SelectedItemChangedEventArgs e)
        {
            var city = e.SelectedItem as City;
            if (city != null)
            {
                await Navigation.PushAsync(new MainPage(city));
            }
        }

    }
}