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
    public class TriangleListVertexIndexBufferTextureBox : VertexPositionTextureObject3D
    {
        private const int k_NumOfTrianglesInABox = 12;
        private const int k_AmountOfVerticesInABox = 8;
        private int m_StartingIndex;
        private int m_MinVertexIndex;
        private bool m_WasVerticesSet;
        private VertexBuffer m_VertexBuffer;
        private IndexBuffer m_IndexBuffer;
        private short[] m_Indices;
        private VertexPositionTexture[] m_RoofVertices;

        public TriangleListVertexIndexBufferTextureBox(Game i_Game, Vector3 i_Size)
            : base(i_Game, i_Size)
        {
            m_WasVerticesSet = false;
            SetVertices();
            m_StartingIndex = m_MinVertexIndex = 0;
            this.PrimitiveType = PrimitiveType.TriangleList;
            this.AssetName = @"GameAssets\NesGagolHayaPo";
        }

        protected override void SetVertices()
        {
            if (!m_WasVerticesSet)
            {
                createVertices();
                createIndexes();
                m_WasVerticesSet = true;
            }
        }

        protected override void DrawTechnique()
        {
            this.BasicEffect.GraphicsDevice.DrawIndexedPrimitives(
                this.PrimitiveType,
                this.StartingVertice,
                m_MinVertexIndex,
                m_VertexBuffer.VertexCount,
                m_StartingIndex,
                k_NumOfTrianglesInABox);
            this.GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(
                PrimitiveType.TriangleStrip,
                m_RoofVertices,
                this.StartingVertice,
                2);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            m_VertexBuffer = new VertexBuffer(
                this.GraphicsDevice,
                typeof(VertexPositionTexture),
                this.Vertices.Length,
                BufferUsage.WriteOnly);
            m_VertexBuffer.SetData(this.Vertices, this.StartingVertice, this.Vertices.Length);
            m_IndexBuffer = new IndexBuffer(
                this.GraphicsDevice,
                typeof(short),
                m_Indices.Length,
                BufferUsage.WriteOnly);
            m_IndexBuffer.SetData(m_Indices);
        }

        public override void Draw(GameTime i_GameTime)
        {
            this.BasicEffect.GraphicsDevice.Indices = m_IndexBuffer;
            this.BasicEffect.GraphicsDevice.SetVertexBuffer(m_VertexBuffer);
            base.Draw(i_GameTime);
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
            if(this.BasicEffect != null)
            {
                m_VertexBuffer.Dispose();
                m_IndexBuffer.Dispose();
            }
        }

        private void createVertices()
        {
            Vector3 v0, v1, v2, v3, v4, v5, v6, v7;

            this.Vertices = new VertexPositionTexture[k_AmountOfVerticesInABox + 2];
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
        }

        private void createIndexes()
        {
            m_Indices = new short[k_NumOfTrianglesInABox * 3];
            m_Indices[0] = 0;
            m_Indices[1] = 1;
            m_Indices[2] = 2;
            m_Indices[3] = 1;
            m_Indices[4] = 3;
            m_Indices[5] = 2;
            m_Indices[6] = 2;
            m_Indices[7] = 3;
            m_Indices[8] = 4;
            m_Indices[9] = 3;
            m_Indices[10] = 5;
            m_Indices[11] = 4;
            m_Indices[12] = 4;
            m_Indices[13] = 5;
            m_Indices[14] = 6;
            m_Indices[15] = 6;
            m_Indices[16] = 5;
            m_Indices[17] = 7;
            m_Indices[18] = 8;
            m_Indices[19] = 6;
            m_Indices[20] = 9;
            m_Indices[21] = 9;
            m_Indices[22] = 6;
            m_Indices[23] = 7;
            m_Indices[24] = 1;
            m_Indices[25] = 7;
            m_Indices[26] = 3;
            m_Indices[27] = 7;
            m_Indices[28] = 5;
            m_Indices[29] = 3;
            m_Indices[30] = 0;
            m_Indices[31] = 2;
            m_Indices[32] = 6;
            m_Indices[33] = 2;
            m_Indices[34] = 4;
            m_Indices[35] = 6;
        }
    }
}
