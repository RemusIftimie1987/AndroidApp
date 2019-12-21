using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace AndroidTutorial
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecondPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (var con = new SQLite.SQLiteConnection(App.FilePath))
            {
                //Create a table "Dummy" if it doesn't exist
                con.CreateTable<Dummy>();

                var mydummy = new Dummy() { Age = 1231242, Name = "HELLO WORLD" };

                int rowsAdded = con.Insert(mydummy);

                var dummyFromDB = con.Table<Dummy>().ToList();

                Age.Text = dummyFromDB.First().Age.ToString();
                Name.Text = dummyFromDB.First().Name;
            }
        }

        public class Dummy
        {
            public int Age { get; set; }
            public string Name { get; set; }
        }
    }
}
