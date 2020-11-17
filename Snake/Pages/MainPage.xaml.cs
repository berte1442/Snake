using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Snake
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        string direction = "right";
        int difficulty = 1000;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Up_Clicked(object sender, EventArgs e)
        {
            direction = "up";
        }

        private async void Left_Clicked(object sender, EventArgs e)
        {
            direction = "left";
            while (direction.ToLower() == "left")
            {
            }
        }

        private async void Right_Clicked(object sender, EventArgs e)
        {
            var x = 10;
            direction = "right";
            while(direction.ToLower() == "right")
            {
                await Snake.TranslateTo(x, Snake.Y, 250, Easing.Linear);
                x += 10;
            }
        }

        private void Down_Clicked(object sender, EventArgs e)
        {
            direction = "down";
        }

        private async void Start_Clicked(object sender, EventArgs e)
        {
            Start.IsEnabled = false;
            //var foodMargin = await Food();
            //SnakeFood.Margin = foodMargin;
            //SnakeFood.Text = "*";
            Food();
            Right_Clicked(sender, e); 

        }

        private void Food()
        {
            Random random = new Random();

            var x = random.Next(0, Convert.ToInt32(Frame.Width));
            var y = random.Next(0, Convert.ToInt32(Frame.Height));
            SnakeFood.Text = "*";
            SnakeFood.TranslateTo(x, y, 250, default);
        }
    }
}
