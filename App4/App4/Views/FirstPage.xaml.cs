using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstPage : ContentPage
    {

        public FirstPage()
        {
            InitializeComponent();
            ToLoginPage();
            GetItemsToCollection();
        }

        //доступ к защищенному элементу
        protected override async void OnAppearing()
        {
            collectionView.ItemsSource = new List<Janr>();
            collectionView.ItemsSource = await App.Database.GetJanrs();
            collectionView.SelectedItem = null;
            base.OnAppearing();
        }

        private async void GetItemsToCollection()
        {
            collectionView.ItemsSource = await App.Database.GetJanrs();
        }

        private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (collectionView.SelectedItem !=null)
            {
            
                Shell.Current.GoToAsync($"{nameof(JanrDetailPage)}?{nameof(JanrDetailPage.JanrId)}={((Janr)collectionView.SelectedItem).Id}");
                //у selecteed item типа данных object а там нет; ?  - разделение, слева адрессат а справа запрос, преобраз данный
            }
        }


        private async void ToLoginPage()
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }


}