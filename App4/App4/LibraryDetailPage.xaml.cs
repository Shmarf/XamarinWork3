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
    [QueryProperty(nameof(BookId ), nameof(BookId))]



    public partial class LibraryDetailPage : ContentPage
    {

        private int bookId;
        public int BookId
        {
            get => BookId;
            set
            {
                bookId = value;

                if (bookId > 0)
                {
                    SetBook();



                }

            }
        }

        

        public Book Book { get; set; }

      

        public LibraryDetailPage()
        {
            InitializeComponent();
        }

        private async void SetBook()
        {
            Book = await App.Database.GetBook(BookId);
           


        }

    }
}