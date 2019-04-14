using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Pizaroo
{
    public class PizarooView
    {
        public Texture2D imgBike { get; set; }
        public Texture2D imgCar1 { get; set; }
        public Texture2D imgCar2 { get; set; }
        public Texture2D imgCar3 { get; set; }
        private static Texture2D rectLane;

        public SpriteFont labelFont20 { get; set; }
        public SpriteFont labelFont40 { get; set; }

        public SpriteBatch spriteBatch { get; set; }

        public PizarooView(ContentManager Content, GraphicsDevice graphicsDevice)
        {
            // images
            imgBike = Content.Load<Texture2D>("Vehicle1");
            imgCar1 = Content.Load<Texture2D>("Vehicle2");
            imgCar2 = Content.Load<Texture2D>("Vehicle3");
            imgCar3 = Content.Load<Texture2D>("Vehicle4");

            // sounds


            // fonts
            labelFont20 = Content.Load<SpriteFont>("Arial20");
            labelFont40 = Content.Load<SpriteFont>("Arial40");

            spriteBatch = new SpriteBatch(graphicsDevice);
        }

        public void DrawPlayerVehicle(PlayerVehicle vehicle)
        {
            spriteBatch.Draw(vehicle.imgVehicle, new Vector2(vehicle.X, vehicle.Y), null, Microsoft.Xna.Framework.Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
        }

        public void DrawAIVehicle(int move, AIVehicle vehicle)
        {
            vehicle.Y = vehicle.Y + move;
            if (vehicle.Y > 1700)
            {
                vehicle.Y = -300;
            }
            spriteBatch.Draw(vehicle.imgVehicle, new Vector2(vehicle.X, vehicle.Y), null, Microsoft.Xna.Framework.Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
        }

        public void DrawScore(string msg, int screenWidth)
        {
            spriteBatch.DrawString(labelFont20, msg, new Vector2(screenWidth - 200, 40), Color.Black);
        }

        public void DrawRectangle(Rectangle coords, Color color, GraphicsDevice graphics)
        {
            if (rectLane == null)
            {
                rectLane = new Texture2D(graphics, 1, 1);
                rectLane.SetData(new[] { Color.White });
            }
            spriteBatch.Draw(rectLane, coords, color);
        }
    }
}
