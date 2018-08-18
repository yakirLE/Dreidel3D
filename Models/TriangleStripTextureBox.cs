using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using C16_Ex04_Yakir_201049475_Omer_300471430.Infrastructure.Models;

namespace C16_Ex04_Yakir_201049475_Omer_300471430.Models
{
    public class TriangleStripTextureBox : VertexPositionTextureObject3D
    {
        private const int k_NumOfTrianglesInABox = 8;
        private VertexPositionTexture[] m_RoofVertices;
        private VertexPositionTexture[] m_FloorVertices;

        public TriangleStripTextureBox(Game i_Game, Vector3 i_Size)
            : base(i_Game, i_Size)
        {
            this.PrimitiveType = PrimitiveType.TriangleStrip;
            this.AssetName = @"GameAssets\NesGagolHayaPo";
        }

        protected override void DrawTechnique()
        {
            base.DrawTechnique();
            this.GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(
                this.PrimitiveType,
                m_RoofVertices,
                this.StartingVertice,
                2);
            this.GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(
                this.PrimitiveType,
                m_FloorVertices,
                this.StartingVertice,
                2);
        }

        public override void Initialize()
        {
            base.Initialize();
            this.TrianglesAmountToDraw = k_NumOfTrianglesInABox;
        }

        protected override void SetVertices()
        {
            Vector3 v0, v1, v2, v3, v4, v5, v6, v7;

            this.Vertices = new VertexPositionTexture[10];
            v0 = new Vector3(-Width / 2, -Height / 2, Depth / 2);
            v1 = new Vector3(-Width / 2, Height / 2, Depth / 2);
            v2 = new Vector3(Width / 2, -Height / 2, Depth / 2);
            v3 = new Vector3(Width / 2, Height / 2, Depth / 2);
            v4 = new Vector3(Width / 2, -Height / 2, -Depth / 2);
            v5 = new Vector3(Width / 2, Height / 2, -Depth / 2);
            v6 = new Vector3(-Width / 2, -Height / 2, -Depth / 2);
            v7 = new Vector3(-Width / 2, Height / 2, -Depth / 2);
            this.Vertices[0] = new VertexPositionTexture(v0, new Vector2(0, 1));
            this.Vertices[1] = new VertexPositionTexture(v1, new Vector2(0, 0));
            this.Vertices[2] = new VertexPositionTexture(v2, new Vector2(0.25f, 1));
            this.Vertices[3] = new VertexPositionTexture(v3, new Vector2(0.25f, 0));
            this.Vertices[4] = new VertexPositionTexture(v4, new Vector2(0.5f, 1));
            this.Vertices[5] = new VertexPositionTexture(v5, new Vector2(0.5f, 0));
            this.Vertices[6] = new VertexPositionTexture(v6, new Vector2(0.75f, 1));
            this.Vertices[7] = new VertexPositionTexture(v7, new Vector2(0.75f, 0));
            this.Vertices[8] = new VertexPositionTexture(v0, new Vector2(1, 1));
            this.Vertices[9] = new VertexPositionTexture(v1, new Vector2(1, 0));
            m_RoofVertices = new VertexPositionTexture[4];
            m_RoofVertices[0] = new VertexPositionTexture(v1, new Vector2(0, 0));
            m_RoofVertices[1] = new VertexPositionTexture(v7, new Vector2(0, 0));
            m_RoofVertices[2] = new VertexPositionTexture(v3, new Vector2(0, 0));
            m_RoofVertices[3] = new VertexPositionTexture(v5, new Vector2(0, 0));
            m_FloorVertices = new VertexPositionTexture[4];
            m_FloorVertices[0] = new VertexPositionTexture(v0, new Vector2(0, 0));
            m_FloorVertices[1] = new VertexPositionTexture(v2, new Vector2(0, 0));
            m_FloorVertices[2] = new VertexPositionTexture(v6, new Vector2(0, 0));
            m_FloorVertices[3] = new VertexPositionTexture(v4, new Vector2(0, 0));
        }
    }
}
