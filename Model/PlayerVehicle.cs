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

namespace Pizaroo
{
    public class PlayerVehicle
    {

        public float X { get; set; } //x position of player on screen
        public float Y { get; set; } //y position of player on screen
        public float Width { get; set; } //width of player
        public float Height { get; set; } //height of player
        public float ScreenWidth { get; set; } //width of game screen

        public Texture2D imgVehicle { get; set; }  //cached image of the player
        
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
