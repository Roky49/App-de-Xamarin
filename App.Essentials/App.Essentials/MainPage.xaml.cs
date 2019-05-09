using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Numerics;
using System.Threading;

namespace App.Essentials
{
    public partial class MainPage : ContentPage
    {
         

        public MainPage()
        {
            InitializeComponent();
            if (Accelerometer.IsMonitoring)
                return;
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
            Accelerometer.Start(SensorSpeed.Game);
            
            


        }

        private void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
           
            Accelerometer.Stop();
            for (int contador=0;contador <= 5;contador++)
            {
                if (contador == 4)
                {
                   
                    Thread.Sleep(5000);
                    Accelerometer.Start(SensorSpeed.Fastest);
                }

            }
        }

        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            Vector3 vector = new Vector3();
            vector.Y = e.Reading.Acceleration.Y;
           vector.X = e.Reading.Acceleration.X;
            vector.Z = e.Reading.Acceleration.Z;

          

            if (0 < vector.Y)
            {

              

                if (0 < vector.X)
                {

                   
                    if (0 < vector.Z)
                    {

                        color.BackgroundColor = Color.FromRgb(243, 8, 8);
                    }
                    else
                    {
                        color.BackgroundColor = Color.FromRgb(104, 244, 82);
                    }
                }
                else
                {
                    
                    if (0 < vector.Z)
                    {

                        color.BackgroundColor = Color.FromRgb(9, 143, 248);
                    }
                    else
                    {
                        color.BackgroundColor = Color.FromRgb(85, 173, 243);
                    }
                }
            }
            else
            {
               
                if (0 < vector.X)
                {

                   
                    if (0 < vector.Z)
                    {

                        color.BackgroundColor = Color.FromRgb(52, 30, 240);
                    }
                    else
                    {
                        color.BackgroundColor = Color.FromRgb(118, 103, 238);
                    }
                }
                else
                {
                    
                    if (0 < vector.Z)
                    {

                        color.BackgroundColor = Color.FromRgb(249, 17, 17);
                    }
                    else
                    {
                        color.BackgroundColor = Color.FromRgb(247, 104, 104);
                    }
                }
            }
           
           


            String text = "Y : " + vector.Y.ToString() +"\nX : "+ vector.X.ToString()+ "\nZ : "+vector.Z.ToString();


            Label.Text = text;
            
        }

      
    }
}
