using System;
using Apu.Data;
using Apu.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Apu
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Apu.Master();
        }
         private static ApuDataBase db;
        public static ApuDataBase DB
        {
            get
            {
                
                if (db == null)
                {
                    db = new ApuDataBase(DependencyService.Get<IFileHelper>().GetLocalFilePath("ApuSQLite.db3"));
                }
                return db;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
