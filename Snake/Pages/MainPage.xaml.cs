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

        private void Left_Clicked(object sender, EventArgs e)
        {
            direction = "left";
        }

        private async void Right_Clicked(object sender, EventArgs e)
        {
            direction = "right";
            while(direction.ToLower() == "right")
            {
                Snake.Padding = await RightClickAsync();
            }
        }

        private void Down_Clicked(object sender, EventArgs e)
        {
            direction = "down";
        }

        private async void Start_Clicked(object sender, EventArgs e)
        {
            Start.IsEnabled = false;
            var foodMargin = await Food();
            SnakeFood.Margin = foodMargin;
            SnakeFood.Text = "*";
            Right_Clicked(sender, e);           

        }

        private async Task<Thickness> RightClickAsync()
        {
            System.Threading.Thread.Sleep(difficulty);
            var padding = await Task.Run(() => MovingRight());

            return padding;
        }
        private Thickness MovingRight()
        {

            var left = int.Parse(Snake.Padding.Left.ToString());
            //var right = int.Parse(Snake.Padding.Right.ToString());
            //var top = int.Parse(Snake.Padding.Top.ToString());
            //var bottom = int.Parse(Snake.Padding.Bottom.ToString());
            left += 10;

            var snakePadding = Snake.Padding;
            snakePadding.Left = left;
            //Snake.Padding = snakePadding;
            return snakePadding;
        }

        private async Task<Thickness> Food()
        {
            var width = Frame.Width;
            var height = Frame.Height;
            var foodMargin = SnakeFood.Margin;
            Random random = new Random();
            foodMargin.Left = random.Next(0, Convert.ToInt32(width/2));
            foodMargin.Right = random.Next(0, Convert.ToInt32(width/2));
            foodMargin.Top = random.Next(0, Convert.ToInt32(height/2));
            foodMargin.Bottom = random.Next(0, Convert.ToInt32(height/2));

            return foodMargin;
        }
    }
}
