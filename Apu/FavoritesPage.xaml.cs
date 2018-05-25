using System;
using System.Collections.Generic;
using Apu.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Apu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritesPage : ContentPage
    {

        FavoritesViewModel ViewModels;
        public FavoritesPage()
        {
            InitializeComponent();
            BindingContext = ViewModels = new FavoritesViewModel();
        }
    }
}
