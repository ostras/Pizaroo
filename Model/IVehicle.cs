using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;

namespace Pizaroo.Model
{
    public interface IVehicle
    {
        float X { get; set; } //x position of vehicle on screen
        float Y { get; set; } //y position of vehicle on screen
        float Width { get; set; } //width of vehicle
        float Height { get; set; } //height of vehicle
        float ScreenWidth { get; set; } //width of game screen

        Texture2D imgVehicle { get; set; }  //cached image of the vehicle
    }
}
