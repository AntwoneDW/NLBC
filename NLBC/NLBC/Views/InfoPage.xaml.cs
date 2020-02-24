using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NLBC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        private static System.Timers.Timer aTimer;
        private Random random = new Random();
        private static string currentImage = "nyc_next_level.png";
        public static string[] images = {
            "next_level_people_2.png",
            "next_level_people_3.jpg",
            "next_level_people.png",
            "next_level_hands.png",
            "nyc_next_level.png"
        };
        public InfoPage()
        {
            InitializeComponent();
            SetTimer();
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            //aTimer.Start();
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
            //                 e.SignalTime);
            string selectedFileName = currentImage;
            while(selectedFileName == currentImage)
            {
                selectedFileName = images[random.Next(images.Length)];
            }
            currentImage = selectedFileName;
            theImage.Source = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile(selectedFileName)
                : ImageSource.FromFile("Images/"+ selectedFileName);
        }

    }
}