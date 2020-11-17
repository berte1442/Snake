using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Snake
{
    public partial class App : Application
    {
        static SnakeDatabase database;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
        public static SnakeDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new SnakeDatabase(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "Snake_Database");
                }
                return database;
            }
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
