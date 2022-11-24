using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(JanrDetailPage), typeof(JanrDetailPage)); // маршрут, регистрируем путь (имя), (тип)
            Routing.RegisterRoute(nameof(BookDetailPage), typeof(BookDetailPage));
            Routing.RegisterRoute(nameof(LibraryDetailPage), typeof(LibraryDetailPage));


        }
        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            Current.GoToAsync("//LoginPage"); //чтобы перейти на tabbar 
        }
    }
}