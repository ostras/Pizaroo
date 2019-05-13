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

            GameController.playerMovedInfo += PlayerMovedListener;
        }

        public float X { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float Y { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float Width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float ScreenWidth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Texture2D imgVehicle { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

        void PlayerMovedListener(Keys keyPressed)
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
