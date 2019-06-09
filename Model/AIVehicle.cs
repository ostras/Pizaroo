using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pizaroo.Model
{
    public class AIVehicle : IVehicle
    {

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

        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float ScreenWidth { get; set; }
        public Texture2D imgVehicle { get; set; }

        public void MoveVehicle(int move)
        {
            Y = Y + move;
            if (Y > 1700)
            {
                Y = -300;
            }
        }

        public void ResetPosition()
        {
            Y = 10;
        }
    }
}
