using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pizaroo
{
    public class AIVehicle {

        public float X { get; set; } //x position of vehicle on screen
        public float Y { get; set; } //y position of vehicle on screen
        public float Width { get; set; } //width of vehicle
        public float Height { get; set; } //height of vehicle
        public float ScreenWidth { get; set; } //width of game screen

        public Texture2D imgVehicle { get; set; }  //cached image of the vehicle

        public AIVehicle(float x, float y, float screenWidth, PizarooView pizarooView, int vehicleNum)
        {
            X = x;
            Y = y;
            if (vehicleNum == 1) {
                imgVehicle = pizarooView.imgCar1;
            }
            else if (vehicleNum == 2)
            {
                imgVehicle = pizarooView.imgCar2;
            }
            else if (vehicleNum == 3)
            {
                imgVehicle = pizarooView.imgCar3;
            }

            Width = imgVehicle.Width;
            Height = imgVehicle.Height;
            ScreenWidth = screenWidth;
        }
    }
}
