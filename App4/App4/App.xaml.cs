using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4
{
    public partial class App : Application
    {
        private static Database database; 

        public static Database Database // static он один, не нужен создавать эк. класса
        {
            get
            {
                if (database == null)
                    database = new Database(); //экземпляр класса
                return database;

            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
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
