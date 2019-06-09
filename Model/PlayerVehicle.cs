using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Pizaroo.Model
{
    public class PlayerVehicle : IVehicle
    {
        
        public PlayerVehicle(float x, float y, float screenWidth, PizarooView pizarooView)
        {
            X = x;
            Y = y;
            imgVehicle = pizarooView.imgBike;
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

        public void MoveLeft()
        {
            if (X > 255)
            {
                X = X - 250;
            }
        }

        public void MoveRight()
        {
            if (X < 925)
            {
                X = X + 250;
            }
        }

        public void ResetPosition()
        {
            Y = 10;
        }

        public void PlayerMovedListener(Keys keyPressed)
        {
            if (keyPressed == Keys.Left)
            {
                MoveLeft();
            }
            else if (keyPressed == Keys.Right)
            {
                MoveRight();
            }
        }
    }
}
