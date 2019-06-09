using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pizaroo.Model;

namespace Pizaroo
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameController : Game
    {
        GraphicsDeviceManager graphics;
        PizarooView pizarooView;

        int laneOffset = 0;

        private PlayerVehicle playerVehicle;
        private IVehicle vehicle1, vehicle2, vehicle3, vehicle4, vehicle5;
        private int screenWidth = 0;
        private int screenHeight = 0;
        int score = 0;

        ArrayList scores = new ArrayList();

        bool collision = false;
        string gameOverMsg = "Game Over!";
        string scoreTableMsg = "Max Scores";
        string playAgainMsg = "Press <SPACE> to play again!";

        private KeyboardState oldKeyboardState;

        // Events & Delegates
        public delegate void PlayerMoved(Keys key);
        public static event PlayerMoved playerMovedInfo;

        public delegate void CollisionHappened();
        public static event CollisionHappened collisionHappenedInfo;

        public GameController()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            GameController.collisionHappenedInfo += CollisionHappenedListener;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            pizarooView = new PizarooView(Content, GraphicsDevice);

            //screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            screenWidth = 1250;
            screenHeight = 1600;

            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges();

            //create game objects
            int vehicleX = 75; // Player initial position
            int vehicleY = screenHeight - 220;  // Vehicle position on the vertical axis
            playerVehicle = new PlayerVehicle(vehicleX, vehicleY, screenWidth, pizarooView);  // create the player
            playerMovedInfo += playerVehicle.PlayerMovedListener;

            vehicle1 = new AIVehicle(25, 10, screenWidth, pizarooView, 1);
            vehicle2 = new AIVehicle(275, 400, screenWidth, pizarooView, 2);
            vehicle3 = new AIVehicle(540, 800, screenWidth, pizarooView, 3);
            vehicle4 = new AIVehicle(775, 1200, screenWidth, pizarooView, 2);
            vehicle5 = new AIVehicle(1025, 10, screenWidth, pizarooView, 1);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (IsActive == false)
            {
                return;  //our window is not active don't update
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState newKeyboardState = Keyboard.GetState();

            //process keyboard events                           
            if (newKeyboardState.IsKeyDown(Keys.Left) && !oldKeyboardState.IsKeyDown(Keys.Left))
            {
                playerMovedInfo(Keys.Left);
            }
            if (newKeyboardState.IsKeyDown(Keys.Right) && !oldKeyboardState.IsKeyDown(Keys.Right))
            {
                playerMovedInfo(Keys.Right);
            }
            // Restart Game
            if (newKeyboardState.IsKeyDown(Keys.Space) && !oldKeyboardState.IsKeyDown(Keys.Space))
            {
                collision = false;
                score = 0;
            }

            //oldKeyboardState = newKeyboardState; // this saves the old state      
            oldKeyboardState = newKeyboardState;

            // Update score and lane offset
            score++;
            laneOffset = laneOffset + 10;

            if (laneOffset == 100)
            {
                laneOffset = 0;
            }

            // Collision detection
            //collision = false;
            if (playerVehicle.X == 75 && (playerVehicle.Y - vehicle1.Y) < 200)
            {
                collision = true;
                vehicle1.ResetPosition();

                collisionHappenedInfo();
            }
            else if (playerVehicle.X == 325 && (playerVehicle.Y - vehicle2.Y) < 200)
            {
                collision = true;
                vehicle2.ResetPosition();

                collisionHappenedInfo();
            }
            else if (playerVehicle.X == 575 && (playerVehicle.Y - vehicle3.Y) < 200)
            {
                collision = true;
                vehicle3.ResetPosition();

                collisionHappenedInfo();
            }
            else if (playerVehicle.X == 825 && (playerVehicle.Y - vehicle4.Y) < 200)
            {
                collision = true;
                vehicle4.ResetPosition();

                collisionHappenedInfo();
            }
            else if (playerVehicle.X == 1075 && (playerVehicle.Y - vehicle5.Y) < 200)
            {
                collision = true;
                vehicle5.ResetPosition();

                collisionHappenedInfo();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Controller calls methods on View for drawing game elements
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (!collision)
            {
                GraphicsDevice.Clear(Color.DimGray);
                string scoreMsg = "Score: " + score;

                pizarooView.spriteBatch.Begin();

                // Player vehicle
                pizarooView.DrawVehicle(0, playerVehicle);

                // AI vehicles
                if (!collision)
                {
                    pizarooView.DrawVehicle(11, vehicle1);
                    pizarooView.DrawVehicle(14, vehicle2);
                    pizarooView.DrawVehicle(15, vehicle3);
                    pizarooView.DrawVehicle(13, vehicle4);
                    pizarooView.DrawVehicle(12, vehicle5);
                }

                // Score
                pizarooView.DrawScore(scoreMsg, screenWidth);

                // Highway lanes
                for (int posYLane = -150; posYLane < 1600; posYLane = posYLane + 150)
                {
                    pizarooView.DrawRectangle(new Rectangle((int)250, (int)posYLane + laneOffset, 10, 100), Color.White, graphics.GraphicsDevice);
                    pizarooView.DrawRectangle(new Rectangle((int)500, (int)posYLane + laneOffset, 10, 100), Color.White, graphics.GraphicsDevice);
                    pizarooView.DrawRectangle(new Rectangle((int)750, (int)posYLane + laneOffset, 10, 100), Color.White, graphics.GraphicsDevice);
                    pizarooView.DrawRectangle(new Rectangle((int)1000, (int)posYLane + laneOffset, 10, 100), Color.White, graphics.GraphicsDevice);
                }

                pizarooView.spriteBatch.End();

                base.Draw(gameTime);
            }

            else
            {
                GraphicsDevice.Clear(Color.DimGray);

                pizarooView.spriteBatch.Begin();


                // Game over
                pizarooView.spriteBatch.DrawString(pizarooView.labelFont40, gameOverMsg, new Vector2(screenWidth / 2 - 160, 20), Color.Red);

                // Scores
                pizarooView.spriteBatch.DrawString(pizarooView.labelFont20, scoreTableMsg, new Vector2(screenWidth / 2 - 110, 120), Color.Black);

                int scoreYPos = 170;
                int pos = 1;

                foreach (int val in scores)
                {
                    string finalScoreMsg = pos.ToString() + ". " + val;
                    pizarooView.spriteBatch.DrawString(pizarooView.labelFont20, finalScoreMsg, new Vector2(screenWidth / 2 - 80, scoreYPos), Color.Black);

                    scoreYPos = scoreYPos + 40;
                    pos++;
                    if (pos == 21) break;
                }

                // Play Again
                pizarooView.spriteBatch.DrawString(pizarooView.labelFont40, playAgainMsg, new Vector2(screenWidth / 2 - 350, 1100), Color.Black);

                pizarooView.spriteBatch.End();

                base.Draw(gameTime);
            }
        }

        void CollisionHappenedListener()
        {
            IEnumerable<String> lines = null;

            try
            {
                lines = File.ReadLines("scores.txt");

            }
            catch (System.IO.FileNotFoundException fnfe)
            {
                pizarooView.HandleExceptionMessage("Scores file doesn't exist", fnfe);
                Exit();
            }

            scores.Clear();

            foreach (string sc in lines)
            {
                scores.Add(Int32.Parse(sc));
            }

            scores.Add(score);
            scores.Sort();
            scores.Reverse();

            try
            {
                FileStream fs = File.Open("scores.txt", FileMode.Append);

                StreamWriter stream = new StreamWriter(fs);
                stream.WriteLine(score);

                stream.Close();

            }
            catch (System.IO.IOException ioe)
            {
                pizarooView.HandleExceptionMessage("Error writing scores to file", ioe);
                Exit();
            }

            score = 0;
        }
    }
}
