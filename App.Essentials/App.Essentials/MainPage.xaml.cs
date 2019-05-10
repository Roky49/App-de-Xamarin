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
            //indicamosque va a ser monitoreado
            if (Accelerometer.IsMonitoring)
                return;
            //Metodo para leer los datos del sensor
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            //Metodo para detectar una sacudida en el dispositivo
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
            //indica la velocidad para controlar el sensor
            Accelerometer.Start(SensorSpeed.Game);
            
            


        }

        private void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
           //paramos el sensor
            Accelerometer.Stop();
            for (int contador=0;contador <= 5;contador++)
            {
                if (contador == 4)
                {
                   //pausamos la aplicaion 5 segundos
                    Thread.Sleep(5000);
                    //Cambiamos la velocidad sensor
                    Accelerometer.Start(SensorSpeed.Fastest);
                }

            }
        }

        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            //definimos un vector3,yaque utiliza esta clase para guardar las cordenadas
            Vector3 vector = new Vector3();
            //guardamos las cordenadas en el objeto(vector3)
            vector.Y = e.Reading.Acceleration.Y;
            vector.X = e.Reading.Acceleration.X;
            vector.Z = e.Reading.Acceleration.Z;

          
            //preguntamos si cada eje es mayor que cero nos dara un color o otro
            if (0 < vector.Y)
            {
                if (0 < vector.X)
                {
                    if (0 < vector.Z)
                    {
                        //Cambiamos el color de la pantalla
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
           
           

            //pasamos el texto para pintar las cordenadas del sernsor
            String text = "Y : " + vector.Y.ToString() +"\nX : "+ vector.X.ToString()+ "\nZ : "+vector.Z.ToString();
            Label.Text = text;
            
        }

      
    }
}
