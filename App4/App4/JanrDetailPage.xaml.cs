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
    [QueryProperty(nameof(JanrId), nameof(JanrId))]
    public partial class JanrDetailPage : ContentPage
    {
        private int janrId;
        public int JanrId
        {
            get => janrId;
            set
            {
                janrId = value;
                if (janrId > 0)
                {
                    SetJanr();
                }

            }
        }



        public Janr Janr { get; set; }

        public JanrDetailPage()
        {
            InitializeComponent();

        }

        private async void Button_Save(object sender, EventArgs e)
        {
            Janr.Name = entryName.Text;
            await App.Database.EditJanr(Janr);
            await Shell.Current.GoToAsync("..");
        }


        private async void Button_Dell(object sender, EventArgs e)
        {
            Janr.Name = entryName.Text;
            await App.Database.DeleteJanr(Janr);
            await Shell.Current.GoToAsync("..");
        }

        private async void Button_Add(object sender, EventArgs e)
        {
            Janr newJanr = new Janr { Name = entryName.Text };
            await App.Database.AddJanr(newJanr);
            await Shell.Current.GoToAsync("..");
        }
        private async void SetJanr()
        {
            Janr = await App.Database.GetJanr(JanrId);
             entryName.Text = Janr.Name;
        }
    }
}