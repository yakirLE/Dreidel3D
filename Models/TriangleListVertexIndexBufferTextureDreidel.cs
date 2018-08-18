using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace C16_Ex04_Yakir_201049475_Omer_300471430.Models
{
    public class TriangleListVertexIndexBufferTextureDreidel : Dreidel
    {
        public TriangleListVertexIndexBufferTextureDreidel(Game i_Game)
            : base(i_Game)
        {
            this.Body = new TriangleListVertexIndexBufferTextureBox(i_Game, Vector3.One * this.DreidelBaseSize);
            this.Handle.SetSolidColor(Color.Red);
            i_Game.Components.Add(this.Body);
        }
    }
}
