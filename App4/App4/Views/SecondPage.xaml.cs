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
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
            GetItemsToCollection();
        }

        protected override async void OnAppearing()
        {
            collectionView.ItemsSource = new List<Book>();
            collectionView.ItemsSource = await App.Database.GetBooks();
            collectionView.SelectedItem = null;
            base.OnAppearing();
        }

        private async void GetItemsToCollection()
        {
            collectionView.ItemsSource = await App.Database.GetBooks();
        }

        private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (collectionView.SelectedItem != null)
            {
                Shell.Current.GoToAsync($"{nameof(BookDetailPage)}?{nameof(BookDetailPage.IdBook)}={((Book)collectionView.SelectedItem).Id}");                                  //у selecteed item типа данных object а там нет; ?  - разделение, слева адрессат а справа запрос
                // маршрут страница параметры страницы
            }
        }
    }
}