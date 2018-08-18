using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace C16_Ex04_Yakir_201049475_Omer_300471430
{
    public interface ICamera3DManager
    {
        Matrix CameraSettings { get; set; }

        Matrix CameraState { get; set; }
    }
}
