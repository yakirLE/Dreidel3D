using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using C16_Ex04_Yakir_201049475_Omer_300471430.Infrastructure.Models;

namespace C16_Ex04_Yakir_201049475_Omer_300471430
{
    public abstract class VertexPositionColorObject3D : PrimitiveObject3D
    {
        private VertexPositionColor[] m_Vertices;

        protected VertexPositionColor[] Vertices
        {
            get { return m_Vertices; }
            set { m_Vertices = value; }
        }

        public VertexPositionColorObject3D(Game i_Game, Vector3 i_Size)
            : base(i_Game, i_Size)
        {
        }

        protected override void DrawTechnique()
        {
            this.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                this.PrimitiveType,
                this.Vertices,
                this.StartingVertice,
                this.TrianglesAmountToDraw);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            this.BasicEffect.VertexColorEnabled = true;
        }
    }
}
