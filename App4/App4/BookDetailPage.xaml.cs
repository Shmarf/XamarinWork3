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
    [QueryProperty(nameof(IdBook), nameof(IdBook))] // запрос
    //имя и значение
    public partial class BookDetailPage : ContentPage
    {
        private int idBook;

        public int IdBook
        {
            get => idBook;
            set
            {
                idBook = value;
                if (idBook > 0)
                {
                    SetBook();
                }
            }
        }

        public Book Book { get; set; }

        public BookDetailPage()
        {
            InitializeComponent();
        }

       
        private async void Button_Save(object sender, EventArgs e)
        {
            Book.Name = entryName.Text;
            Book.JanrId = ((Janr)picker.SelectedItem).Id;
            Book.Janr = ((Janr)picker.SelectedItem);
            await App.Database.EditBook(Book);
            await Shell.Current.GoToAsync("..");
        }


        private async void Button_Dell(object sender, EventArgs e)
        {
            Book.Name = entryName.Text;
            await App.Database.DeleteBook(Book);
            await Shell.Current.GoToAsync("..");
        }

        private async void Button_Add(object sender, EventArgs e)
        {
            Book newBook = new Book { Name = entryName.Text, JanrId = ((Janr)picker.SelectedItem).Id};
            Book.Janr = ((Janr)picker.SelectedItem);
            await App.Database.AddBook(newBook);
            await Shell.Current.GoToAsync("..");
        }

        private async void SetBook()
        {
            Book = await App.Database.GetBook(IdBook);

            if (Book != null)
            {
                picker.ItemsSource = await App.Database.GetJanrs();
                picker.SelectedItem = await App.Database.GetJanr(Book.JanrId);
                entryName.Text = Book.Name;
            }


        }


    }
}